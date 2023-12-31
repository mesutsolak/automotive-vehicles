﻿namespace AutomotiveBrands.Client.ViewModels
{
    public sealed record ListViewModel
    {
        public ListViewModel(List<VehicleListResponse> vehicleListResponses)
        {
            VehicleListResponses = vehicleListResponses;
        }

        public List<VehicleListResponse> VehicleListResponses { get; init; }
    }
}
