using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlacesTwoTakenForWhiteCrossBottomSideWallLayerPackage
{
    internal class TwoPlacesTakenCrossBottomRedSide : TwoPlacesTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private bool isStraightLine;
        private Color centroidColorOfWhiteSquare;
        private List<Step> steps;
        public TwoPlacesTakenCrossBottomRedSide(Dictionary<Color, Side> rubicCubeSides, Color mainSideColor, bool isStraightLine, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.isStraightLine = isStraightLine;
            this.centroidColorOfWhiteSquare = mainSideColor;
            this.steps = steps;
        }

        public override void create()
        {
           setSquares(this.centroidColorOfWhiteSquare);
        }

        private void setSquares(Color centroidColorOfWhiteSquare)
        {
            Color colorOnYellowSide = getColorFromYellowSide(centroidColorOfWhiteSquare, rubicCubeSides);

            Movement movement = new Movement(MovementType.R_PRIM, rubicCubeSides, steps);
            
            comleteSettingSquare(colorOnYellowSide, centroidColorOfWhiteSquare, rubicCubeSides, isStraightLine, steps);

        }
    }
}