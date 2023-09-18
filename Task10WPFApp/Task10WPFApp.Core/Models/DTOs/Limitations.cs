using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10WPFApp.Core.Models.DTOs
{
    public static class Limitations
    {
        public static readonly string NameOrSurname = @"^[A-Z][a-z'-]+$";
        public static readonly string GroupFullName = @"^[A-Z]{2}-\d{2}.?";
        public static readonly string GroupShortName = @"^\d{2}.?";
    }
}
