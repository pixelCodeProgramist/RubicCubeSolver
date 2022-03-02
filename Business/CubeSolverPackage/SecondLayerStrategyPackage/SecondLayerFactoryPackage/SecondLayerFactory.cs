using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.SecondLayerStrategyPackage.SecondLayerFactoryPackage
{
    abstract class SecondLayerFactory
    {
        public abstract ISecondLayerForFactory getAlgorithm(Color colorType, Dictionary<Color, Side> rubicCubeSides);
    }

}
