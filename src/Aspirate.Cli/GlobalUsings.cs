// Global using directives

global using System.IO.Abstractions;
global using System.ComponentModel;
global using System.Text;
global using System.Text.Json;
global using Aspirate.Cli.Commands.Apply;
global using Aspirate.Cli.Commands.Destroy;
global using Aspirate.Cli.Commands.Generate;
global using Aspirate.Cli.Commands.Init;
global using Microsoft.Extensions.DependencyInjection;

global using Aspirate.Cli.Extensions;
global using Aspirate.Cli.Processors.Components.Final;
global using Aspirate.Cli.Processors.Components.Postgresql;
global using Aspirate.Cli.Processors.Components.Project;
global using Aspirate.Cli.Processors.Components.RabbitMQ;
global using Aspirate.Cli.Processors.Components.Redis;
global using Aspirate.Cli.Services;
global using Aspirate.Contracts.Extensions;
global using Aspirate.Contracts.Interfaces;
global using Aspirate.Contracts.Literals;
global using Aspirate.Contracts.Models;
global using Aspirate.Contracts.Models.Aspirate;
global using Aspirate.Contracts.Models.AspireManifests;
global using Aspirate.Contracts.Models.AspireManifests.Components;
global using Aspirate.Contracts.Models.AspireManifests.Components.V0;
global using Aspirate.Contracts.Models.MsBuild;
global using Aspirate.Contracts.Processors;
global using Aspirate.Spectre.DependencyInjection;
global using CliWrap;
global using CliWrap.EventStream;
global using Spectre.Console;
global using Spectre.Console.Cli;
