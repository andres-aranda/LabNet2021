using Logica;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PresentacionMVC.Controllers
{
    public class JuegosAPIController : Controller
    {
        readonly APILogic Logic = new APILogic();
        // GET: JuegosAPI
        public async Task<ActionResult> Index()
        {
            var lista = await Logic.GetJuegos();

            return View(lista);
        }
      
    }
}