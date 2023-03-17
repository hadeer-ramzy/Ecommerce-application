using System.ComponentModel.DataAnnotations;

namespace E_Commerce.PL.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
