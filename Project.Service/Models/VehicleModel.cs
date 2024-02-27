using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.Models
{
    [Table("VehicleModels")]
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }
        public int MakeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        //Navigational properties
        public VehicleMake VehicleMake { get; set; }
    }
}
