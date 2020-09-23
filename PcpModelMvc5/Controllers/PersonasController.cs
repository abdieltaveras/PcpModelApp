using BLLPcpModelApp;
using BLLPcpModelApp.Models;
using Microsoft.Reporting.WebForms;
using PcpModelMvc5.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PcpModelMvc5.Controllers
{

    public class BaseController : Controller {
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            // Redirect on error:
            filterContext.Result = RedirectToAction("Index", "Error");

            // OR set the result without redirection:
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }

    public class ErroresController : Controller {

        public ActionResult ShowError()
        {
            return View("error");
        }
    }
    public class PersonasController : BaseController
    {
        // GET: Personas
        public ActionResult Index()
        {
            var personas = BLLPcpModel_App.GetPersonas(new PersonaGetParams());
            return View(personas);
        }

        // GET: Personas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Personas/Create
        public ActionResult CreateWithError(int id=-1)
        {
            
            var persona = new Persona();
            if (id>0)
            {
                
            }    
            return View(persona);
        }

        public ActionResult CreateOrEdit(int id = -1)
        {
            var model = new PersonaVm();
            if (id > 0)
            {
                var searchParam = new PersonaGetParams { IdPersona = id };
                var persona = BLLPcpModel_App.GetPersonas(searchParam).FirstOrDefault();
                if (persona != null)
                {
                    model.Persona = persona;
                }
            }
            return View(model);
        }

        // POST: Personas/Create
        [HttpPost]
        public ActionResult CreateOrEdit(Persona persona)
        {
            var next = RedirectToAction("CreateOrEdit");
            try
            {
                BLLPcpModel_App.InsUpdPersona(persona);
            }
            catch (Exception e )
            {
                TempData["error"] = $"En el metodo CreateOrEdit al tratar de guardar a {persona}, en el controlador personas, el mensaje que reporta la aplicacion es {e.Message}";
                TempData["retornarAlUrl"] = $"/Personas/CreateOrEdit/{persona.IdPersona}";
                Response.StatusCode = 500;
                next = RedirectToAction("ShowError","Errores");
            }
            return next;
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        DbPcpModelAppDataSet ds = new DbPcpModelAppDataSet();
        public ActionResult ReportPersonas()
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(900);
            reportViewer.Height = Unit.Percentage(900);

            var connectionString = ConfigurationManager.ConnectionStrings["DbPcpModelAppConnectionString"].ConnectionString;


            SqlConnection conx = new SqlConnection(connectionString); SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM TblPersonas", conx);

            adp.Fill(ds, ds.TblPersonas.TableName);

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\MyReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("MyDataSet", ds.Tables[0]));


            ViewBag.ReportViewer = reportViewer;

            return View();
        }
    }
}
