﻿using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Framework.Test.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public class SauceDemoFixture : IDisposable
    {
        public SauceDemoFixture()
        {
            Client = new ChromeDriverTestClient();
            Driver = Client.Driver;
            App = new SauceDemoApp(Driver);
        }

        public ChromeDriverTestClient Client { get; }

        public Driver Driver { get; }

        public SauceDemoApp App { get; }

        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}