namespace iCreateTikTok.Models
{
    public class DataItem
    {
        public string Status { get; set; }
        public string Task_id { get; set; }
        public string File_name { get; set; }
        public string File_type { get; set; }
        public DataItem(string status, string task_id, string file_name, string file_type)
        {
            Status = status;
            Task_id = task_id;
            File_name = file_name;
            File_type = file_type;
        }
    }
}
