using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using apr.Entities;
using apr.Business;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using apr.WebMVC.Models;

namespace apr.WebMVC.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public JsonResult findAll()
        {
            List<Pedidos> pedidos = new List<Pedidos>();
            try
            {
                pedidos = new PedidosBll().findAll();
            }
            catch (Exception ex)
            {

                //throw;
            }

            return Json(pedidos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult create(Pedidos pedido)
        {
            ResponseResult<Pedidos> responseResult;

            try
            {

                if (new PedidosBll().create(pedido))
                    responseResult = new ResponseResult<Pedidos>() { State = true, Message = "Pedido Registrado correctamete" };
                else
                    responseResult = new ResponseResult<Pedidos>() { State = false, Message = "El Registro de Pedido no Fue posible" };
            }
            catch (Exception ex)
            {
                responseResult = new ResponseResult<Pedidos>() { State = false, Message = ex.Message };
            }


            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

    }
}