using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes365RestApi.Entities;
using Viajes365RestApi.Handlers;
using Viajes365RestApi.Helpers;

namespace Viajes365RestApi.Services
{
    public interface IAttractionService
    {
        IEnumerable<Attraction> GetAll();
        Attraction GetById(long id);
        Attraction Create(Attraction attraction);
        void Update(Attraction attraction);
        void Delete(long id);
    }
    public class AttractionService : IAttractionService
    {
        private DataContext _context;

        public AttractionService(DataContext context)
        {
            _context = context;
        }

        Attraction IAttractionService.Create(Attraction attraction)
        {
            // validation
            if (string.IsNullOrWhiteSpace(attraction.Name))
                throw new AppException("Attraction name is required");

            attraction.Active = true;
            _context.Attractions.Add(attraction);
            _context.SaveChanges();
            return attraction;
        }

        void IAttractionService.Delete(long id)
        {
            var attraction = _context.Attractions.Find(id);
            if (attraction != null)
            {
                _context.Attractions.Remove(attraction);
                _context.SaveChanges();
            }
        }

        IEnumerable<Attraction> IAttractionService.GetAll()
        {
            return _context.Attractions.ToList();
        }

        Attraction IAttractionService.GetById(long id)
        {
            return _context.Attractions.Find(id);
        }


        void IAttractionService.Update(Attraction attractionParam)
        {
            var attraction = _context.Attractions.Find(attractionParam.AttractionId);

            if (attraction == null)
                throw new AppException("Attraction not found");

            // update Attraction if it has changed
            if (!string.IsNullOrWhiteSpace(attractionParam.Name) && attractionParam.Name != attraction.Name)
            {
                if (_context.Attractions.Any(x => x.Name == attractionParam.Name))
                    throw new AppException("Attraction name " + attractionParam.Name + " already exists");

                attraction.Name = attractionParam.Name;
            }

            if (!string.IsNullOrWhiteSpace(attractionParam.Summary.ToString()))
                attraction.Summary = attractionParam.Summary;

            if (!string.IsNullOrWhiteSpace(attractionParam.Note.ToString()))
                attraction.Note = attractionParam.Note;

            if (!string.IsNullOrWhiteSpace(attractionParam.Rating.ToString()))
                attraction.Rating = attractionParam.Rating;

            if (!string.IsNullOrWhiteSpace(attractionParam.Active.ToString()))
                attraction.Active = attractionParam.Active;

            // saving updates
            _context.Attractions.Update(attraction);
            _context.SaveChanges();
        }
    }
}
