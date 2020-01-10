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
        private readonly IHospitalRepo _repo;

        public HospitalController(IHospitalRepo repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> GetHospitals()
        {
            var hospitals = await _repo.Hospital();
            return Ok(hospitals);
        }

        [HttpGet("{id}")]
        //  [Authorize]
        public async Task<IActionResult> GetHospital(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Please specify a valid Id");
            }
            var hospital = await _repo.Hospital(id);
            if (hospital == null)
                return BadRequest("No hospital exist for the specified Id");
            return Ok(hospital);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHospital(Hospital hosp)
        {
            _repo.CreateOneHospital(hosp);

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to Create User");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditHospital(int id)
        {
            var result = _repo.Hospital(id);
            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to like User");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospital(int id)
        {
            _repo.Delete(id);

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to Delete User");
        }

    }

}