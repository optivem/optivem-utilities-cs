﻿
using Optivem.Template.UI.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.UI.Services
{
    // TODO: VC: Consider moving into framework

    public class BaseService
    {
        public BaseService(Client client)
        {
            Client = client;
        }

        public Client Client { get; }
    }
}
