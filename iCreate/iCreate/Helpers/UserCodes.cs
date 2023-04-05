namespace iCreate.Helpers
{
    public class UserCodes
    {
        public List<int> codesList = new List<int>();
        public List<int> randomCodes = GetUniqueCodes(1000,20);

        private static List<int> GetUniqueCodes(int maxRange, int totalRandomnoCount)
        {
            List<int> noList = new List<int>();
            int count = 0;
            Random r = new Random();
            List<int> listRange = new List<int>();
            for (int i = 0; i < totalRandomnoCount; i++)
            {
                listRange.Add(i);
            }
            while (listRange.Count > 0)
            {
                int item = r.Next(maxRange);
                if (!noList.Contains(item) && listRange.Count > 0)
                {
                    noList.Add(item);
                    listRange.Remove(count);
                    count++;
                }
            }
            return noList;
        }
    }
}
