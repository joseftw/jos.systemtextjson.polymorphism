﻿using System;

namespace JOS.SystemTextJsonPolymorphism.Models.PolymorphicCovariant.Truck
{
    public class TruckTrailer
    {
        public TruckTrailer(string name, int wheels)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Wheels = wheels;
        }

        public string Name { get; }
        public int Wheels { get; }
    }
}
