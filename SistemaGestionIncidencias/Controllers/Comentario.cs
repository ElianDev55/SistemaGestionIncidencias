using System;
using System.Linq;
using System.Web.Mvc;
using SistemaGestionIncidencias.DAL;
using SistemaGestionIncidencias.Models;

namespace SistemaGestionIncidencias.Controllers
{
    public class ComentariosController : Controller
    {
        private IncidenciasContext db = new IncidenciasContext();

        [HttpPost]
        public ActionResult AgregarComentario(int incidenciaId, string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return Json(new { success = false, message = "El comentario no puede estar vacío." });
            }

            var comentario = new Comentario
            {
                IncidenciaId = incidenciaId,
                Texto = texto,
                Fecha = DateTime.Now
            };

            db.Comentarios.Add(comentario);
            db.SaveChanges();

            return Json(new
            {
                success = true,
                fecha = comentario.Fecha.ToString("yyyy-MM-dd HH:mm"),
                texto = comentario.Texto
            });
        }

        public ActionResult ObtenerComentarios(int incidenciaId)
        {
            var comentarios = db.Comentarios
                .Where(c => c.IncidenciaId == incidenciaId)
                .OrderByDescending(c => c.Fecha)
                .Select(c => new
                {
                    c.Texto,
                    Fecha = c.Fecha // Enviamos Fecha como DateTime, sin formatear
                })
                .ToList(); // Aquí sí ejecutamos la consulta en la base de datos

            return Json(comentarios, JsonRequestBehavior.AllowGet);
        }


    }
}
