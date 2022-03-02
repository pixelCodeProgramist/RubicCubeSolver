using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.SecondLayerStrategyPackage.SecondLayerFactoryPackage
{
    class LeftFactory : SecondLayerFactory
    {
        public override ISecondLayerForFactory getAlgorithm(Color colorType, Dictionary<Color, Side> rubicCubeSides)
        {
            ISecondLayerForFactory secondLayerForFactory = null;
            switch(colorType)
            {
                case Color.GREEN:
                    secondLayerForFactory = new GreenSideSecondLayerLeft(rubicCubeSides);
                    break;
                case Color.ORANGE:
                    secondLayerForFactory = new OrangeSideSecondLayerLeft(rubicCubeSides);
                    break;
                case Color.RED:
                    secondLayerForFactory = new RedSideSecondLayerLeft(rubicCubeSides);
                    break;
                case Color.BLUE:
                    secondLayerForFactory = new BlueSideSecondLayerLeft(rubicCubeSides);
                    break;
                default:
                    break;
            }

            return secondLayerForFactory;
        }
        
    }
}
