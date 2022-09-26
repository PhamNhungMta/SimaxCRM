using SimaxCrm.Model.Entity;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface IHelperService
    {
        bool SendText(SendTextModel sendTextModel, Lead lead, EmailSetup emailSetup, ref string result);
        bool TestEmail(string toEmail, EmailSetup emailSetup, out string errorMsg);
       // string AssignAgentSourceAndRankingWise(int source, int tid = 0);
        byte[] HtmlToPdf(string html);
        string HtmlToWord(string html);
        FollowUpModels GetNotifications(string userId);
        void PostToFirebase(string title, string body, string topic, string keyword);
        void createDefaultData(int tid);
        bool SendText(EmailSent emailSent, EmailSetup emailSetup);
    }
}
