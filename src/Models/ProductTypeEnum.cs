using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsGoPark.WebSite.Models
{
    /// <summary>
    /// enum for Product/Game Category
    /// </summary>
    public enum ProductTypeEnum
    {
        Statepark = 0,
        Nationalpark = 1,
        Localpark = 2,
        others=3,
    }

    /// <summary>
    /// Representing class enum for product/game category
    /// Grouping products/games together by category
    /// </summary>
    public static class ProductTypeEnumExtensions
    {
        /// <summary>
        /// enum value is displayed as a string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DisplayName(this ProductTypeEnum data)
        {
            return data switch
            {
                ProductTypeEnum.Statepark => "Statepark",
                ProductTypeEnum.Nationalpark => "Nationalpark",
                ProductTypeEnum.Localpark => "Localpark",
                ProductTypeEnum.others => "others",
                _ => throw new NotImplementedException(),
            };
        }
    }
}