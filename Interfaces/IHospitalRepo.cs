using CruxDotNetReact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruxDotNetReact.Interfaces
{
    public interface IHospitalRepo
    {
        void CreateOneHospital<T> (T entity) where T : class;
        void UpdateHospitals<T> (T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<Hospital>> Hospital();
        Task<Hospital> Hospital(int id);

        Task<bool> SaveAll();

    }
}
