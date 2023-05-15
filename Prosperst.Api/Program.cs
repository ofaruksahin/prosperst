using Azure.Core;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Extensions

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(NoContent).Assembly);
});

builder.Services.AddAutoMapper(typeof(NoContent).Assembly);
builder.Services.AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssembly(typeof(NoContent).Assembly);
});

builder.Services.AddDbContext<ProsperstDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SqlServerConnectionString");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IKPSService, KPSService>();
builder.Services.AddHttpClient<IKPSService, KPSService>(options =>
{
    string baseUrl = builder.Configuration.GetSection("KPSSettings").GetValue<string>("Url");
    options.BaseAddress = new Uri(baseUrl);
    options.DefaultRequestHeaders.Add("Host", "tckimlik.nvi.gov.tr");
    options.DefaultRequestHeaders.Add("SOAPAction", "http://tckimlik.nvi.gov.tr/WS/TCKimlikNoDogrula");
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

#endregion Extensions

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();