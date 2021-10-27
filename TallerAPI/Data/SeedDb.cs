using System;
using System.Linq;
using System.Threading.Tasks;
using TallerAPI.Data.Entities;
using TallerAPI.Helpers;
using TallerCommon.Enums;

namespace TallerAPI.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync ()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckVehicleTypeAsync();
            await CheckBrandAsync();
            await CheckDocumentTypeAsync();
            await CheckProcedureAsync();
            await CheckRolesAsycn();
            await CheckUserAsync("1010", "jonathan", "velasquez", "jonathanalberto123@hotmail.com", "3213914492", "Calle Luna Calle Sol", UserType.Admin);
            await CheckUserAsync("2020", "Juan", "Zuluaga", "zulu@yopmail.com", "311 322 4620", "Calle Luna Calle Sol", UserType.User);
            await CheckUserAsync("3030", "Ledys", "Bedoya", "ledys@yopmail.com", "311 322 4620", "Calle Luna Calle Sol", UserType.User);
            await CheckUserAsync("4040", "Sandra", "Lopera", "sandra@yopmail.com", "311 322 4620", "Calle Luna Calle Sol", UserType.Admin);
        }

        private async Task CheckRolesAsycn()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckUserAsync(string document, string firstName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Address = address,
                    Document = document,
                    DocumentType = _context.documentType.FirstOrDefault(x => x.Description == "Cedula"),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

              }
        }

        private async Task CheckProcedureAsync()
        {
            if (!_context.procedure.Any())
            {
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Alineación" });
                _context.procedure.Add(new Procedure { Price = 15000, Description = "Lubricación de suspención delantera" });
                _context.procedure.Add(new Procedure { Price = 20000, Description = "Lubricación de suspención trasera" });
                _context.procedure.Add(new Procedure { Price = 25000, Description = "Frenos delanteros" });
                _context.procedure.Add(new Procedure { Price = 30000, Description = "Frenos traseros" });
                _context.procedure.Add(new Procedure { Price = 35000, Description = "Líquido frenos delanteros" });
                _context.procedure.Add(new Procedure { Price = 40000, Description = "Líquido frenos traseros" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Calibración de válvulas" });
                _context.procedure.Add(new Procedure { Price = 12000, Description = "Alineación carburador" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Aceite motor" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Aceite caja" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Filtro de aire" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Sistema eléctrico" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Guayas" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Cambio llanta delantera" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Cambio llanta trasera" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Reparación de motor" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Kit arrastre" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Banda transmisión" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Cambio batería" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Lavado sistema de inyección" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Lavada de tanque" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Cambio de bujia" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Cambio rodamiento delantero" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Cambio rodamiento trasero" });
                _context.procedure.Add(new Procedure { Price = 10000, Description = "Accesorios" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDocumentTypeAsync()
        {
            if (!_context.documentType.Any())
            {
                _context.documentType.Add(new DocumentType { Description = "Cedula" });
                _context.documentType.Add(new DocumentType { Description = "NIT" });
                _context.documentType.Add(new DocumentType { Description = "Pasaporte" });
                _context.documentType.Add(new DocumentType { Description = "Tarjeta de identidad" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckBrandAsync()
        {
            if (!_context.brand.Any())
            {
                _context.brand.Add(new Brand { Description = "Ducati" });
                _context.brand.Add(new Brand { Description = "Harley Davidson" });
                _context.brand.Add(new Brand { Description = "KTM" });
                _context.brand.Add(new Brand { Description = "BMW" });
                _context.brand.Add(new Brand { Description = "Triumph" });
                _context.brand.Add(new Brand { Description = "Victoria" });
                _context.brand.Add(new Brand { Description = "Honda" });
                _context.brand.Add(new Brand { Description = "Suzuki" });
                _context.brand.Add(new Brand { Description = "Kawasaky" });
                _context.brand.Add(new Brand { Description = "TVS" });
                _context.brand.Add(new Brand { Description = "Bajaj" });
                _context.brand.Add(new Brand { Description = "AKT" });
                _context.brand.Add(new Brand { Description = "Yamaha" });
                _context.brand.Add(new Brand { Description = "Chevrolet" });
                _context.brand.Add(new Brand { Description = "Mazda" });
                _context.brand.Add(new Brand { Description = "Renault" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckVehicleTypeAsync()
        {
            if (!_context.vehicleTypes.Any())
            {
                _context.vehicleTypes.Add(new VehicleType { Description = "Carro" });
                _context.vehicleTypes.Add(new VehicleType { Description = "Moto" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
