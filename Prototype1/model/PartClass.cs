using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype1.model
{
    public partial class Material
    {

        public string Color
        {
            get
            {
                if(MaterialStorageAmount < MaterialMinStorageAmount)
                {
                    return "#f19292";
                } else if(MaterialStorageAmount > MaterialMinStorageAmount * 3)
                {
                    return "#ffba01";
                }
                else
                {
                    return "White";
                }
            }
        }

        public string Supplier
        {
            get
            {
                string result = String.Empty;
                foreach(var x in MaterialSupplier)
                {
                    if (result != String.Empty)
                    {
                        result += ", ";
                    }

                    result += x.Supplier.SupplierName;
                }
                if(result == String.Empty)
                {
                    result = "Поставщиков нет";
                }
                return result;
            }
        }
    }
}
