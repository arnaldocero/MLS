using MLS.Common.Enums;
using MLS.Web.Data.Entities;
using MLS.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MLS.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext dataContext,
                        IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            var admin = await CheckUserAsync("1140827910", "Arnaldo Alfonso", "Pacheco Sarmiento", "arnaldopachecosarmiento@gmail.com", "3016253057", "Calle 9A #25-62", UserType.Administrador);
            var operador = await CheckUserAsync("1140827910", "Arnaldo Alfonso", "Pacheco Sarmiento", "p.arnaldoalfonso@hotmail.com", "3016253057", "Calle 9A #25-62", UserType.Usertrabajador);
            var consulta = await CheckUserAsync("1140827910", "Arnaldo Alfonso", "Pacheco Sarmiento", "arnaldopacheco1@outlook.com", "3016253057", "Calle 9A #25-62", UserType.Userpaciente);
            await CheckTaxisAsync(admin,operador,consulta);
        }

        private async Task<UserEntity> CheckUserAsync(string document,
    string firstName,
    string lastName,
    string email,
    string phone,
    string address,
    UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "1140827910");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
            return user;

        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Administrador.ToString());
            await _userHelper.CheckRoleAsync(UserType.Userpaciente.ToString());
            await _userHelper.CheckRoleAsync(UserType.Usertrabajador.ToString());

        }

        private async Task CheckTaxisAsync(
            UserEntity admin,
            UserEntity operador,
            UserEntity consulta)
        {
            if (!_dataContext.Documento.Any())
            {
                _dataContext.Documento.Add(new DocumentoEntity
                {
                    Name = "Primer documento",
                    Document = "1140827910",
                    FirstName = "Arnaldo Pacheco",
                    pdfUrl = "pdf/archivo/documento.pdf",
                    UploadDate = DateTime.UtcNow,
                    User=operador



                });

                _dataContext.Documento.Add(new DocumentoEntity
                {
                    Name = "Segundo documento",
                    Document = "1043605313",
                    FirstName = "Marijulie Solano",
                    pdfUrl = "pdf/archivo/documentos.pdf",
                    UploadDate = DateTime.UtcNow,
                    User = operador

                });

                await _dataContext.SaveChangesAsync();
            }
        }

    }
}
