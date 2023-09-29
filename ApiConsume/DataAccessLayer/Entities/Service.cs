using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        public string ServiceIcon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}