namespace Project.Service.Models
{
    public class VehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Abbreviation { get; set; }

        //Navigational properties
        public ICollection<VehicleModel> VehicleModels { get; set; } = null!;
    }
}
