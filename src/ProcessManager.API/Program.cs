using ProcessManager.Application.UseCases.CreateArea;
using ProcessManager.Application.UseCases.CreateProcess;
using ProcessManager.Application.UseCases.GetProcessTree;
using ProcessManager.Infrastructure;
using ProcessManager.Application.UseCases.DeleteProcess;
using ProcessManager.Application.UseCases.UpdateProcess;
using ProcessManager.Application.UseCases.ListAreas;


var builder = WebApplication.CreateBuilder(args);


// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

// UseCases
builder.Services.AddScoped<CreateAreaUseCase>();
builder.Services.AddScoped<CreateProcessUseCase>();
builder.Services.AddScoped<GetProcessTreeUseCase>();
builder.Services.AddScoped<DeleteProcessUseCase>();
builder.Services.AddScoped<UpdateProcessUseCase>();
builder.Services.AddScoped<ListAreasUseCase>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FrontendPolicy");
app.MapControllers();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
