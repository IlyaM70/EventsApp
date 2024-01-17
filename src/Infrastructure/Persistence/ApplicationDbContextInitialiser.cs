using EventsApp.Domain.Models;
using EventsApp.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventsApp.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsNpgsql())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        #region Default roles
        var administratorRole = new IdentityRole<int>(Constants.Role_Admininstrator);
        var userRole = new IdentityRole<int>(Constants.Role_User);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
            await _roleManager.CreateAsync(administratorRole);


        if (_roleManager.Roles.All(r => r.Name != userRole.Name))
            await _roleManager.CreateAsync(userRole);
        #endregion

        #region Default users
        var administrator = new User { UserName = "admin@EventsApp", Email = "admin@EventsApp", SecurityStamp = Guid.NewGuid().ToString() };
        var alexand = new User { UserName = "Alexandr", Email = "Alexandr@mail.ru", Gender = Constants.Gender_Male, SecurityStamp = Guid.NewGuid().ToString() };
        var maxim = new User { UserName = "Maxim", Email = "Maxim@mail.ru", Gender = Constants.Gender_Male, SecurityStamp = Guid.NewGuid().ToString() };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            await _userManager.AddToRolesAsync(administrator, new string[] { administratorRole.Name! });
        }
        if (_userManager.Users.All(u => u.UserName != alexand.UserName))
        {

            await _userManager.CreateAsync(alexand, "Alexand12345678!");
            await _userManager.AddToRolesAsync(maxim, new string[] { userRole.Name! });
        }
        if (_userManager.Users.All(u => u.UserName != maxim.UserName))
        {
            await _userManager.CreateAsync(maxim, "Maxim12345678!");
            await _userManager.AddToRolesAsync(maxim, new string[] { userRole.Name! });
        }



        #endregion

        #region Default data
        // Seed, if necessary
        if (!_context.Categories.Any())
        {
            _context.Categories.AddRange(
                new Category()
                {
                    Name = "Кино"
                },
                new Category()
                {
                    Name = "Хоккей"
                },
                new Category()
                {
                    Name = "Бар"
                }
                );

            await _context.SaveChangesAsync();
        }

        if (!_context.Events.Any())
        {
            _context.Events.AddRange(
                
                new Event()
                {
                    Name="Кино",
                    Address="Улица 1, 1",
                    Description="Сходим в кино",
                    CategoryId = _context.Categories.Where(x => x.Name == "Кино").FirstOrDefault()!.Id,
                    CreaterId = Convert.ToInt32(_context.Users.Where(x=>x.Email== "Alexandr@mail.ru").FirstOrDefault()!.Id),
                    GenderRestrictions = Constants.Gender_None,
                    IsCommercial = false,
                    ApplicationsDue = DateTime.UtcNow.AddDays(1),
                    Begining = DateTime.UtcNow.AddDays(1).AddHours(2),
                    Ending = DateTime.UtcNow.AddDays(1).AddHours(5),
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                    MainEventId = null,
                    MinPersons = 2,
                    MaxPersons = 5,
                    MinAge = 20,
                    MaxAge = 25,
                },
                new Event()
                {
                    Name = "Бар",
                    Address = "Улица 1, 2",
                    Description = "Сходим в Бар",
                    CategoryId = _context.Categories.Where(x => x.Name == "Бар").FirstOrDefault()!.Id,
                    CreaterId = Convert.ToInt32(_context.Users.Where(x => x.Email == "Maxim@mail.ru").FirstOrDefault()!.Id),
                    GenderRestrictions = Constants.Gender_None,
                    IsCommercial = false,
                    ApplicationsDue = DateTime.UtcNow.AddDays(1),
                    Begining = DateTime.UtcNow.AddDays(1).AddHours(2),
                    Ending = DateTime.UtcNow.AddDays(1).AddHours(5),
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                    MainEventId = null,
                    MinPersons = 2,
                    MaxPersons = 5,
                    MinAge = 20,
                    MaxAge = 25,
                },                
                new Event()
                {
                    Name = "Сходим в Кино потом на Хоккей",
                    Address = "Улица 2, 2",
                    Description = "Сходим в Кино потом на Хоккей",
                    CategoryId = _context.Categories.Where(x => x.Name == "Хоккей").FirstOrDefault()!.Id,
                    CreaterId = Convert.ToInt32(_context.Users.Where(x => x.Email == "Maxim@mail.ru").FirstOrDefault()!.Id),
                    GenderRestrictions = Constants.Gender_None,
                    IsCommercial = false,
                    ApplicationsDue = DateTime.UtcNow.AddDays(3),
                    Begining = DateTime.UtcNow.AddDays(3).AddHours(2),
                    Ending = DateTime.UtcNow.AddDays(3).AddHours(5),
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                    MainEventId = null,
                    MinPersons = 2,
                    MaxPersons = 5,
                    MinAge = 20,
                    MaxAge = 25,
                }
                );

            await _context.SaveChangesAsync();

            _context.Events.AddRange(
                new Event()
                {
                    Name = "Сходим в Кино",
                    Address = "Улица 2, 2",
                    Description = "Сходим в Кино",
                    CategoryId = _context.Categories.Where(x => x.Name == "Кино").FirstOrDefault()!.Id,
                    CreaterId = Convert.ToInt32(_context.Users.Where(x => x.Email == "Maxim@mail.ru").FirstOrDefault()!.Id),
                    GenderRestrictions = Constants.Gender_None,
                    IsCommercial = false,
                    ApplicationsDue = DateTime.UtcNow.AddDays(3),
                    Begining = DateTime.UtcNow.AddDays(3).AddHours(2),
                    Ending = DateTime.UtcNow.AddDays(3).AddHours(5),
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                    MainEventId = _context.Events.Where(x => x.Name == "Сходим в Кино потом на Хоккей").FirstOrDefault()!.Id,
                    MinPersons = 2,
                    MaxPersons = 5,
                    MinAge = 20,
                    MaxAge = 25,
                },
                new Event()
                {
                    Name = "Хоккей",
                    Address = "Улица 2, 2",
                    Description = "Сходим на Хоккей",
                    CategoryId = _context.Categories.Where(x => x.Name == "Хоккей").FirstOrDefault()!.Id,
                    CreaterId = Convert.ToInt32(_context.Users.Where(x => x.Email == "Maxim@mail.ru").FirstOrDefault()!.Id),
                    GenderRestrictions = Constants.Gender_None,
                    IsCommercial = false,
                    ApplicationsDue = DateTime.UtcNow.AddDays(3),
                    Begining = DateTime.UtcNow.AddDays(3).AddHours(2),
                    Ending = DateTime.UtcNow.AddDays(3).AddHours(5),
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                    MainEventId = _context.Events.Where(x => x.Name == "Сходим в Кино потом на Хоккей").FirstOrDefault()!.Id,
                    MinPersons = 2,
                    MaxPersons = 5,
                    MinAge = 20,
                    MaxAge = 25,
                }
                );

            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
