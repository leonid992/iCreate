namespace iCreateTikTok.Models
{
    public class LeadItem
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public DataItem Data { get; set; }
        public string Request_id { get; set; }
        public LeadItem(int code, string message, DataItem data, string request_id)
        {
            Code = code;
            Message = message;
            Data = data;
            Request_id = request_id;
        }
       
    }
}
