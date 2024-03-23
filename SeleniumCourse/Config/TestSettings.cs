using SeleniumCourse.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCourse.Config
{
    public class TestSettings
    {
        public BrowserType browserType { get; set; }
        public Uri applicationURL { get; set; }
        public float? timeoutInterval { get; set; }
    }
}
