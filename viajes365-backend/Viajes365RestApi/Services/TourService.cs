using System.Collections.Generic;
using System.Linq;
using Viajes365RestApi.Entities;
using Viajes365RestApi.Handlers;
using Viajes365RestApi.Helpers;

namespace Viajes365RestApi.Services
{
    public interface ITourService
    {
        IEnumerable<Tour> GetAll();
        Tour GetById(long id);
        Tour Create(Tour tour);
        void Update(Tour tour);
        void Delete(long id);
    }
    public class TourService : ITourService
    {
        private DataContext _context;

        public TourService(DataContext context)
        {
            _context = context;
        }

        Tour ITourService.Create(Tour tour)
        {
            // validation
            if (string.IsNullOrWhiteSpace(tour.Name))
                throw new AppException("Tour name is required");

            tour.Active = true;
            _context.Tours.Add(tour);
            _context.SaveChanges();
            return tour;
        }

        void ITourService.Delete(long id)
        {
            var location = _context.Tours.Find(id);
            if (location != null)
            {
                _context.Tours.Remove(location);
                _context.SaveChanges();
            }
        }

        IEnumerable<Tour> ITourService.GetAll()
        {
            return _context.Tours.ToList();
        }

        Tour ITourService.GetById(long id)
        {
            return _context.Tours.Find(id);
        }


        void ITourService.Update(Tour tourParam)
        {
            var tour = _context.Tours.Find(tourParam.TourId);

            if (tour == null)
                throw new AppException("Tour not found");

            // update Tour if it has changed
            if (!string.IsNullOrWhiteSpace(tourParam.Name) && tourParam.Name != tour.Name)
            {
                if (_context.Tours.Any(x => x.Name == tourParam.Name))
                    throw new AppException("Tour name " + tourParam.Name + " already exists");

                tour.Name = tourParam.Name;
            }

            if (!string.IsNullOrWhiteSpace(tourParam.Summary.ToString()))
                tour.Summary = tourParam.Summary;

            if (!string.IsNullOrWhiteSpace(tourParam.Duration.ToString()))
                tour.Duration = tourParam.Duration;

            if (!string.IsNullOrWhiteSpace(tourParam.Active.ToString()))
                tour.Active = tourParam.Active;

            // saving updates
            _context.Tours.Update(tour);
            _context.SaveChanges();
        }
    }
}
