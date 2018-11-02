using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WPSPApi.DataProvider;
using WPSPApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WPSPApi.Controllers
{
    //[Produces("application/json")]
    [Route("api/Patroller")]
    public class PatrollerController : Controller
    {
        private IPatrollerDataProvider patrollerDataProvider;

        // added
        private WPSPOrigContext _context { get; set; }


        public PatrollerController(IPatrollerDataProvider patrollerDataProvider)
        {
            this.patrollerDataProvider = patrollerDataProvider;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IEnumerable<Patroller>> Get()
        {
            //return await this.patrollerDataProvider.GetPatrollers();

            using (var ctx = new WPSPOrigContext())
            {
                return ctx.Patroller.FromSql("SELECT * FROM Patroller", null).ToList();

               //     .FromSql<Patroller>($"spGetPatrollers")
               //     .ToList();
                
            }
        }

        [HttpGet("{skiPatrolNumber}")]
        [Authorize]
        public async Task<Patroller> GetPatroller(int skiPatrolNumber)
        {
            return await this.patrollerDataProvider.GetPatroller(skiPatrolNumber);
        }

        [HttpPost]
        [Authorize]
        public async Task Post([FromBody]Patroller patroller)
        {
            await this.patrollerDataProvider.AddPatroller(patroller);
        }

        [HttpPut("{skiPatrolNumber}")]
        //[Authorize]
        public async Task Put(int skiPatrolNumber, [FromBody]Patroller patroller)
        {
            await this.patrollerDataProvider.UpdatePatroller(patroller);
        }

        [HttpDelete("{skiPatrolNumber}")]
        //[Authorize]
        public async Task Delete(int skiPatrolNumber)
        {
            await this.patrollerDataProvider.DeletePatroller(skiPatrolNumber);
        }
    }
}