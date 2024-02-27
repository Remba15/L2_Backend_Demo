namespace Project.Service.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; } = null!;
        public string? Abbreviation { get; set; }

        //Navigational properties
        public VehicleMake VehicleMake { get; set; } = null!;
    }
}
