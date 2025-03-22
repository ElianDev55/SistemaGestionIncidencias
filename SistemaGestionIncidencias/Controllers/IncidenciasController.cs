using System.Linq;
using System.Net;
using System.Web.Mvc;
using SistemaGestionIncidencias.Models;
using SistemaGestionIncidencias.DAL;
using System.Data.Entity;
using PagedList;

namespace SistemaGestionIncidencias.Controllers
{
    public class IncidenciasController : Controller
    {

        public ActionResult Index(int? page, string estado, string prioridad, string tecnico)
        {
            int pageSize = 5;  // Cantidad de incidencias por página
            int pageNumber = (page ?? 1); // Página actual (por defecto, la 1)

            var query = db.Incidencias.Include(i => i.UsuarioReporta)
                                       .Include(i => i.TecnicoAsignado)
                                       .OrderByDescending(i => i.FechaCreacion)
                                       .AsQueryable();

            // Aplicar filtros
            if (!string.IsNullOrEmpty(estado))
                query = query.Where(i => i.Estado == estado);

            if (!string.IsNullOrEmpty(prioridad))
                query = query.Where(i => i.Prioridad == prioridad);

            if (!string.IsNullOrEmpty(tecnico))
                query = query.Where(i => i.TecnicoAsignado.Nombre.Contains(tecnico));

            var incidencias = query.ToPagedList(pageNumber, pageSize);  // Convierte la consulta en una lista paginada

            // Cargar listas de filtros
            ViewBag.Estados = new SelectList(new[] { "Abierto", "En Proceso", "Cerrado" });
            ViewBag.Prioridades = new SelectList(new[] { "Baja", "Media", "Alta" });
            ViewBag.Tecnicos = new SelectList(db.Usuarios.Where(u => u.EsTecnico).Select(u => u.Nombre).Distinct());


            return View(incidencias);
        }

        private IncidenciasContext db = new IncidenciasContext();

        // Método para cargar usuarios en listas desplegables
        private void CargarUsuarios()
        {
            var usuarios = db.Usuarios.Select(u => new { u.Id, u.Nombre }).ToList();
            var tecnicos = db.Usuarios.Where(u => u.EsTecnico).Select(u => new { u.Id, u.Nombre }).ToList();

            ViewBag.Usuarios = new SelectList(usuarios, "Id", "Nombre");  // Asegurar que esta variable está bien
            ViewBag.Tecnicos = new SelectList(tecnicos, "Id", "Nombre");
        }



        // GET: Incidencias/Create
        public ActionResult Create()
        {
            CargarUsuarios();
            return View();
        }

        // POST: Incidencias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Titulo,Descripcion,Estado,Prioridad,UsuarioReportaId,TecnicoAsignadoId")] Incidencia incidencia)
        {
            if (ModelState.IsValid)
            {
                incidencia.FechaCreacion = incidencia.FechaActualizacion = System.DateTime.Now;
                db.Incidencias.Add(incidencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CargarUsuarios();
            return View(incidencia);
        }

        // GET: Incidencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Incidencia incidencia = db.Incidencias.Find(id);
            if (incidencia == null)
                return HttpNotFound();

            CargarUsuarios();
            return View(incidencia);
        }

        // POST: Incidencias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Descripcion,Estado,Prioridad,UsuarioReportaId,TecnicoAsignadoId,FechaCreacion")] Incidencia incidencia)
        {
            if (ModelState.IsValid)
            {
                incidencia.FechaActualizacion = System.DateTime.Now;
                db.Entry(incidencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CargarUsuarios();
            return View(incidencia);
        }
    }
}
