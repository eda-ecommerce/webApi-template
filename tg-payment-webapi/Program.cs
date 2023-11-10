var builder = WebApplication.CreateBuilder(args);

// CORS
var ProverbAllowSpecificOrigins = "_ProverbAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: ProverbAllowSpecificOrigins,
        builder => {
            builder
                .WithOrigins("http://localhost:4200")
                .WithOrigins("https://sayings.marckevinzenzen.de")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


// Services
builder.Services.AddScoped<IPaymentService, PaymentService>();

// Repos
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

// Add Mapster Mapping
var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
typeAdapterConfig.Scan(Assembly.GetAssembly(typeof(SayingToSayingDtoRegister)));
// register the mapper as Singleton service for my application
var mapperConfig = new Mapper(typeAdapterConfig);
builder.Services.AddSingleton<IMapper>(mapperConfig);

//DbContext
builder.Services.AddDbContext<PaymentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(ProverbAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
