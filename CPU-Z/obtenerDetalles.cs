using System;
using System.Net;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CPU_Z
{
    public class obtenerDetalles
    {
        public static List<string> WebDataScrap(string procesador, string marca)
        {
            //pi__image es la clase de la imagen
            var list = new List<string>();
            try
            {
                string url = "https://www.geektopia.es/es/";
                //Get the content of the URL from the Web
                if (marca == "amd")
                {
                    //15 campos
                    url = $"https://www.geektopia.es/es/product/amd/{procesador.Replace(' ', '-')}/";
                }
                if (marca == "intel")
                {
                    //17 campos
                    url = $"https://www.geektopia.es/es/product/intel/{procesador.Replace(' ', '-')}/";
                }

                var web = new HtmlWeb();
                var doc = web.Load(url);


                //Filter the content
                doc.DocumentNode.Descendants()
                                .Where(n => n.Name == "script")
                                .ToList()
                                .ForEach(n => n.Remove());

                const string classValue = "tcms__td";
                var nodes = doc.DocumentNode.SelectNodes($"//*[@class='{classValue}']") ?? Enumerable.Empty<HtmlNode>();
                var result = "";

                //Write the desired content to a file
                using (var file = new StreamWriter("test.txt"))
                {
                    int contador = 0;
                    foreach (var node in nodes)
                    {
                        if (contador < 17)
                        {
                            //Get the country name
                            var splittedWords = Regex.Split(node.InnerText, "\n");
                            var words = splittedWords
                               .Where(x => !x.Contains("&nbsp;") && !string.IsNullOrEmpty(x.Trim()))
                               .ToList();

                            //if (words.Count() != 4) continue;
                            //Descripcion
                            var countryName = words[0].Trim();
                            //var countryCode = words[2].Trim();
                            if (contador == 3)
                            {
                                var resultado = false;
                                foreach (var comp in countryName)
                                {

                                    if (comp == '$')
                                    {
                                        resultado = true;
                                        goto saliendo;
                                    }
                                    else
                                    {
                                        resultado = false;

                                    }
                                }
                            saliendo:
                                if (resultado == false)
                                {
                                    list.Add("");
                                }
                            }
                            if (contador == 5 && marca == "intel")
                            {
                                int numero;
                                if (!int.TryParse(countryName, out numero))
                                {
                                    list.Add("");
                                }
                            }
                            //if (contador == 7 && marca == "amd")
                            //{
                            //    int numero;
                            //    if (!int.TryParse(countryName, out numero))
                            //    {
                            //        list.Add("");
                            //    }
                            //}
                            if (countryName.Contains("PCIe"))
                            {
                                goto saltar;
                            }
                            list.Add(countryName);
                        saltar:
                            if (countryName.Contains("DDR"))
                            {
                                goto salir;
                            }

                            contador++;
                        }
                        else
                        {
                            goto stop;
                        }
                    }
                }
            stop:
                var nodesImg = doc.DocumentNode.SelectNodes($"//img[@class='pi__image']") ?? Enumerable.Empty<HtmlNode>();

                //Write the desired content to a file
                using (var file = new StreamWriter("test.txt"))
                {
                    try
                    {
                        int contador = 0;
                        foreach (HtmlNode node in nodesImg)
                        {
                            if (contador < 2)
                            {
                                var img = node.Attributes.ToArray();
                                result = $"{img[2].Value}";
                                file.WriteLine(result);
                                contador++;
                                list.Add(result);
                                list.Add(procesador.ToUpper());
                            }
                            else
                            {
                                goto salir;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return list;
                    }
                }
            salir:
                if (result == "")
                {
                    goto stop;
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured:\r\n{ex.Message}");
                return list;
            }
        }
    }
}