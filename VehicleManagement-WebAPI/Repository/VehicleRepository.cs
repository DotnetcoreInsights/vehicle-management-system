using VehicleManagement_WebAPI.Models;

namespace VehicleManagement_WebAPI.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleDbContext _context;
        public VehicleRepository(VehicleDbContext context) 
        {
            _context = context;
        }
        //Get
        public IEnumerable<VehicleModel> GetAllVehicles()
        {
            try
            {
                return _context.Vehicles.ToList();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        //GetById
        public VehicleModel GetVehicleById(int vehicleId)
        {
            try
            {
                return _context.Vehicles.Find(vehicleId);
            }
            catch(Exception ex)
            {
                throw new Exception("An error occurred while retrieving vehicles.", ex);
            }
        }
        //Add
        public void AddVehicle(VehicleModel vehicle)
        {
            try
            {
                _context.Vehicles.Add(vehicle);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("An err occurred while adding vehicle", ex);
            }
        }

        //Update
        public bool UpdateVehicle(VehicleModel vehicle)
        {
            try
            {
                if(VehicleExists(vehicle.Id))
                {
                    _context.Vehicles.Update(vehicle);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("An err occurred while updating vehicle", ex);
            }
        }

        //Delete
        public bool DeleteVehicle(int vehicleId)
        {
            try
            {
                var vehicles = _context.Vehicles.Find(vehicleId);
                if(vehicles != null)
                {
                    _context.Vehicles.Remove(vehicles);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("An err occurred while deleting vehicle", ex);
            }
        }

        private bool VehicleExists(int vehicleId)
        {
            return _context.Vehicles.Any(x => x.Id == vehicleId);
        }
    }
}
