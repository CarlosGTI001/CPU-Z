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


namespace CPU_Z.Controllers
{
    public class api : Controller
    {
        public string request(string nombre, string marca){
            string da = "";
            int contador = 0;
            List<string> lista =  obtenerDetalles.WebDataScrap(nombre, marca);
            foreach(string dt in lista){
                da += dt;
                if(contador < lista.Count-1)
                da += ",";
                contador++;
            }
            return da;
        }    
    }
}    