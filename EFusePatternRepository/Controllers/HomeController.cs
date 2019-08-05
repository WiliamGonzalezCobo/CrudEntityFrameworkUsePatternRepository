using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_Repo.Negocio;
using EF_Repo.Dto;
using EFusePatternRepository.Models;
using EF_Repo.Utils.MapperBase;
using EFusePatternRepository.SpecificationMapper;

namespace EFusePatternRepository.Controllers
{
    public class HomeController : Controller
    {
        private UserDetailBusiness userDetailBusiness;
        private UserDetailModel userModel;
        public HomeController()
        {
            userDetailBusiness = new UserDetailBusiness();
        }

        public ActionResult Usuarios()
        {
            //var test1 = userDetailBusiness.GetUsersName("william");
            //var test2 = userDetailBusiness.GetUsersEmail("wifagoco@gmail.com");
            //var test3 = userDetailBusiness.GetUsersAll();
            //var test4 = userDetailBusiness.GetUsersCity("cali");
            //IReadOnlyList<UserDetailDto> test5 = userDetailBusiness.GetUsersCityAndName("cali", "felipe");
            //if (test5.Any()) {
            //    var test6 = userDetailBusiness.ValidMail("wifigoco@gmail.com", test5.FirstOrDefault());
            //}

            return View(MapperConfigurationCentral<UserDetailDto, UserDetailModel>.MapList(userDetailBusiness.GetUsersAll(), SpecificationMapper.SpecificationMapper.UserDetailDtoToModel));
        }

        public ActionResult AgregarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarUsuario(UserDetailModel model)
        {
            if (ModelState.IsValid)
            {
                userDetailBusiness.AddUser(MapperConfigurationCentral<UserDetailModel, UserDetailDto>.MapEntity(model));
            }
            return RedirectToAction("Usuarios");
        }

        public ActionResult ActualizarUsuario(int? id)
        {

            if (id.HasValue)
            {
                userModel = MapperConfigurationCentral<UserDetailDto, UserDetailModel>.MapEntity(userDetailBusiness.GetUserById(id.Value), SpecificationMapper.SpecificationMapper.UserDetailDtoToModel);
            }
            else
            {
                return RedirectToAction("Usuarios");
            }
            return View(userModel);
        }

        [HttpPost]
        public ActionResult ActualizarUsuario(UserDetailModel model)
        {
            if (ModelState.IsValid)
            {
                userDetailBusiness.UpdateUser(MapperConfigurationCentral<UserDetailModel, UserDetailDto>.MapEntity(model, SpecificationMapper.SpecificationMapper.UserDetailModelToDto));
            }
            return RedirectToAction("Usuarios");
        }

        public ActionResult BorrarUsuario(int? id)
        {

            if (id.HasValue)
            {
                userModel = MapperConfigurationCentral<UserDetailDto, UserDetailModel>.MapEntity(userDetailBusiness.GetUserById(id.Value), SpecificationMapper.SpecificationMapper.UserDetailDtoToModel);
            }
            else
            {
                return RedirectToAction("Usuarios");
            }
            return View(userModel);
        }

        [HttpPost]
        public ActionResult BorrarUsuario(UserDetailModel model)
        {
            if (ModelState.IsValid)
            {
                userDetailBusiness.DeleteUser(MapperConfigurationCentral<UserDetailModel, UserDetailDto>.MapEntity(model, SpecificationMapper.SpecificationMapper.UserDetailModelToDto).IdUserDetail);
            }
            return RedirectToAction("Usuarios");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}