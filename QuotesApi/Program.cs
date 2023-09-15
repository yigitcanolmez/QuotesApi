using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using QuotesApi.Data;
using QuotesApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-iaz33aj5ecqggglu.us.auth0.com";
    options.Audience = "http://localhost:5123";
});
 

builder.Services.AddControllers().AddXmlSerializerFormatters();

 
builder.Services.AddDbContext<QuoteDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Sql"));
});
builder.Services.AddResponseCaching();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseResponseCaching();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlerMiddleware>();


app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();
app.UseMiddleware<DenemeMiddleware>();

app.Run();

