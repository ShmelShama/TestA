using TestAssignment.DAL;
using TestAssignment.DAL.MapProfile;
using TestAssignment.DAL.DataAccessService;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddJsonOptions(options => options
    .JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TestAssignDbContext>();
builder.Services.AddAutoMapper(typeof(ProductCategoryProfile), typeof(ProductProfile));
builder.Services.AddScoped<ProductCategoryService>();
builder.Services.AddScoped<ProductService>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
