using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossMiddleSquarePackage.YellowCrossMiddleSquareFactoryPackage
{
    abstract class YellowCrossMiddleSquareFactory
    {
        public abstract IYellowCrossMiddleSquareFactory getAlgorithm(Color colorType, Dictionary<Color, Side> rubicCubeSides, List<Step> steps);
    }
}
