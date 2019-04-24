﻿using System;

namespace RideServiceGroup1.Entities
{
    public class RideCategory : IEntity
    {
        public RideCategory()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
