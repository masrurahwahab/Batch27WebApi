namespace Batch27WebApi.Models.Entities
{
    public class BookMenu : BaseEntities
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string BookCode { get; private set; } = GenerateCode();

       

        private static string GenerateCode()
        {
            Random random = new Random();
            return $"BC{random.Next(100, 1000).ToString()}";            
        }


    }
}
