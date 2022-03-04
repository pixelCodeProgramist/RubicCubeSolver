using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.SecondLayerStrategyPackage.SecondLayerFactoryPackage
{
    class LeftFactory : SecondLayerFactory
    {
        public override ISecondLayerForFactory getAlgorithm(Color colorType, Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            ISecondLayerForFactory secondLayerForFactory = null;
            switch(colorType)
            {
                case Color.GREEN:
                    secondLayerForFactory = new GreenSideSecondLayerLeft(rubicCubeSides, steps);
                    break;
                case Color.ORANGE:
                    secondLayerForFactory = new OrangeSideSecondLayerLeft(rubicCubeSides, steps);
                    break;
                case Color.RED:
                    secondLayerForFactory = new RedSideSecondLayerLeft(rubicCubeSides, steps);
                    break;
                case Color.BLUE:
                    secondLayerForFactory = new BlueSideSecondLayerLeft(rubicCubeSides, steps);
                    break;
                default:
                    break;
            }

            return secondLayerForFactory;
        }
        
    }
}
