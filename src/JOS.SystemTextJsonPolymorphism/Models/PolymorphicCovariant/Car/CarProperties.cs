﻿using System;

namespace JOS.SystemTextJsonPolymorphism.Models.PolymorphicCovariant.Car
{
    public class CarProperties : VehicleProperties
    {
        public CarProperties(int wheels, int passengers, CarRims rims) : base(wheels, passengers)
        {
            Rims = rims ?? throw new ArgumentNullException(nameof(rims));
        }

        public CarRims Rims { get; }
    }
}
