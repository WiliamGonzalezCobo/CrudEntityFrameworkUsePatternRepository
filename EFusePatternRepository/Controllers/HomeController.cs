using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_Repo.Negocio;
using EF_Repo.Dto;
using AutoMapper;
using EFusePatternRepository.Models;

namespace EFusePatternRepository.Controllers
{
    public class HomeController : Controller
    {
        private UserDetailBusiness userDetailBusiness;
        private MapperConfiguration configMapUserDtoToUserModel;
        private MapperConfiguration configMapUserModelToUserDto;
        private IMapper mapper;
        private UserDetailModel userModel;
        public HomeController()
        {

            userDetailBusiness = new UserDetailBusiness();
            configMapUserDtoToUserModel = new MapperConfiguration(cfg => cfg.CreateMap<UserDetailDto, UserDetailModel>());
            configMapUserModelToUserDto = new MapperConfiguration(cfg => cfg.CreateMap<UserDetailModel, UserDetailDto>());

        }

        public ActionResult Usuarios()
        {
            var test1 = userDetailBusiness.GetUsersName("william");
            var test2 = userDetailBusiness.GetUsersEmail("wifagoco@gmail.com");
            var test3 = userDetailBusiness.GetUsersAll();
            var test4 = userDetailBusiness.GetUsersCity("cali");
            IReadOnlyList<UserDetailDto> test5 = userDetailBusiness.GetUsersCityAndName("cali", "felipe");
            var test6 = userDetailBusiness.ValidMail("wifigoco@gmail.com",test5.FirstOrDefault());

            mapper = configMapUserDtoToUserModel.CreateMapper();
            return View(mapper.Map<IReadOnlyList<UserDetailDto>, IReadOnlyList<UserDetailModel>>(userDetailBusiness.GetUsersAll()));
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
                mapper = configMapUserModelToUserDto.CreateMapper();
                userDetailBusiness.AddUser(mapper.Map<UserDetailDto>(model));
            }
            return RedirectToAction("Usuarios");
        }

        public ActionResult ActualizarUsuario(int? id)
        {

            if (id.HasValue)
            {
                mapper = configMapUserDtoToUserModel.CreateMapper();
                userModel = mapper.Map<UserDetailModel>(userDetailBusiness.GetUserById(id.Value));
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
                mapper = configMapUserModelToUserDto.CreateMapper();
                userDetailBusiness.UpdateUser(mapper.Map<UserDetailDto>(model));
            }
            return RedirectToAction("Usuarios");
        }

        public ActionResult BorrarUsuario(int? id)
        {

            if (id.HasValue)
            {
                mapper = configMapUserDtoToUserModel.CreateMapper();
                userModel = mapper.Map<UserDetailModel>(userDetailBusiness.GetUserById(id.Value));
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
                mapper = configMapUserModelToUserDto.CreateMapper();
                userDetailBusiness.DeleteUser(mapper.Map<UserDetailDto>(model).Id);
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