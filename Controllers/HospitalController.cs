using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CruxDotNetReact.Application.Error;
using CruxDotNetReact.Data;
using CruxDotNetReact.Interfaces;
using CruxDotNetReact.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CruxDotNetReact.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepo _authRepo;
        private readonly DataContext _context;

        public HospitalController(IHospitalRepo authRepo, DataContext context)
        {
            _authRepo = authRepo;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetHospitals()
        {
            var hospitals = await _authRepo.Hospital();
            return Ok(hospitals);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetHospital(int id)
        {
            var hospital = await _authRepo.Hospital(id);
            if (hospital == null)
                throw new RestException(HttpStatusCode.BadRequest);
            return Ok(hospital);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHospital(Hospital hosp)
        {
            _authRepo.CreateOneHospital(hosp);

            if (await _authRepo.SaveAll())
                return Ok();

            return BadRequest("Failed to Create User");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditHospital(int id, Hospital hosp)
        {
            var hospital = await _context.Hospitals.FirstOrDefaultAsync(x => x.Id == id);

            if (hospital == null)
                throw new RestException(HttpStatusCode.BadRequest, new { User = "User not found" });


            hospital.Location = hosp.Location;
            hospital.Name = hosp.Name;
            hospital.State = hosp.State;
            hospital.Email = hosp.Email;
            hospital.DateCreated = hosp.DateCreated;


            if (await _authRepo.SaveAll())
                return Ok();

            return BadRequest("Failed to like User");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospital(int id)
        {
            var hospital = await _context.Hospitals.FirstOrDefaultAsync(x => x.Id == id);
            _authRepo.Delete(hospital);
            if (hospital == null)
                throw new RestException(HttpStatusCode.BadRequest, new { User = "User not found" });

            if (await _authRepo.SaveAll())
                return Ok();

            return BadRequest("Failed to Delete User");
        }

    }

}