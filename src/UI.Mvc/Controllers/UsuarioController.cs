using Domain.Acessos.Entitites;
using FastMapper;
using Microsoft.AspNet.Identity;
using Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI.Mvc.Models;

namespace UI.Mvc.Controllers
{
    public class UsuarioController : Controller
    {
        private UserManager<UsuarioEntity, string> _userManager;

        public UsuarioController()
        {
            _userManager = new AppUserManager();
        }

        // GET: Usuario
        public ActionResult Index()
        {
            var usuarios = _userManager.Users.Select(x => new UsuarioViewModel()
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email
            });

            return View(usuarios);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel registro)
        {
            if (ModelState.IsValid)
            {
                var usuario = new UsuarioEntity()
                {
                    UserName = registro.UserName,
                    Email = registro.Email,
                    Ativo = true
                };

                var resultado = await _userManager.CreateAsync(usuario, registro.Password);

                if (resultado.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    AddErrors(resultado);
                    return View(registro);
                }
            }

            return View();
        }

        // GET: Usuario/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var usuarioEntity = await _userManager.FindByIdAsync(id);

            var usuario = TypeAdapter.Adapt<UsuarioEntity, UsuarioViewModel>(usuarioEntity);

            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(UsuarioViewModel usuarioViewModel)
        {
                var usuario = await _userManager.FindByIdAsync(usuarioViewModel.Id);
                usuario.Email = usuarioViewModel.Email;
                usuario.UserName = usuarioViewModel.UserName;

                var result = await _userManager.UpdateAsync(usuario);

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    AddErrors(result);
                    return View();
                }
        }

        // POST: Usuario/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {

            // TODO: Add delete logic here

            var user = await _userManager.FindByIdAsync(id);
            var resultado = await _userManager.DeleteAsync(user);

            if (resultado.Succeeded)
                return RedirectToAction("Index");
            else
            {
                ViewBag.erro = "Erro ao deletar usuario";
                return View();
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
