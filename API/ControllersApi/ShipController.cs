using App_Logic;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("API/ControllersApi/ShipController")]
    public class ShipController : Controller
    {
      

        [HttpPost("calcularcargamaxima")]
        public IActionResult CalcularCargaMaxima( double manga_Tamanno, double eslora_Tamanno)
        {
        
            LogicShip logicship = new LogicShip();
                

            try
            {
                Ship shipDTO = logicship.CalcularCargaMaxima(manga_Tamanno, eslora_Tamanno);
                return Json(new
                {
                    success = true,
                    shipDTO.contenedores_en_manga,
                    shipDTO.contenedores_en_eslora,
                    shipDTO.maximo_estiba,
                    shipDTO.total_a_transportar
             
                }); ;
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}