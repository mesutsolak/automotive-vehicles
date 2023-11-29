﻿namespace AutomotiveBrands.Client.Models.Request.AutomotiveBrands.Vehicle
{
    public sealed record VehicleListRequest
    {
        public BrandType Brand { get; init; }

        public VehicleListRequest(BrandType brand)
        {
            Brand = brand;
        }
    }
}