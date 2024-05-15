using BClaims.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var uri = new Uri(builder.Configuration["ApiConfiguration:BaseAddress"] + "api/v1/");

builder.Services.AddClient(uri);
builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
