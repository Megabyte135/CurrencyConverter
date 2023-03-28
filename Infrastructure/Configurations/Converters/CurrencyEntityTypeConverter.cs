using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Domain.Models;

namespace Infrastructure.Configurations.Converters
{
    public class CurrencyEntityTypeConverter : ValueConverter<Currency, string>
    {
        public CurrencyEntityTypeConverter()
            : base(
                  u => u.FullName,
                  u => new Currency()
                  )
        {
           
        }
    }
}
