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
global using AutomotiveBrands.Lib.Shared.Utilities;
global using AutomotiveBrands.Lib.Validation.Infrastructure.Validators;
global using AutomotiveBrands.Lib.Validation.IOC;
global using AutomotiveBrands.UserService.Application.Commands.Preferences.Create;
global using AutomotiveBrands.UserService.Application.Commands.Preferences.Update;
global using AutomotiveBrands.UserService.Application.Pipelines;
global using AutomotiveBrands.UserService.Application.Queries.Vehicles.List;
global using AutomotiveBrands.UserService.Fundamentals.IOC;
global using AutomotiveBrands.UserService.Fundamentals.Middlewares;
global using AutomotiveBrands.UserService.Infrastructure.Data.Context;
global using AutomotiveBrands.UserService.Infrastructure.Data.Entities.Preferences;
global using AutomotiveBrands.UserService.Infrastructure.Data.Repositories.Preferences;
global using AutomotiveBrands.UserService.Infrastructure.Data.Seeds;
global using AutomotiveBrands.UserService.Infrastructure.Data.UnitOfWork;
global using AutomotiveBrands.UserService.Infrastructure.Mappers;
global using AutomotiveBrands.UserService.Infrastructure.WebHelpers;
global using FluentValidation;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.Extensions.Primitives;
global using Serilog;
global using System.Diagnostics;
global using System.Net;
global using System.Reflection;