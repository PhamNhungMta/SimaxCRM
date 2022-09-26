using Newtonsoft.Json;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace SimaxCrm.Service.Implementation
{
    public class HelperService : IHelperService
    {
        private readonly ICityService _cityService;
        private readonly ILeadAutoAssignLogService _leadAutoAssignLogService;
        private readonly ICallLogService _callLogService;
        private readonly ICallLogProductService _callLogProductService;
        private readonly IMessageService _messageService;
        private readonly IMessageDetailService _messageDetailService;
        private readonly ILeadTagService _leadTagService;
        private readonly IInventoryTagService _inventoryTagService;
        private readonly ILeadRemarksService _leadRemarksService;
        private readonly ILeadSourceService _leadSourceService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;
        private readonly ILeadTypeService _leadTypeService;

        public HelperService(
            ILeadAutoAssignLogService leadAutoAssignLogService,
            ICallLogService callLogService,
            ILeadTypeService leadTypeService,
            ICategoryService categoryService,
            ISubCategoryService subCategoryService,
            ICityService cityService,
            ICallLogProductService callLogProductService,
            IMessageService messageService,
            IMessageDetailService messageDetailService,
            ILeadTagService leadTagService,
            IInventoryTagService inventoryTagService,
            ILeadRemarksService leadRemarksService,
            ILeadSourceService leadSourceService)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
            _leadTypeService = leadTypeService;
            _cityService = cityService;
            _leadAutoAssignLogService = leadAutoAssignLogService;
            _callLogService = callLogService;
            _callLogProductService = callLogProductService;
            _messageService = messageService;
            _messageDetailService = messageDetailService;
            _leadTagService = leadTagService;
            _inventoryTagService = inventoryTagService;
            _leadRemarksService = leadRemarksService;
            _leadSourceService = leadSourceService;
        }

        public bool SendText(SendTextModel sendTextModel, Lead lead, EmailSetup emailSetup, ref string result)
        {
            try
            {
                if (sendTextModel.LogType == Model.Enum.TemplateType.Email)
                {
                    sendEmailMethod(lead.Email, sendTextModel.LogSubject, sendTextModel.LogText, emailSetup);
                    return true;
                }
                else
                {
                    return sendSMSMethod(lead.PhoneNumber, sendTextModel.LogText, ref result);
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return false;
            }
        }

        private bool sendSMSMethod(string phoneNumber, string logText, ref string result)
        {
            result = "api not configured";
            return false;
        }

        private static void sendEmailMethod(string toEmail, string subject, string content, EmailSetup emailSetup)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(emailSetup.Email);
            message.To.Add(new MailAddress(toEmail));
            message.Subject = subject;
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = content;
            smtp.Port = emailSetup.SmtpPort;
            smtp.Host = emailSetup.SmtpServer; //for gmail host  
            smtp.EnableSsl = emailSetup.UseSsl == "Yes";
            smtp.UseDefaultCredentials = false;
            if (!string.IsNullOrEmpty(emailSetup.Username) && !string.IsNullOrEmpty(emailSetup.Password))
            {
                smtp.Credentials = new NetworkCredential(emailSetup.Username, emailSetup.Password);
            }
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }

        public bool TestEmail(string toEmail, EmailSetup emailSetup, out string errorMsg)
        {
            try
            {
                sendEmailMethod(toEmail, "Email Testing " + DateTime.Now.ToFileTime(), "Email Testing Body", emailSetup);
                errorMsg = "Sent";
                return true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
        }

      

        public Byte[] HtmlToPdf(String html)
        {
            Byte[] file = null;
            html = Regex.Replace(html, "<td style=", "<td style11=");
            using (MemoryStream ms = new MemoryStream())
            {
                PdfSharp.Pdf.PdfDocument pdfDocument = new PdfSharp.Pdf.PdfDocument();
                PdfSharp.Pdf.PdfDocument pdf = PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.Letter);
                pdf.Save(ms);
                file = ms.ToArray();
            }
            return file;

        }


        public string HtmlToWord(String html)
        {
            var strBody = new StringBuilder();

            strBody.Append("<html " +
             "xmlns:o='urn:schemas-microsoft-com:office:office' " +
             "xmlns:w='urn:schemas-microsoft-com:office:word'" +
              "xmlns='http://www.w3.org/TR/REC-html40'>" +
              "<head><title>Time</title>");

            //The setting specifies document's view after it is downloaded as Print
            //instead of the default Web Layout
            strBody.Append("<!--[if gte mso 9]>" +
             "<xml>" +
             "<w:WordDocument>" +
             "<w:View>Print</w:View>" +
             "<w:Zoom>90</w:Zoom>" +
             "<w:DoNotOptimizeForBrowser/>" +
             "</w:WordDocument>" +
             "</xml>" +
             "<![endif]-->");

            strBody.Append("<style>" +
             "<!-- /* Style Definitions */" +
             "@page Section1" +
             "   {size:8.5in 11.0in; " +
             "   margin:1.0in 1.25in 1.0in 1.25in ; " +
             "   mso-header-margin:.5in; " +
             "   mso-footer-margin:.5in; mso-paper-source:0;}" +
             " div.Section1" +
             "   {page:Section1;}" +
             "-->" +
             "</style></head>");

            strBody.Append("<body lang=EN-US style='tab-interval:.5in'>" +
             "<div class=Section1>");
            strBody.Append(html);
            strBody.Append("</div></body></html>");

            return strBody.ToString();
            //Force this content to be downloaded 
            //as a Word document with the name of your choice

        }

        public FollowUpModels GetNotifications(string userId)
        {
            var callLogs = _callLogService.GetOldActiveReminder(userId.ToString());
            var callLogsPending = callLogs.Where(m => m.AlertStatus == Model.Enum.AlertStatusType.Pending).ToList();
            foreach (var item in callLogsPending)
            {
                item.AlertStatus = AlertStatusType.Shown;
                _callLogService.Update(item);
            }

            var callLogProducts = _callLogProductService.GetOldActiveReminder(userId.ToString());
            var callLogProductsPending = callLogProducts.Where(m => m.AlertStatus == Model.Enum.AlertStatusType.Pending).ToList();
            foreach (var item in callLogProductsPending)
            {
                item.AlertStatus = AlertStatusType.Shown;
                _callLogProductService.Update(item);
            }

            var messages = _messageService.GetOldActiveReminder(userId.ToString());
            var messagesPending = messages.Where(m => m.MessageDetail.Any(x => x.AlertStatus == Model.Enum.AlertStatusType.Pending)).ToList();
            foreach (var item in messagesPending.SelectMany(m => m.MessageDetail).ToList())
            {
                item.AlertStatus = AlertStatusType.Shown;
                _messageDetailService.Update(item);
            }

            var marge = callLogProductsPending.Select(m => new FollowUpModel()
            {
                Id = m.ProductId,
                IdStr = m.Product.IdStr,
                Type = "Inventory",
                Title = "Inventory Follow Up",
                Text = $"Inventory Id: {m.Product.IdStr}, Follow Up: {m.AlertDate.ToString()}"
            }).Union(callLogsPending.Select(m => new FollowUpModel()
            {
                Id = m.LeadId,
                IdStr = m.Lead.IdStr,
                Type = "Lead",
                Title = "Lead Follow Up",
                Text = $"Lead Id: {m.Lead.IdStr}, Follow Up: {m.AlertDate.ToString()}"
            })).Union(messagesPending.Select(m => new FollowUpModel()
            {
                Id = m.Id,
                IdStr = m.Id.ToString(),
                Type = "Message",
                Title = m.CreatedBy.Name,
                Text = $"{m.Name} - {m.Body}",
                AlertDate = m.CreatedDate
            })).ToList();

            var callLogsShown = callLogs.Where(m => m.AlertStatus == Model.Enum.AlertStatusType.Shown).ToList();
            var callLogProductsShown = callLogProducts.Where(m => m.AlertStatus == Model.Enum.AlertStatusType.Shown).ToList();
            var messagesShown = messages.Where(m => m.MessageDetail.Any(x => x.AlertStatus == Model.Enum.AlertStatusType.Shown)).ToList();


            var margeShown = callLogProductsShown.Select(m => new FollowUpModel()
            {
                Id = m.Id,
                IdStr = m.Product.IdStr,
                Type = "Inventory",
                Title = "Inventory Follow Up",
                Text = $"Inventory Id: {m.Product.IdStr}, Follow Up: {m.AlertDate.ToString()}",
                AlertDate = m.AlertDate
            }).Union(callLogsShown.Select(m => new FollowUpModel()
            {
                Id = m.Id,
                Type = "Lead",
                IdStr = m.Lead.IdStr,
                Title = "Lead Follow Up",
                Text = $"Lead Id: {m.Lead.IdStr}, Follow Up: {m.AlertDate.ToString()}",
                AlertDate = m.AlertDate
            })).Union(messagesShown.Select(m => new FollowUpModel()
            {
                Id = m.Id,
                IdStr = m.Id.ToString(),
                Type = "Message",
                Title = m.Name,
                Text = $"<b>{m.CreatedBy.Name}:</b> {m.Name} - {m.Body}",
                AlertDate = m.CreatedDate
            })).OrderByDescending(m => m.AlertDate).ToList();

            var final = new FollowUpModels
            {
                pending = marge,
                shown = margeShown,
            };

            return final;
        }

        public void PostToFirebase(string title, string body, string topic, string keyword)
        {
            using (var client = new HttpClient())
            {
                var firebaseOptionsServerId = "AAAAxtrm9tA:APA91bEqF1iZ3nQYCw0Z-wN7U4tP8fR2_kvQ-tln6Rnvq_sQhX5iYHEKS3DGr-KQ46UteRbG1XHRD0k3fgPLcFTHqgi3vUBr7kuLocjvnl6j9XVEqO-zHEJEXvlHotn7C7rRfE02b9zp";
                var firebaseOptionsSenderId = "854076094160";

                client.BaseAddress = new Uri("https://fcm.googleapis.com");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization",
                    $"key={firebaseOptionsServerId}");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Sender", $"id={firebaseOptionsSenderId}");

                var data = new
                {
                    to = "/topics/" + topic,
                    priority = "high",
                    content_available = true,
                    notification = new
                    {
                        title = title,
                        body = body,
                        guid = DateTime.Now.ToFileTime(),
                        keyword,
                        //image = "/images/logo.png"
                    },
                    data = new
                    {
                        title = title,
                        body = body,
                        guid = DateTime.Now.ToFileTime(),
                        keyword,
                        //image= "https://static.pexels.com/photos/4825/red-love-romantic-flowers.jpg"
                        //content = "iVBORw0KGgoAAAANSUhEUgAAAGQAAABkCAYAAABw4pVUAAAACXBIWXMAAABkAAAAZAF4kfVLAAAKT2lDQ1BQaG90b3Nob3AgSUNDIHByb2ZpbGUAAHjanVNnVFPpFj333vRCS4iAlEtvUhUIIFJCi4AUkSYqIQkQSoghodkVUcERRUUEG8igiAOOjoCMFVEsDIoK2AfkIaKOg6OIisr74Xuja9a89+bN/rXXPues852zzwfACAyWSDNRNYAMqUIeEeCDx8TG4eQuQIEKJHAAEAizZCFz/SMBAPh+PDwrIsAHvgABeNMLCADATZvAMByH/w/qQplcAYCEAcB0kThLCIAUAEB6jkKmAEBGAYCdmCZTAKAEAGDLY2LjAFAtAGAnf+bTAICd+Jl7AQBblCEVAaCRACATZYhEAGg7AKzPVopFAFgwABRmS8Q5ANgtADBJV2ZIALC3AMDOEAuyAAgMADBRiIUpAAR7AGDIIyN4AISZABRG8lc88SuuEOcqAAB4mbI8uSQ5RYFbCC1xB1dXLh4ozkkXKxQ2YQJhmkAuwnmZGTKBNA/g88wAAKCRFRHgg/P9eM4Ors7ONo62Dl8t6r8G/yJiYuP+5c+rcEAAAOF0ftH+LC+zGoA7BoBt/qIl7gRoXgugdfeLZrIPQLUAoOnaV/Nw+H48PEWhkLnZ2eXk5NhKxEJbYcpXff5nwl/AV/1s+X48/Pf14L7iJIEyXYFHBPjgwsz0TKUcz5IJhGLc5o9H/LcL//wd0yLESWK5WCoU41EScY5EmozzMqUiiUKSKcUl0v9k4t8s+wM+3zUAsGo+AXuRLahdYwP2SycQWHTA4vcAAPK7b8HUKAgDgGiD4c93/+8//UegJQCAZkmScQAAXkQkLlTKsz/HCAAARKCBKrBBG/TBGCzABhzBBdzBC/xgNoRCJMTCQhBCCmSAHHJgKayCQiiGzbAdKmAv1EAdNMBRaIaTcA4uwlW4Dj1wD/phCJ7BKLyBCQRByAgTYSHaiAFiilgjjggXmYX4IcFIBBKLJCDJiBRRIkuRNUgxUopUIFVIHfI9cgI5h1xGupE7yAAygvyGvEcxlIGyUT3UDLVDuag3GoRGogvQZHQxmo8WoJvQcrQaPYw2oefQq2gP2o8+Q8cwwOgYBzPEbDAuxsNCsTgsCZNjy7EirAyrxhqwVqwDu4n1Y8+xdwQSgUXACTYEd0IgYR5BSFhMWE7YSKggHCQ0EdoJNwkDhFHCJyKTqEu0JroR+cQYYjIxh1hILCPWEo8TLxB7iEPENyQSiUMyJ7mQAkmxpFTSEtJG0m5SI+ksqZs0SBojk8naZGuyBzmULCAryIXkneTD5DPkG+Qh8lsKnWJAcaT4U+IoUspqShnlEOU05QZlmDJBVaOaUt2ooVQRNY9aQq2htlKvUYeoEzR1mjnNgxZJS6WtopXTGmgXaPdpr+h0uhHdlR5Ol9BX0svpR+iX6AP0dwwNhhWDx4hnKBmbGAcYZxl3GK+YTKYZ04sZx1QwNzHrmOeZD5lvVVgqtip8FZHKCpVKlSaVGyovVKmqpqreqgtV81XLVI+pXlN9rkZVM1PjqQnUlqtVqp1Q61MbU2epO6iHqmeob1Q/pH5Z/YkGWcNMw09DpFGgsV/jvMYgC2MZs3gsIWsNq4Z1gTXEJrHN2Xx2KruY/R27iz2qqaE5QzNKM1ezUvOUZj8H45hx+Jx0TgnnKKeX836K3hTvKeIpG6Y0TLkxZVxrqpaXllirSKtRq0frvTau7aedpr1Fu1n7gQ5Bx0onXCdHZ4/OBZ3nU9lT3acKpxZNPTr1ri6qa6UbobtEd79up+6Ynr5egJ5Mb6feeb3n+hx9L/1U/W36p/VHDFgGswwkBtsMzhg8xTVxbzwdL8fb8VFDXcNAQ6VhlWGX4YSRudE8o9VGjUYPjGnGXOMk423GbcajJgYmISZLTepN7ppSTbmmKaY7TDtMx83MzaLN1pk1mz0x1zLnm+eb15vft2BaeFostqi2uGVJsuRaplnutrxuhVo5WaVYVVpds0atna0l1rutu6cRp7lOk06rntZnw7Dxtsm2qbcZsOXYBtuutm22fWFnYhdnt8Wuw+6TvZN9un2N/T0HDYfZDqsdWh1+c7RyFDpWOt6azpzuP33F9JbpL2dYzxDP2DPjthPLKcRpnVOb00dnF2e5c4PziIuJS4LLLpc+Lpsbxt3IveRKdPVxXeF60vWdm7Obwu2o26/uNu5p7ofcn8w0nymeWTNz0MPIQ+BR5dE/C5+VMGvfrH5PQ0+BZ7XnIy9jL5FXrdewt6V3qvdh7xc+9j5yn+M+4zw33jLeWV/MN8C3yLfLT8Nvnl+F30N/I/9k/3r/0QCngCUBZwOJgUGBWwL7+Hp8Ib+OPzrbZfay2e1BjKC5QRVBj4KtguXBrSFoyOyQrSH355jOkc5pDoVQfujW0Adh5mGLw34MJ4WHhVeGP45wiFga0TGXNXfR3ENz30T6RJZE3ptnMU85ry1KNSo+qi5qPNo3ujS6P8YuZlnM1VidWElsSxw5LiquNm5svt/87fOH4p3iC+N7F5gvyF1weaHOwvSFpxapLhIsOpZATIhOOJTwQRAqqBaMJfITdyWOCnnCHcJnIi/RNtGI2ENcKh5O8kgqTXqS7JG8NXkkxTOlLOW5hCepkLxMDUzdmzqeFpp2IG0yPTq9MYOSkZBxQqohTZO2Z+pn5mZ2y6xlhbL+xW6Lty8elQfJa7OQrAVZLQq2QqboVFoo1yoHsmdlV2a/zYnKOZarnivN7cyzytuQN5zvn//tEsIS4ZK2pYZLVy0dWOa9rGo5sjxxedsK4xUFK4ZWBqw8uIq2Km3VT6vtV5eufr0mek1rgV7ByoLBtQFr6wtVCuWFfevc1+1dT1gvWd+1YfqGnRs+FYmKrhTbF5cVf9go3HjlG4dvyr+Z3JS0qavEuWTPZtJm6ebeLZ5bDpaql+aXDm4N2dq0Dd9WtO319kXbL5fNKNu7g7ZDuaO/PLi8ZafJzs07P1SkVPRU+lQ27tLdtWHX+G7R7ht7vPY07NXbW7z3/T7JvttVAVVN1WbVZftJ+7P3P66Jqun4lvttXa1ObXHtxwPSA/0HIw6217nU1R3SPVRSj9Yr60cOxx++/p3vdy0NNg1VjZzG4iNwRHnk6fcJ3/ceDTradox7rOEH0x92HWcdL2pCmvKaRptTmvtbYlu6T8w+0dbq3nr8R9sfD5w0PFl5SvNUyWna6YLTk2fyz4ydlZ19fi753GDborZ752PO32oPb++6EHTh0kX/i+c7vDvOXPK4dPKy2+UTV7hXmq86X23qdOo8/pPTT8e7nLuarrlca7nuer21e2b36RueN87d9L158Rb/1tWeOT3dvfN6b/fF9/XfFt1+cif9zsu72Xcn7q28T7xf9EDtQdlD3YfVP1v+3Njv3H9qwHeg89HcR/cGhYPP/pH1jw9DBY+Zj8uGDYbrnjg+OTniP3L96fynQ89kzyaeF/6i/suuFxYvfvjV69fO0ZjRoZfyl5O/bXyl/erA6xmv28bCxh6+yXgzMV70VvvtwXfcdx3vo98PT+R8IH8o/2j5sfVT0Kf7kxmTk/8EA5jz/GMzLdsAADoTaVRYdFhNTDpjb20uYWRvYmUueG1wAAAAAAA8P3hwYWNrZXQgYmVnaW49Iu+7vyIgaWQ9Ilc1TTBNcENlaGlIenJlU3pOVGN6a2M5ZCI/Pgo8eDp4bXBtZXRhIHhtbG5zOng9ImFkb2JlOm5zOm1ldGEvIiB4OnhtcHRrPSJBZG9iZSBYTVAgQ29yZSA1LjUtYzAyMSA3OS4xNTQ5MTEsIDIwMTMvMTAvMjktMTE6NDc6MTYgICAgICAgICI+CiAgIDxyZGY6UkRGIHhtbG5zOnJkZj0iaHR0cDovL3d3dy53My5vcmcvMTk5OS8wMi8yMi1yZGYtc3ludGF4LW5zIyI+CiAgICAgIDxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSIiCiAgICAgICAgICAgIHhtbG5zOnhtcD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyIKICAgICAgICAgICAgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iCiAgICAgICAgICAgIHhtbG5zOnN0RXZ0PSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VFdmVudCMiCiAgICAgICAgICAgIHhtbG5zOmRjPSJodHRwOi8vcHVybC5vcmcvZGMvZWxlbWVudHMvMS4xLyIKICAgICAgICAgICAgeG1sbnM6cGhvdG9zaG9wPSJodHRwOi8vbnMuYWRvYmUuY29tL3Bob3Rvc2hvcC8xLjAvIgogICAgICAgICAgICB4bWxuczp0aWZmPSJodHRwOi8vbnMuYWRvYmUuY29tL3RpZmYvMS4wLyIKICAgICAgICAgICAgeG1sbnM6ZXhpZj0iaHR0cDovL25zLmFkb2JlLmNvbS9leGlmLzEuMC8iPgogICAgICAgICA8eG1wOkNyZWF0b3JUb29sPkFkb2JlIFBob3Rvc2hvcCBDQyAoV2luZG93cyk8L3htcDpDcmVhdG9yVG9vbD4KICAgICAgICAgPHhtcDpDcmVhdGVEYXRlPjIwMjEtMDUtMjVUMTM6NTQ6MzArMDU6MzA8L3htcDpDcmVhdGVEYXRlPgogICAgICAgICA8eG1wOk1ldGFkYXRhRGF0ZT4yMDIxLTA1LTI1VDEzOjU0OjMwKzA1OjMwPC94bXA6TWV0YWRhdGFEYXRlPgogICAgICAgICA8eG1wOk1vZGlmeURhdGU+MjAyMS0wNS0yNVQxMzo1NDozMCswNTozMDwveG1wOk1vZGlmeURhdGU+CiAgICAgICAgIDx4bXBNTTpJbnN0YW5jZUlEPnhtcC5paWQ6MWQxMzExYTAtZmMwOC1jZDQ1LWI3ZjktZWIyMzA3YTY0MThhPC94bXBNTTpJbnN0YW5jZUlEPgogICAgICAgICA8eG1wTU06RG9jdW1lbnRJRD54bXAuZGlkOmFlOTQxNWM3LWYxYWEtYzY0ZS04OGMzLWIxMGM0ODc3Y2JiMzwveG1wTU06RG9jdW1lbnRJRD4KICAgICAgICAgPHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD54bXAuZGlkOmFlOTQxNWM3LWYxYWEtYzY0ZS04OGMzLWIxMGM0ODc3Y2JiMzwveG1wTU06T3JpZ2luYWxEb2N1bWVudElEPgogICAgICAgICA8eG1wTU06SGlzdG9yeT4KICAgICAgICAgICAgPHJkZjpTZXE+CiAgICAgICAgICAgICAgIDxyZGY6bGkgcmRmOnBhcnNlVHlwZT0iUmVzb3VyY2UiPgogICAgICAgICAgICAgICAgICA8c3RFdnQ6YWN0aW9uPmNyZWF0ZWQ8L3N0RXZ0OmFjdGlvbj4KICAgICAgICAgICAgICAgICAgPHN0RXZ0Omluc3RhbmNlSUQ+eG1wLmlpZDphZTk0MTVjNy1mMWFhLWM2NGUtODhjMy1iMTBjNDg3N2NiYjM8L3N0RXZ0Omluc3RhbmNlSUQ+CiAgICAgICAgICAgICAgICAgIDxzdEV2dDp3aGVuPjIwMjEtMDUtMjVUMTM6NTQ6MzArMDU6MzA8L3N0RXZ0OndoZW4+CiAgICAgICAgICAgICAgICAgIDxzdEV2dDpzb2Z0d2FyZUFnZW50PkFkb2JlIFBob3Rvc2hvcCBDQyAoV2luZG93cyk8L3N0RXZ0OnNvZnR3YXJlQWdlbnQ+CiAgICAgICAgICAgICAgIDwvcmRmOmxpPgogICAgICAgICAgICAgICA8cmRmOmxpIHJkZjpwYXJzZVR5cGU9IlJlc291cmNlIj4KICAgICAgICAgICAgICAgICAgPHN0RXZ0OmFjdGlvbj5zYXZlZDwvc3RFdnQ6YWN0aW9uPgogICAgICAgICAgICAgICAgICA8c3RFdnQ6aW5zdGFuY2VJRD54bXAuaWlkOjFkMTMxMWEwLWZjMDgtY2Q0NS1iN2Y5LWViMjMwN2E2NDE4YTwvc3RFdnQ6aW5zdGFuY2VJRD4KICAgICAgICAgICAgICAgICAgPHN0RXZ0OndoZW4+MjAyMS0wNS0yNVQxMzo1NDozMCswNTozMDwvc3RFdnQ6d2hlbj4KICAgICAgICAgICAgICAgICAgPHN0RXZ0OnNvZnR3YXJlQWdlbnQ+QWRvYmUgUGhvdG9zaG9wIENDIChXaW5kb3dzKTwvc3RFdnQ6c29mdHdhcmVBZ2VudD4KICAgICAgICAgICAgICAgICAgPHN0RXZ0OmNoYW5nZWQ+Lzwvc3RFdnQ6Y2hhbmdlZD4KICAgICAgICAgICAgICAgPC9yZGY6bGk+CiAgICAgICAgICAgIDwvcmRmOlNlcT4KICAgICAgICAgPC94bXBNTTpIaXN0b3J5PgogICAgICAgICA8ZGM6Zm9ybWF0PmltYWdlL3BuZzwvZGM6Zm9ybWF0PgogICAgICAgICA8cGhvdG9zaG9wOkNvbG9yTW9kZT4zPC9waG90b3Nob3A6Q29sb3JNb2RlPgogICAgICAgICA8cGhvdG9zaG9wOklDQ1Byb2ZpbGU+c1JHQiBJRUM2MTk2Ni0yLjE8L3Bob3Rvc2hvcDpJQ0NQcm9maWxlPgogICAgICAgICA8dGlmZjpPcmllbnRhdGlvbj4xPC90aWZmOk9yaWVudGF0aW9uPgogICAgICAgICA8dGlmZjpYUmVzb2x1dGlvbj4xMDAwMC8xMDAwMDwvdGlmZjpYUmVzb2x1dGlvbj4KICAgICAgICAgPHRpZmY6WVJlc29sdXRpb24+MTAwMDAvMTAwMDA8L3RpZmY6WVJlc29sdXRpb24+CiAgICAgICAgIDx0aWZmOlJlc29sdXRpb25Vbml0PjM8L3RpZmY6UmVzb2x1dGlvblVuaXQ+CiAgICAgICAgIDxleGlmOkNvbG9yU3BhY2U+MTwvZXhpZjpDb2xvclNwYWNlPgogICAgICAgICA8ZXhpZjpQaXhlbFhEaW1lbnNpb24+MTAwPC9leGlmOlBpeGVsWERpbWVuc2lvbj4KICAgICAgICAgPGV4aWY6UGl4ZWxZRGltZW5zaW9uPjEwMDwvZXhpZjpQaXhlbFlEaW1lbnNpb24+CiAgICAgIDwvcmRmOkRlc2NyaXB0aW9uPgogICA8L3JkZjpSREY+CjwveDp4bXBtZXRhPgogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgIAo8P3hwYWNrZXQgZW5kPSJ3Ij8+9RvWmAAAACBjSFJNAAB6JQAAgIMAAPn/AACA6QAAdTAAAOpgAAA6mAAAF2+SX8VGAABDB0lEQVR42ty9d7xkWXUe+q219wmV66a+nbune7p7EhN6mCgRBiSyiGIQWMIIy5YsS8+SkIxk+ck/W8+WnuUnLBSwMOiRhBFCBhOHgQkwDDPMMDnH7uncffOtdMLee70/9jlVdbt7okAP+/I73J66t+pWnbX3Ct/61rdp4b6j+EF8CQTd1WUszs+jVqtjdamLPE1QaVURBRGMcYACIhVg6egcgijE4uE5MDNq1SqiRoTcGYRxFS5NUanWYUPG+plpgEOkSR/QDpJTY/nwwlQ+SDcvHz62de7w0W3JwcXpvJueka0M6khsbHMTw4JB5BQrEwRqEFbjfmWi2ZWQD7a2zM5Vm9UD02dsfFKEDkWTlbn+wrJpT8yi0qoiGfSxcnwRlSBEnllILqhNRcg7BroaodlqwqYDZESocAwRh17SRxhosFJQGZBlGYJ6BZ2Dc8h6PWgdojndQnzhRkiTASenvY8aP2JfzAwVhQgrMfIASPrJ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"
                    }
                };


                var json = JsonConvert.SerializeObject(data);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var result = client.PostAsync("/fcm/send", httpContent).Result;
                var resp = result.Content.ReadAsStringAsync().Result;
            }
        }

        public void createDefaultData(int tid)
        {
            var leadTags = "Vip,Sincere,Hurry,Cold,Warm,Hot";
            var inventoryTag = "Low Price,High Price,Best Price,Vip,Despirit,Hurry";
            var leadSource = "SMS,Google,Facebook,YouTube,Emailer,walkin,99Acres,Magicbricks,Housing";
            var followUp = "First Call Done,Taking Follow up,Proposal Send,Site Visit Plan,Site Visit Done,Call Back";
            var postpone = "One Week,Two Week,One Month,Three Month,Plan Postpone";
            var comment = "Call Done,Working in Progress,Following up";
            var converted = "Deal Done,Booked Payment awaited,Booked Payment received";
            var surrender = "Give up,Wrong no,Wrong inquiry,Wrong city,Wrong project";
            var closed = "Query closed,Not responding,Repeat Query,Fake query,Low Budget,Junk";
            var soldout = "Property Sold by Me,Property Sold out by Team,Property Sold by other agent,Property Sold by owner";
            var reopen = "Interest shown by Client,Reopen by follow-up,Auto Re-open Lead";
            var cities = "Delhi,Kolkata,Punjab";
            var category = "Commercial,Residential";
            var subCategory1 = "Commercial Shops,Commercial Showrooms,Commercial Office/Space,Commercial Land/Building,Industrial Lands/Plots,Agricultural Land,Hotel/Resorts,Guest-House/Banquet-Halls,Institutional Land/Building,Other";
            var subCategory2 = "Apartment,Independent/Builder Floor,Independent House/Villa,Residential Land,Studio Apartment,Farm House,Serviced Apartments,Other";
            var leadType = "Buy,Rent,Sell";


            foreach (var item in category.Split(','))
            {
                var obj = new Category()
                {
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Status = true,
                    Tid = tid,
                };
                _categoryService.Create(obj);
            }

            foreach (var item in subCategory1.Split(','))
            {
                var obj = new SubCategory()
                {
                    CategoryId=1,
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Status = true,
                    Tid = tid,
                };
                _subCategoryService.Create(obj);
            }


            foreach (var item in subCategory2.Split(','))
            {
                var obj = new SubCategory()
                {
                    CategoryId = 2,
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Status = true,
                    Tid = tid,
                };
                _subCategoryService.Create(obj);
            }

            foreach (var item in leadTags.Split(','))
            {
                var obj = new LeadTag()
                {
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Status = true,
                    Tid = tid,
                };
                _leadTagService.Create(obj, false);
            }

            foreach (var item in leadType.Split(','))
            {
                var obj = new LeadType()
                {
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Status = true,
                    Tid = tid,
                };
                _leadTypeService.Create(obj);
            }

            foreach (var item in cities.Split(','))
            {
                var obj = new City()
                {
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Status = true,
                    Tid = tid,
                };
                _cityService.Create(obj);
            }

            foreach (var item in inventoryTag.Split(','))
            {
                var obj = new InventoryTag()
                {
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Status = true,
                    Tid = tid,
                };
                _inventoryTagService.Create(obj, false);
            }

            foreach (var item in leadSource.Split(','))
            {
                var obj = new LeadSource()
                {
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Status = true,
                    Tid = tid,
                };
                _leadSourceService.Create(obj, false);
            }

            foreach (var item in followUp.Split(','))
            {
                var obj = new LeadRemarks()
                {
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Tid = tid,
                    Status = "FollowUp"
                };
                _leadRemarksService.Create(obj, false);
            }

            foreach (var item in reopen.Split(','))
            {
                var obj = new LeadRemarks()
                {
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Tid = tid,
                    Status = "Reopen"
                };
                _leadRemarksService.Create(obj, false);
            }

            foreach (var item in postpone.Split(','))
            {
                var obj = new LeadRemarks()
                {
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Tid = tid,
                    Status = "Postpone"
                };
                _leadRemarksService.Create(obj, false);
            }

            foreach (var item in comment.Split(','))
            {
                var obj = new LeadRemarks()
                {
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Tid = tid,
                    Status = "Comment"
                };
                _leadRemarksService.Create(obj, false);
            }

            foreach (var item in converted.Split(','))
            {
                var obj = new LeadRemarks()
                {
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Tid = tid,
                    Status = "Converted"
                };
                _leadRemarksService.Create(obj, false);
            }

            foreach (var item in surrender.Split(','))
            {
                var obj = new LeadRemarks()
                {
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Tid = tid,
                    Status = "Surrender"
                };
                _leadRemarksService.Create(obj, false);
            }

            foreach (var item in closed.Split(','))
            {
                var obj = new LeadRemarks()
                {
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Tid = tid,
                    Status = "Closed"
                };
                _leadRemarksService.Create(obj, false);
            }

            foreach (var item in soldout.Split(','))
            {
                var obj = new LeadRemarks()
                {
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    Name = item,
                    Tid = tid,
                    Status = "Soldout"
                };
                _leadRemarksService.Create(obj, false);
            }
        }

        public bool SendText(EmailSent emailSent, EmailSetup emailSetup)
        {
            try
            {
                sendEmailMethod(emailSent.ToEmail, emailSent.Subject, emailSent.Body, emailSetup);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
