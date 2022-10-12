using System;
using System.Collections.Generic;

namespace SimaxCrm.Model.ResponseModel
{
    public class Authentication
    {
        public string AccessToken { get; set; }
    }

    public class DossierList
    {
        public List<Dossier> Items { get; set; }
    }

    public class Dossier
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DossierLocation Location { get; set; }
        public string PropertyType { get; set; }
    }

    public class DossierLocation
    {
        public Address Address { get; set; }
    }

    public class Address
    {
        public string City { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string Street { get; set; }
    }
}