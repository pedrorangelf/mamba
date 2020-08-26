using System;

namespace Mamba.API.Extensions.Utilities
{
    public static class DateTimeUtilities
    {
        public static string ObterPeriodoTemporal(DateTime data, string prefixo = "")
        {
            if (!string.IsNullOrEmpty(prefixo)) prefixo += " ";

            var substract = DateTime.Now.Subtract(data);
            var horas = substract.Hours;
            var dias = substract.Days;
            var meses = Math.Floor(dias / (365.25 / 12));
            var anos = meses / 12;
            
            if (dias < 1)
            {
                if (horas < 1)
                    return prefixo + "há alguns minutos";

                return prefixo + "há " + ((horas == 1) ? $"{horas} hora" : $"{horas} horas");
            }

            if (meses < 1)
                return prefixo + "há " + ((dias == 1) ? $"{dias} dia" : $"{dias} dias");

            if (meses >= 12)
                return prefixo + "há " + ((anos == 1) ? $"{anos} ano" : $"{anos} anos");

            return prefixo + "há " + ((meses == 1) ? $"{meses} mês" : $"{meses} meses");
        }
    }
}
