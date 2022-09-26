using System;

namespace SimaxCrm.Model.ResponseModel
{
    public class CalenderResponse
    {
        public string id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public bool allDay { get; set; }
        public string className { get; set; }
    }
}