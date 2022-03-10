using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlaceOneTakenForWhiteCrossBottomSideWallLayerPackage
{
    class OnePlaceTakenCrossBottomBlueSide : OnePlaceTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private Color centroidColor;
        private List<Step> steps;
        public OnePlaceTakenCrossBottomBlueSide(Dictionary<Color, Side> rubicCubeSides, ref Color mainSideColor, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.centroidColor = mainSideColor;
            this.steps = steps;
        }

        public override Color create()
        {
            rotateLastLayerRelativeCentroidAndYellowNaighbourSquare(rubicCubeSides, ref centroidColor, steps);
            if (centroidColor == Color.BLUE)
            {
                Movement movement = new Movement(MovementType.B_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.U_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.L, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.U, rubicCubeSides, steps);
                
            }
            return centroidColor;
        }
    }
}