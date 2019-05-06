using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using apr.Entities;
using apr.Business;
using apr.WebMVC.Models;

namespace apr.WebMVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult findAll()
        {
            List<Productos> productos = new List<Productos>();
            try
            {
                productos = new ProductosBll().findAll();
            }
            catch (Exception ex)
            {

            }

            return Json(productos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult create(Productos producto)
        {
            ResponseResult<Productos> responseResult;

            try
            {

                if (new ProductosBll().create(producto))
                    responseResult = new ResponseResult<Productos>() { State = true, Message = "Producto Registrado correctamete" };
                else
                    responseResult = new ResponseResult<Productos>() { State = false, Message = "El Registro de Producto no Fue posible" };
            }
            catch (Exception ex)
            {
                responseResult = new ResponseResult<Productos>() { State = false, Message = ex.Message };        
            }


            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult find(Int32 idproducto)
        {
            ResponseResult<Productos> responseResult = new ResponseResult<Productos>();

            Productos producto = null;
            try
            {
                producto = new ProductosBll().find(idproducto);

                responseResult.State = true;
                responseResult.Data = producto;
            }
            catch (Exception ex)
            {
                responseResult.State = false;
                responseResult.Message = ex.Message;
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult edit(Productos producto)
        {
            ResponseResult<Productos> responseResult;

            try
            {

                if (new ProductosBll().edit(producto))
                    responseResult = new ResponseResult<Productos>() { State = true, Message = "Producto Actualizado correctamete" };
                else
                    responseResult = new ResponseResult<Productos>() { State = false, Message = "La Actualización de Producto no Fue posible" };
            }
            catch (Exception ex)
            {
                responseResult = new ResponseResult<Productos>() { State = false, Message = ex.Message };                
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult remove(Int32 idproducto)
        {
            ResponseResult<Productos> responseResult;

            try
            {

                if (new ProductosBll().remove(idproducto))
                    responseResult = new ResponseResult<Productos>() { State = true, Message = "Producto Eliminado correctamete" };
                else
                    responseResult = new ResponseResult<Productos>() { State = false, Message = "La Eliminacion de Producto no Fue posible" };
            }
            catch (Exception ex)
            {
                responseResult = new ResponseResult<Productos>() { State = false, Message = ex.Message };               
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult findAllByIdCategoria(Int32 idcategoria)
        {
            List<Productos> productos = new List<Productos>();
            try
            {
                productos = new ProductosBll().findAllByIdCategoria(idcategoria);
            }
            catch (Exception ex)
            {

            }

            return Json(productos, JsonRequestBehavior.AllowGet);
        }
    }
}