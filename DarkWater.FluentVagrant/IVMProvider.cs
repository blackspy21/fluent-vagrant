﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkWater.FluentVagrant
{
  public interface IVMProvider
  {
    bool? ShowGUI { get; }
    int Memory { get; }
    int NumberOfCPUs { get; }
  }
}
