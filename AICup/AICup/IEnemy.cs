﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICup
{
    public interface IEnemy 
    {
        void GetInputData(InputData inputData);
        Action CreateAction();
    }
}