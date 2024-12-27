using Astrivis.Application.Services;
using Astrivis.Application.Services.Interfaces;
using Astrivis.Infrastructure;
using Astrivis.Infrastructure.Clients;
using Astrivis.Infrastructure.Repositories;
using Astrivis.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Solnet.Rpc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the in-memory database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

// Register application services
builder.Services.AddScoped<IWalletService, WalletService>();
builder.Services.AddScoped<ISolanaClient, SolanaClient>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();

// Register Solana RPC client
builder.Services.AddSingleton<IRpcClient>(ClientFactory.GetClient(Cluster.MainNet));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();