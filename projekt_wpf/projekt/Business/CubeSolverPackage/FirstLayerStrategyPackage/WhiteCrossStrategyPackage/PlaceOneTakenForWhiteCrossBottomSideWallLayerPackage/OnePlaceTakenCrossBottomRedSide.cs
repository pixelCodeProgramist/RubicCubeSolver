using RubicCube.Models;
using System;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlaceOneTakenForWhiteCrossBottomSideWallLayerPackage
{
    class OnePlaceTakenCrossBottomRedSide : OnePlaceTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;

        private Color centroidColor;

        private List<Step> steps;
        public OnePlaceTakenCrossBottomRedSide(Dictionary<Color, Side> rubicCubeSides,ref Color mainSideColor, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.centroidColor = mainSideColor;
            this.steps = steps;
        }

        public override Color create()
        {
            rotateLastLayerRelativeCentroidAndYellowNaighbourSquare(rubicCubeSides, ref centroidColor, steps);
            if(centroidColor == Color.RED)
            {
                Movement movement = new Movement(MovementType.R_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.U_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.B, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.U, rubicCubeSides, steps);
                
            }

            return centroidColor;
            

        }
    }
}