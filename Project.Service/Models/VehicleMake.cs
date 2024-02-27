using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.Models
{
    [Table("VehicleMakes")]
    public class VehicleMake
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        //Navigational properties
        public ICollection<VehicleModel> VehicleModels { get; set; }

    }
}
