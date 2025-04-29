using VehicleManagement_WebAPI.Models;

namespace VehicleManagement_WebAPI.Repository
{
    public interface IVehicleRepository
    {
        IEnumerable<VehicleModel> GetAllVehicles();
        VehicleModel GetVehicleById(int vehicleId);
        void AddVehicle(VehicleModel vehicle);
        bool UpdateVehicle(VehicleModel vehicle);
        bool DeleteVehicle(int vehicleId);
    }
}
