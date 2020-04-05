using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Core.Configuration
{
    public class AppSettings
    {
        public string Secret { get; set; } = "This is the secret key and its very important";
    }
}
