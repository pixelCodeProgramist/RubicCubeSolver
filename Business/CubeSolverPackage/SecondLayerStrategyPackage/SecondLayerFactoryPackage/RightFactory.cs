using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.SecondLayerStrategyPackage.SecondLayerFactoryPackage
{
    class RightFactory : SecondLayerFactory
    {
        public override ISecondLayerForFactory getAlgorithm(Color colorType, Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            ISecondLayerForFactory secondLayerForFactory = null;
            switch(colorType)
            {
                case Color.GREEN:
                    secondLayerForFactory = new GreenSideSecondLayerRight(rubicCubeSides, steps);
                    break;
                case Color.ORANGE:
                    secondLayerForFactory = new OrangeSideSecondLayerRight(rubicCubeSides, steps);
                    break;
                case Color.RED:
                    secondLayerForFactory = new RedSideSecondLayerRight(rubicCubeSides, steps);
                    break;
                case Color.BLUE:
                    secondLayerForFactory = new BlueSideSecondLayerRight(rubicCubeSides, steps);
                    break;
                default:
                    break;
            }

            return secondLayerForFactory;
        }
        
    }
}
