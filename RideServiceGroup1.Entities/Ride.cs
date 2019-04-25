﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RideServiceGroup1.Entities
{
    public class Ride
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RideCategory Category { get; set; }
        public Status Status
        {
            get => Reports.Count == 0
                ? Status.Working
                : Reports.OrderBy(x => x.Status).FirstOrDefault().Status;
        }
        public List<Report> Reports { get; set; } 
        public string Url
        {
            get => $"/Img/{Name.ToLower()}.jpg";
        }

        public Ride()
        {

        }

        public int NumbersOfShutdowns()
        {
            int numberOfShutdowns = 0;
            Reports.ForEach(x =>
            {
                if (x.Status == Status.Broken)
                    numberOfShutdowns++;
            });
            return numberOfShutdowns;
        }

        public int DaysSinceLastShutdown()
        {
            DateTime lastShutdown = new DateTime();

            //var q = Reports.Where(x => x.Status == Status.Broken).OrderByDescending(t => t.ReportTime).FirstOrDefault();
            
            foreach (Report report in Reports)
            {
                if (report.Status == Status.Broken)
                {
                    lastShutdown = report.ReportTime;
                    TimeSpan timeSinceLastShutdown = DateTime.Now - lastShutdown;
                    return timeSinceLastShutdown.Days;
                }
            }
            return 0;
        }
    }
}
