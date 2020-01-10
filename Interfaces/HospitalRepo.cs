using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CruxDotNetReact.Application.Error;
using CruxDotNetReact.Data;
using CruxDotNetReact.Models;
using Microsoft.EntityFrameworkCore;

namespace CruxDotNetReact.Interfaces
{
    public class HospitalRepo : IHospitalRepo
    {
        private readonly DataContext _context;

        public HospitalRepo(DataContext context)
        {
            _context = context;
        }

        
        public void CreateOneHospital<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete(int id) 
        {
            var hospital = _context.Hospitals.FirstOrDefault(x => x.Id == id);
            if (hospital == null)
                throw new RestException(HttpStatusCode.BadRequest);

            _context.Remove(hospital);
        }

        public void UpdateHospitals<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;

        }
        public async Task<IEnumerable<Hospital>> Hospital()
        {
            var hospitals = await _context.Hospitals.ToListAsync();
            return hospitals;
        }

        public async Task<Hospital> Hospital(int id)
        {
           

            var hospital = await _context.Hospitals.FirstOrDefaultAsync(x =>x.Id==id);
          
            return hospital;
        }

        

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
