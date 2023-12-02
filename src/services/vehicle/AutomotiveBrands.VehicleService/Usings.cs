﻿global using AutoMapper;
global using AutomotiveBrands.Lib.ApiVersion.Infrastructure.Constants;
global using AutomotiveBrands.Lib.ApiVersion.Infrastructure.Providers;
global using AutomotiveBrands.Lib.ApiVersion.IOC;
global using AutomotiveBrands.Lib.Database.Abstract;
global using AutomotiveBrands.Lib.Database.Concrete;
global using AutomotiveBrands.Lib.Database.Configurations;
global using AutomotiveBrands.Lib.Database.Infrastructure.Extensions;
global using AutomotiveBrands.Lib.Database.IOC;
global using AutomotiveBrands.Lib.Database.Middlewares;
global using AutomotiveBrands.Lib.Documentation.IOC;
global using AutomotiveBrands.Lib.Documentation.Middlewares;
global using AutomotiveBrands.Lib.Host.IOC;
global using AutomotiveBrands.Lib.Host.Setup;
global using AutomotiveBrands.Lib.Performance.IOC;
global using AutomotiveBrands.Lib.Performance.Middlewares;
global using AutomotiveBrands.Lib.RateLimit.IOC;
global using AutomotiveBrands.Lib.Response.Controllers;
global using AutomotiveBrands.Lib.Response.Models;
global using AutomotiveBrands.Lib.Shared.Enums;
global using AutomotiveBrands.Lib.Shared.Utilities;
global using AutomotiveBrands.Lib.Validation.Infrastructure.Validators;
global using AutomotiveBrands.Lib.Validation.IOC;
global using AutomotiveBrands.UserService.Infrastructure.Data.UnitOfWork;
global using AutomotiveBrands.VehicleService.Application.Pipelines;
global using AutomotiveBrands.VehicleService.Application.Queries.Vehicles.Detail;
global using AutomotiveBrands.VehicleService.Application.Queries.Vehicles.GetById;
global using AutomotiveBrands.VehicleService.Application.Queries.Vehicles.List;
global using AutomotiveBrands.VehicleService.Fundamentals.IOC;
global using AutomotiveBrands.VehicleService.Fundamentals.Middlewares;
global using AutomotiveBrands.VehicleService.Infrastructure.Data.Context;
global using AutomotiveBrands.VehicleService.Infrastructure.Data.Entities.Vehicles;
global using AutomotiveBrands.VehicleService.Infrastructure.Data.Repositories.Vehicles.Abstract;
global using AutomotiveBrands.VehicleService.Infrastructure.Data.Repositories.Vehicles.Concrete;
global using AutomotiveBrands.VehicleService.Infrastructure.Data.Seeds;
global using AutomotiveBrands.VehicleService.Infrastructure.Data.UnitOfWork;
global using AutomotiveBrands.VehicleService.Infrastructure.Mappers;
global using FluentValidation;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Serilog;
global using System.Diagnostics;
global using System.Reflection;