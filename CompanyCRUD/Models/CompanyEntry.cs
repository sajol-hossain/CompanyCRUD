using System.ComponentModel.DataAnnotations;

namespace CompanyCRUD.Models
{
	public class CompanyEntry
	{

		[Key]
		public int Id { get; set; }

		public string FieldName { get; set; }
		public string Value{ get; set; }
		public int CompanyID{ get; set; }
	}
}
