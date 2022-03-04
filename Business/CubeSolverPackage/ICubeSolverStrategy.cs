using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage
{
    interface ICubeSolverStrategy
    {
        public void solve(Dictionary<Color, Side> rubicCubeSides, List<Step> steps);
    }
}
