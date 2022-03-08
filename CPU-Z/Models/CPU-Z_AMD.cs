using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPU_Z.Models
{
    public class CPU_Z_AMD
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Litografia { get; set; }
        public string Arquitectura { get; set; }
        [Display(Name = "Lanzamiento")]
        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaLanzamiento { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        [Display(Name = "Precio")]
        public decimal precioLanzamiento { get; set; }
        public string Socket { get; set; }
        [Required]
        public int Nucleos { get; set; }
        public int Hilos { get; set; }
        [Required]
        [Display(Name = "Frecuencia")]
        public string FrecuenciaBase { get; set; }
        [Display(Name = "Frecuencia Turbo")]
        public string FrecuenciaTurbo { get; set; }
        [Display(Name = "Cache L1")]
        public string cacheL1 { get; set; }
        [Display(Name = "Cache L2")]
        public string cacheL2 { get; set; }
        [Display(Name = "Cache L3")]
        public string cacheL3 { get; set; }
        [Required]
        [Display(Name = "RAM")]
        public string RamDDR { get; set; }
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen URL")]
        public string imgUrl { get; set; }
        
    }
}
