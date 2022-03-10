using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPU_Z.Data;
using CPU_Z.Models;
using HtmlAgilityPack;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;


namespace CPU_Z.Controllers
{

    public class api : Controller
    {
        public ActionResult request(string nombre, string marca){

            string arquitectura = "", litografia = "", fecha = "", socket = "", fbase = "", fturbo = "", rbase = "", ram = "", urlimg = "", c1 = "", c2 = "", c3 = "", multiplicador = "";
            int hilos = 0, nucleos = 0, mm = 0, dd = 0, yyyy = 0;
            decimal precio = 0;

            var list = obtenerDetalles.WebDataScrap(nombre, marca);
            List<(string, string)> listaDimencional = new List<(string, string)>();
            //AMD
            if (marca == "amd")
            {
                arquitectura = list[0];
                litografia = list[1];
                fecha = list[2];
                int mesNumero = 0;
                List<char> fechaf = new List<char>();
                foreach (char f in fecha)
                {
                    fechaf.Add(f);
                }
                if (fecha.Length == 18)
                {
                    var mes = "" + fechaf[5] + fechaf[6] + fechaf[7] + "";

                    switch (mes)
                    {
                        case "ene":
                            mesNumero = 01;
                            break;
                        case "feb":
                            mesNumero = 02;
                            break;
                        case "mar":
                            mesNumero = 03;
                            break;
                        case "abr":
                            mesNumero = 04;
                            break;
                        case "may":
                            mesNumero = 05;
                            break;
                        case "jun":
                            mesNumero = 06;
                            break;
                        case "jul":
                            mesNumero = 07;
                            break;
                        case "ago":
                            mesNumero = 08;
                            break;
                        case "sep":
                            mesNumero = 09;
                            break;
                        case "oct":
                            mesNumero = 10;
                            break;
                        case "nov":
                            mesNumero = 11;
                            break;
                        case "dic":
                            mesNumero = 12;
                            break;
                    }
                    yyyy = int.Parse("" + fechaf[15] + fechaf[16] + fechaf[17] + fechaf[18] + "");
                    mm = mesNumero;
                    dd = int.Parse("0" + fechaf[0]);
                    precio = decimal.Parse(list[3]);
                    socket = list[4];
                    if (int.TryParse(list[6], out nucleos))
                    {

                    }
                    else
                    {
                        nucleos = 0;
                    }
                    if (int.TryParse(list[6], out hilos))
                    {

                    }
                    else
                    {
                        hilos = 0;
                    }
                    fbase = list[7];
                    fturbo = list[8];
                    if (list[11].Contains("KB"))
                    {
                        c1 = list[9];
                        c2 = list[10];
                        c3 = list[11];
                        ram = list[12];
                        urlimg = list[13];
                    }
                    else
                    {
                        c1 = "";
                        c2 = list[9];
                        c3 = list[10];
                        ram = list[11];
                        urlimg = list[12];
                    }
                }
                if (fecha.Length == 19)
                {
                    var mes = "" + fechaf[6] + fechaf[7] + fechaf[8] + "";

                    switch (mes)
                    {
                        case "ene":
                            mesNumero = 01;
                            break;
                        case "feb":
                            mesNumero = 02;
                            break;
                        case "mar":
                            mesNumero = 03;
                            break;
                        case "abr":
                            mesNumero = 04;
                            break;
                        case "may":
                            mesNumero = 05;
                            break;
                        case "jun":
                            mesNumero = 06;
                            break;
                        case "jul":
                            mesNumero = 07;
                            break;
                        case "ago":
                            mesNumero = 08;
                            break;
                        case "sep":
                            mesNumero = 09;
                            break;
                        case "oct":
                            mesNumero = 10;
                            break;
                        case "nov":
                            mesNumero = 11;
                            break;
                        case "dic":
                            mesNumero = 12;
                            break;
                    }
                    yyyy = int.Parse("" + fechaf[15] + fechaf[16] + fechaf[17] + fechaf[18] + "");
                    mm = mesNumero;
                    dd = int.Parse("" + fechaf[0] + fechaf[1]);
                    if (list[3] != "")
                    {
                        string p1 = list[3].Replace("$", string.Empty);
                        string p2 = p1.Replace(" ", string.Empty);
                        precio = decimal.Parse(p2);
                    }
                    else
                        precio = 0;

                    socket = list[4];
                    if (int.TryParse(list[6], out nucleos))
                    {

                    }
                    else
                    {
                        nucleos = 0;
                    }
                    if (int.TryParse(list[6], out hilos))
                    {

                    }
                    else
                    {
                        hilos = 0;
                    }
                    fbase = list[7];
                    fturbo = list[8];
                    rbase = list[9];
                    multiplicador = list[10];
                    if (list[13].Contains("KB"))
                    {
                        if (list[14].Contains("KB"))
                        {
                            c1 = list[12];
                            c2 = list[13];
                            c3 = list[14];
                            ram = list[15];
                            urlimg = list[16];
                        }
                        else
                        {
                            c1 = list[11];
                            c2 = list[12];
                            c3 = list[13];
                            ram = list[14];
                            urlimg = list[15];
                        }
                    }
                    else
                    {
                        c1 = "";
                        c2 = list[10];
                        c3 = list[11];
                        ram = list[12];
                        urlimg = list[13];
                    }
                }
            }
            if (marca == "intel")
            {
                arquitectura = list[0];
                litografia = list[1];
                fecha = list[2];
                int mesNumero = 0;
                List<char> fechaf = new List<char>();
                foreach (char f in fecha)
                {
                    fechaf.Add(f);
                }
                if (fecha.Length == 18)
                {
                    var mes = "" + fechaf[5] + fechaf[6] + fechaf[7] + "";

                    switch (mes)
                    {
                        case "ene":
                            mesNumero = 01;
                            break;
                        case "feb":
                            mesNumero = 02;
                            break;
                        case "mar":
                            mesNumero = 03;
                            break;
                        case "abr":
                            mesNumero = 04;
                            break;
                        case "may":
                            mesNumero = 05;
                            break;
                        case "jun":
                            mesNumero = 06;
                            break;
                        case "jul":
                            mesNumero = 07;
                            break;
                        case "ago":
                            mesNumero = 08;
                            break;
                        case "sep":
                            mesNumero = 09;
                            break;
                        case "oct":
                            mesNumero = 10;
                            break;
                        case "nov":
                            mesNumero = 11;
                            break;
                        case "dic":
                            mesNumero = 12;
                            break;
                    }
                    yyyy = int.Parse("" + fechaf[14] + fechaf[15] + fechaf[16] + fechaf[17] + "");
                    mm = mesNumero;
                    dd = int.Parse("0" + fechaf[0]);
                    if (list[3] != "")
                    {
                        string p1 = list[3].Replace("$", string.Empty);
                        string p2 = p1.Replace(" ", string.Empty);
                        precio = decimal.Parse(p2);
                    }
                    else
                        precio = 0;
                    socket = list[4];
                }

                if (fecha.Length == 19)
                {
                    var mes = "" + fechaf[6] + fechaf[7] + fechaf[8] + "";

                    switch (mes)
                    {
                        case "ene":
                            mesNumero = 01;
                            break;
                        case "feb":
                            mesNumero = 02;
                            break;
                        case "mar":
                            mesNumero = 03;
                            break;
                        case "abr":
                            mesNumero = 04;
                            break;
                        case "may":
                            mesNumero = 05;
                            break;
                        case "jun":
                            mesNumero = 06;
                            break;
                        case "jul":
                            mesNumero = 07;
                            break;
                        case "ago":
                            mesNumero = 08;
                            break;
                        case "sep":
                            mesNumero = 09;
                            break;
                        case "oct":
                            mesNumero = 10;
                            break;
                        case "nov":
                            mesNumero = 11;
                            break;
                        case "dic":
                            mesNumero = 12;
                            break;
                    }
                    yyyy = int.Parse("" + fechaf[15] + fechaf[16] + fechaf[17] + fechaf[18] + "");
                    mm = mesNumero;
                    dd = int.Parse("" + fechaf[0] + fechaf[1]);
                    if (list[3] != "")
                    {
                        string p1 = list[3].Replace("$", string.Empty);
                        string p2 = p1.Replace(" ", string.Empty);
                        precio = decimal.Parse(p2);
                    }
                    else
                        precio = 0;
                }
                socket = list[5];
                if (int.TryParse(list[6], out nucleos))
                {

                }
                else
                {
                    nucleos = 0;
                }
                if (int.TryParse(list[6], out hilos))
                {

                }
                else
                {
                    hilos = 0;
                }
                fbase = list[7];
                fturbo = list[8];
                rbase = list[9];
                multiplicador = list[10];
                if (list[13].Contains("KB"))
                {
                    if (list[14].Contains("KB"))
                    {
                        c1 = list[12];
                        c2 = list[13];
                        c3 = list[14];
                        ram = list[15];
                        urlimg = list[16];
                    }
                    else
                    {
                        c1 = list[11];
                        c2 = list[12];
                        c3 = list[13];
                        ram = list[14];
                        urlimg = list[15];
                    }
                }
                else
                {
                    c1 = "";
                    c2 = list[11];
                    c3 = list[12];
                    ram = list[13];
                    urlimg = list[14];
                }
            }

            //foreach(var on in listaDimencional)
            //{
            //    Console.WriteLine(on);
            //}

            var product = new CPU_Z_Intel
            {
                Nombre = nombre,
                Arquitectura = arquitectura,
                cacheL1 = c1,
                cacheL2 = c2,
                cacheL3 = c3,
                precioLanzamiento = precio,
                MultiplicadorReloj = multiplicador,
                RamDDR = ram,
                FrecuenciaBase = fbase,
                FrecuenciaTurbo = fturbo,
                fechaLanzamiento = new DateTime(yyyy, mm, dd),
                imgUrl = urlimg,
                Litografia = litografia,
                Hilos = hilos,
                Nucleos = nucleos,
                RelojBase = rbase,
                Socket = socket
            };

            string json = JsonConvert.SerializeObject(product);
            return Json(json);
        }    
    }
}    