﻿using Sokoban.Facade;
using Sokoban.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Program
    {
        static void Main(string[] args)
        {
            IBootstrapFacade bootstrap = new BootstrapFacade();
            bootstrap.LoadApplication();
        }
    }
}
