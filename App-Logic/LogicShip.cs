using System;
using DTO;

namespace App_Logic
{
    public class LogicShip
    {
        public Ship CalcularCargaMaxima(double manga_Tamanno, double eslora_Tamanno)
        {
            Ship shipDTO = new Ship();

            // Validaciones
            if (eslora_Tamanno <= 0 || manga_Tamanno <= 0)
            {
                throw new Exception("Ninguna de las medidas puede ser 0.");
            }

            else if (eslora_Tamanno < manga_Tamanno) {

                throw new Exception("La eslora siempre debe de ser mayor a la medida de la manga.");
            }

            //Contenedor
            double anchoContenedor = 2.43;
            double largoContenedor = 12.192;
            double alturaContenedor = 2.59;
            double desperdicio = 0.1; // 10cm de desperdicio, está adaptado a m de una vez.

            shipDTO.contenedores_en_manga = (int)((manga_Tamanno - desperdicio) / (anchoContenedor + desperdicio));

            // Mitad de contenedores validacion
            int maxEstibaManga = (int)Math.Floor(manga_Tamanno / (anchoContenedor + desperdicio));
            shipDTO.contenedores_en_manga = Math.Min(shipDTO.contenedores_en_manga, maxEstibaManga);

            shipDTO.contenedores_en_eslora = (int)((eslora_Tamanno - desperdicio) / (largoContenedor + desperdicio));

            int maximoEstibaAncho = shipDTO.contenedores_en_manga / 2;
            int maximoEstibaLargo = shipDTO.contenedores_en_eslora / 2;
            shipDTO.maximo_estiba = Math.Min(maximoEstibaAncho, maximoEstibaLargo);

            shipDTO.total_a_transportar = shipDTO.contenedores_en_manga + shipDTO.contenedores_en_eslora;

            return shipDTO;
        }
    }
}
