using Project.Service.Models;

namespace Project.Service.Services
{
    public interface IVehicleService
    {
        public void InsertMake(VehicleMake vehicleMake);
        public void InsertModel(VehicleModel vehicleModel);
        public Task<List<VehicleMake>> GetMakes();
        public Task<List<VehicleModel>> GetModels();
        public Task<VehicleMake> GetMakeById(int id);
        public Task<VehicleModel> GetModelById(int id);
        public void UpdateMake(VehicleMake vehicleMake);
        public void UpdateModel(VehicleModel vehicleModel);
        public void DeleteMake(VehicleMake vehicleMake);
        public void DeleteModel(VehicleModel vehicleModel);
    }
}
