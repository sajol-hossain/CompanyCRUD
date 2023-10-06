using System.ComponentModel.DataAnnotations;

namespace CompanyCRUD.Models
{
	public class Company
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Address { get; set; }

		public List<CompanyEntry> CompanyEntries { get; set; } = new List<CompanyEntry>();

        public Company()
        {
            CompanyEntries = new List<CompanyEntry>();
        }
    }
}
