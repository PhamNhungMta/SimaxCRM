using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using SimaxCrm.Data.Repository.Interface;

namespace SimaxShop.Service.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IConfiguration _configuration;

        public CompanyService(ICompanyRepository companyRepository, IConfiguration configuration)
        {
            _companyRepository = companyRepository;
            _configuration = configuration;
        }

        public List<Company> List()
        {
            return _companyRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public Company ById(string Id)
        {
            return _companyRepository.SearchFor(x => x.Id == Id, "Branches").FirstOrDefault();
        }

        public Company ByName(string Name)
        {
            return _companyRepository.SearchFor(x => x.Name.ToLower() == Name.ToLower()).FirstOrDefault();
        }

        public Company ByIdAndName(string Id, string Name)
        {
            return _companyRepository.SearchFor(x => x.Id == Id && x.Name.ToLower() == Name.ToLower()).FirstOrDefault();
        }

        public void Create(Company company)
        {
            _companyRepository.Insert(company);
        }

        public void Update(Company company)
        {
            _companyRepository.UpdateEntity(company);
        }

        private async Task<string> GetAccessTokenRequest()
        {
            var url = _configuration["PriceHublleBaseURL"] + "/auth/login/credentials";

            var httpClient = new HttpClient();

            var data = new
                        {
                            username = _configuration[$"PriceHubbleAccount:Username"],
                            password = _configuration[$"PriceHubbleAccount:Password"]
                        };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent =  response.Content.ReadAsStringAsync().Result; 
                var result = JsonConvert.DeserializeObject<Authentication>(jsonContent.Replace("'\'",""));
                
                return result.AccessToken;
            }
            return null;
        }

        public async Task<string> CallApi (string endpoint, object data)
        {
            var url = _configuration["PriceHublleBaseURL"] + endpoint;

            var httpClient = new HttpClient();

            var accessToken = await GetAccessTokenRequest();

            if (accessToken != null)
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent =  response.Content.ReadAsStringAsync().Result;
                    return jsonContent;
                }
            }
            return null;
        }

        public async Task<List<Dossier>> GetDossierList ()
        {
            object[] orderBy = {
                                new {
                                    field = "modifiedAt",
                                    direction = "desc"
                                }
                            };
            var data = new
                        {
                            countryCode = "CH",
                            limit = 50,
                            offset = 0,
                            orderBy = orderBy,
                            filters = new {}
                        };
            var jsonContent = await CallApi("/api/v1/dossiers/search", data);
            if (jsonContent != null)
            {
                var result = JsonConvert.DeserializeObject<DossierList>(jsonContent);
                return result?.Items;
            }
            // return null;
            var result1 = JsonConvert.DeserializeObject<DossierList>("{\"items\": [{\"title\": \"Family home\",\"description\": \"My description\",\"location\": {\"address\": {\"city\": \"Oberglatt\",\"houseNumber\": \"1\",\"postCode\": \"8154\",\"street\": \"Allmendstrasse\"}},\"propertyType\": \"apartment\"}]}");
            return result1.Items;
           
        }
        
    }

}