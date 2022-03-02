using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.SecondLayerStrategyPackage.SecondLayerFactoryPackage
{
    class RightFactory : SecondLayerFactory
    {
        public override ISecondLayerForFactory getAlgorithm(Color colorType, Dictionary<Color, Side> rubicCubeSides)
        {
            ISecondLayerForFactory secondLayerForFactory = null;
            switch(colorType)
            {
                case Color.GREEN:
                    secondLayerForFactory = new GreenSideSecondLayerRight(rubicCubeSides);
                    break;
                case Color.ORANGE:
                    secondLayerForFactory = new OrangeSideSecondLayerRight(rubicCubeSides);
                    break;
                case Color.RED:
                    secondLayerForFactory = new RedSideSecondLayerRight(rubicCubeSides);
                    break;
                case Color.BLUE:
                    secondLayerForFactory = new BlueSideSecondLayerRight(rubicCubeSides);
                    break;
                default:
                    break;
            }

            return secondLayerForFactory;
        }
        
    }
}
