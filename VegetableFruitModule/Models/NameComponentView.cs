using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegetableFruitModule.Models
{
    public class NameComponentView
    {
        public static string Create { get; set; } = "Create";
        public static string Index { get; set; } = "Index";
        public static string CategoryCreate { get; set; } = $"Category{Create}";
        public static string CategoryIndex { get; set; } = $"Category{Index}";
        public static string VegetableFruitCreate { get; set; } = $"VegetableFruit{Create}";
        public static string VegetableFruitIndex { get; set; } = $"VegetableFruit{Index}";
    }
}
