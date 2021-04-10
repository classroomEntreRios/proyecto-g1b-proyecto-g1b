using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes365RestApi.Entities;
using Viajes365RestApi.Handlers;
using Viajes365RestApi.Helpers;

namespace Viajes365RestApi.Services
{
    public interface ILocationService
    {
        IEnumerable<Location> GetAll();
        Location GetById(long id);
        Location Create(Location location);
        void Update(Location location);
        void Delete(long id);
    }
    public class LocationService : ILocationService
    {
        private DataContext _context;

        public LocationService(DataContext context)
        {
            _context = context;
        }

        Location ILocationService.Create(Location location)
        {
            // validation
            if (string.IsNullOrWhiteSpace(location.LocationName))
                throw new AppException("Location name is required");

            location.Active = true;
            _context.Locations.Add(location);
            _context.SaveChanges();
            return location;
        }

        void ILocationService.Delete(long id)
        {
            var location = _context.Locations.Find(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                _context.SaveChanges();
            }
        }

        IEnumerable<Location> ILocationService.GetAll()
        {
            return _context.Locations.ToList();
        }

        Location ILocationService.GetById(long id)
        {
            return _context.Locations.Find(id);
        }


        void ILocationService.Update(Location locationParam)
        {
            var location = _context.Locations.Find(locationParam.LocationId);

            if (location == null)
                throw new AppException("Location not found");

            // update Location if it has changed
            if (!string.IsNullOrWhiteSpace(locationParam.LocationName) && locationParam.LocationName != location.LocationName)
            {
                // throw error if the new username is already taken
                if (_context.Locations.Any(x => x.LocationName == locationParam.LocationName))
                    throw new AppException("Location name " + locationParam.LocationName + " already exists");

                location.LocationName = locationParam.LocationName;
            }

            if (!string.IsNullOrWhiteSpace(locationParam.LocationId.ToString()))
                location.LocationId = locationParam.LocationId;

            if (!string.IsNullOrWhiteSpace(locationParam.Latitude.ToString()))
                location.Latitude = locationParam.Latitude;

            if (!string.IsNullOrWhiteSpace(locationParam.Longitude.ToString()))
                location.Longitude = locationParam.Longitude;

            if (!string.IsNullOrWhiteSpace(locationParam.FullAddress.ToString()))
                location.FullAddress = locationParam.FullAddress;

            if (!string.IsNullOrWhiteSpace(locationParam.Note.ToString()))
                location.Note = locationParam.Note;

            if (!string.IsNullOrWhiteSpace(locationParam.Active.ToString()))
                location.Active = locationParam.Active;

            // saving updates
            _context.Locations.Update(location);
            _context.SaveChanges();
        }

    }
}
