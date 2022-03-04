using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlacesTwoTakenForWhiteCrossBottomSideWallLayerPackage
{
    internal class TwoPlacesTakenCrossBottomOrangeSide : TwoPlacesTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private bool isStraightLine;
        private Color centroidColorOfWhiteSquare;
        private List<Step> steps;
        public TwoPlacesTakenCrossBottomOrangeSide(Dictionary<Color, Side> rubicCubeSides, Color mainSideColor, bool isStraightLine, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.isStraightLine = isStraightLine;
            this.centroidColorOfWhiteSquare = mainSideColor;
            this.steps = steps;
        }

        public override void create()
        {
            setTwoInOneLineWhiteSquare(this.centroidColorOfWhiteSquare);
        }

        private void setTwoInOneLineWhiteSquare(Color centroidColorOfWhiteSquare)
        {
            Color colorOnYellowSide = getColorFromYellowSide(centroidColorOfWhiteSquare, rubicCubeSides);

            Movement movement = new Movement(MovementType.L_PRIM, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            comleteSettingSquare(colorOnYellowSide, centroidColorOfWhiteSquare, rubicCubeSides, isStraightLine, steps);
        }
    }
}