﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RideServiceGroup1.DAL;
using RideServiceGroup1.Entities;

namespace RideServiceGroup1.Web.Pages
{
    public class indexModel : PageModel
    {
        public List<Ride> Rides { get; set; }
        public void OnGet()
        {
            RideRepository rideRepo = new RideRepository();

            Rides = rideRepo.GetAllRideImgs();


            //Rides.Add(new Ride()
            //{
            //    Id = 1,
            //    Category = new RideCategory() { Id = 1, Description = "Vandting", Name = "Vandforlystelse" },
            //    Name = "Orkanen",
            //    Description = "Meget lang beskrivelse om orkanen som er sjov og nui gider jeg ikke skrive mere men det her er mere end 50 tegn"
            //} );
        }
    }
}