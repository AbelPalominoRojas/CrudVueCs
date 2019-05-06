using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using apr.Business;
using apr.Entities;
using apr.WebMVC.Models;

namespace apr.WebMVC.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }
        
        
        public JsonResult findAll()
        {
           // if (!Request.IsAjaxRequest()) return Json(new List<Categorias>(), JsonRequestBehavior.AllowGet);

            List<Categorias> categorias = new List<Categorias>();
            try
            {
                categorias = new CategoriasBll().findAll();
            }
            catch (Exception ex)
            {

                //throw;
            }


            return Json(categorias,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult create(Categorias categoria)
        {
            ResponseResult<Categorias> responseResult;

            try
            {

                if(new CategoriasBll().create(categoria))
                    responseResult = new ResponseResult<Categorias>() { State = true, Message = "Categoria Registrado correctamete" };
                else
                    responseResult = new ResponseResult<Categorias>() { State = false, Message = "El Registro de Categoria no Fue posible" };
            }
            catch (Exception ex)
            {
                responseResult = new ResponseResult<Categorias>() { State = false, Message = ex.Message };
               // throw;
            }


            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult find(Int32 idcategoria)
        {
            ResponseResult<Categorias> responseResult = new ResponseResult<Categorias>();

            Categorias categoria = null;
            try
            {
                categoria = new CategoriasBll().find(idcategoria);

                responseResult.State = true;
                responseResult.Data = categoria;
            }
            catch (Exception ex)
            {
                responseResult.State = false;
                responseResult.Message = ex.Message;
                
                //throw;
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult edit(Categorias categoria)
        {
            ResponseResult<Categorias> responseResult;

            try
            {

                if (new CategoriasBll().edit(categoria))
                    responseResult = new ResponseResult<Categorias>() { State = true, Message = "Categoria Actualizado correctamete" };
                else
                    responseResult = new ResponseResult<Categorias>() { State = false, Message = "La Actualización de Categoria no Fue posible" };
            }
            catch (Exception ex)
            {
                responseResult = new ResponseResult<Categorias>() { State = false, Message = ex.Message };
                // throw;
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult remove(Int32 idcategoria)
        {
            ResponseResult<Categorias> responseResult;

            try
            {

                if (new CategoriasBll().remove(idcategoria))
                    responseResult = new ResponseResult<Categorias>() { State = true, Message = "Categoria Eliminado correctamete" };
                else
                    responseResult = new ResponseResult<Categorias>() { State = false, Message = "La Eliminacion de Categoria no Fue posible" };
            }
            catch (Exception ex)
            {
                responseResult = new ResponseResult<Categorias>() { State = false, Message = ex.Message };
                // throw;
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

    }
}