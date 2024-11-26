using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bibliotec.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        Context context = new Context();

        public IActionResult Index()
        {
            return View();
        }

          [Route("[Logar]")]
        public IActionResult Logar(IFormCollection form)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string emailInformado = form["Email"];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string senhaInformado = form["Senha"];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            Models.Usuario usuarioBuscado = context.Usuario.FirstOrDefault(Usuario=> Usuario.Email == emailInformado && Usuario.Senha == senhaInformado)!;

            // List<Usuario> listaUsuario = context.Usuario.ToList();

            // foreach(Usuario usuario_ in listaUsuario)
            // {
            //     if(usuario.Email == emailInformado && usuario_.Senha == senhaInformado)
            //     {

            //     }else{
            //         //Usuario nao encontrado
            //     }
            // }   
            // usuarioBuscado == null
            if (usuarioBuscado == null)
            {
                Console.WriteLine($"Dados invalidos");
            return LocalRedirect("~/Login");
            }else{
                Console.WriteLine($"Parabens voce entrou!");
                HttpContext.Session.SetString("UsuarioID", usuarioBuscado.
                Usuarioid.ToString());
                 HttpContext.Session.SetString("Admin", usuarioBuscado.
                Admin.ToString());
             return LocalRedirect("~/Livro");
            }

#pragma warning disable CS0162 // Unreachable code detected
            return View();
#pragma warning restore CS0162 // Unreachable code detected
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}