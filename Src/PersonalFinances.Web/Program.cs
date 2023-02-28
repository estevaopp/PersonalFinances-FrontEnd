var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


// builder.Services.AddHttpClient("PersonalFinancesApiUri", c =>
// {
//     if (app.Environment.IsStaging())
//     {
//         c.BaseAddress = new Uri("http://localhost:5281/");
//     }
//     if (app.Environment.IsProduction())
//     {
//         c.BaseAddress = new Uri("http://localhost:5281/");
//     }
//     if (app.Environment.IsDevelopment())
//     {
//         c.BaseAddress = new Uri("http://localhost:5281/");
//     }
// });

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}");

app.Run();
