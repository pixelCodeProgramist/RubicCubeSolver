using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlacesTwoTakenForWhiteCrossBottomSideWallLayerPackage
{
    internal class TwoPlacesTakenCrossBottomBlueSide : TwoPlacesTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private bool isStraightLine;
        private Color centroidColorOfWhiteSquare;
        private List<Step> steps;
        public TwoPlacesTakenCrossBottomBlueSide(Dictionary<Color, Side> rubicCubeSides, Color mainSideColor, bool isStraightLine, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.isStraightLine = isStraightLine;
            this.centroidColorOfWhiteSquare = mainSideColor;
            this.steps = steps;
        }

        public override void create()
        {
            Color colorOnYellowSide = getColorFromYellowSide(centroidColorOfWhiteSquare, rubicCubeSides);

            Movement movement = new Movement(MovementType.B_PRIM, rubicCubeSides, steps);
            
            comleteSettingSquare(colorOnYellowSide, centroidColorOfWhiteSquare, rubicCubeSides, isStraightLine, steps);
        }
    }
}