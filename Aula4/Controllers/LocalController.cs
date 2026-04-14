using Aula4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Aula4.Controllers
{
    public class LocalController : Controller
    {
        // GET: LocalController
        public ActionResult Index()
        {
            var lista = LerLista();
            return View(lista);
        }

        private List<Local> LerLista()
        {
            List<Local> lista;
            string locais = HttpContext.Session.GetString("locais");

            if (String.IsNullOrEmpty(locais))
                lista = IniciarLista();
            else
            {
                lista = JsonConvert.DeserializeObject<List<Local>>(locais);
                if (lista.Count == 0)
                    lista = IniciarLista();
            }

            return lista;
        }

        private List<Local> IniciarLista()
        {
            List<Local> lista = Local.Lista;
            AtualizarLista(lista);
            return lista;
        }

        private void AtualizarLista(List<Local> lista)
        {
            string locais = JsonConvert.SerializeObject(lista);
            HttpContext.Session.SetString("locais", locais);
        }

        // GET: LocalController/Details/5
        public ActionResult Details(int index)
        {
            var lista = LerLista();
            return View(lista[index]);
        }

        // GET: LocalController/Create
        public ActionResult Create()
        {
            return View(new Local());
        }

        // POST: LocalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Local local)
        {
            try
            {
                var lista = LerLista();
                lista.Add(local);
                AtualizarLista(lista);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LocalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(LerLista()[id]);
        }

        // POST: LocalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Local local)
        {
            try
            {
                var lista = LerLista();
                lista[id] = local;
                AtualizarLista(lista);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LocalController/Delete/5
        public ActionResult Delete(int id)
        {
            var lista = LerLista();
            return View(lista[id]);
        }

        // POST: LocalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Local local)
        {
            try
            {
                var lista = LerLista();
                lista.RemoveAt(id);
                AtualizarLista(lista);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}