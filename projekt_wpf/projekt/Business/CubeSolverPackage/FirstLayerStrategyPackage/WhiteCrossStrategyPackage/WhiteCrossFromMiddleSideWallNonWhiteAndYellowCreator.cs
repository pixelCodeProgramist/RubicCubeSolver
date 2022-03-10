using RubicCube.Business.CubeSolverPackage.FirstLayerStrategyPackage.WhiteCrossStrategyPackage.WhiteCrossFromMiddleSideWallNonWhiteAndYellowPackage;
using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage
{
    class WhiteCrossFromMiddleSideWallNonWhiteAndYellowCreator
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;

        public WhiteCrossFromMiddleSideWallNonWhiteAndYellowCreator(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
            this.moveToThirdLayer();
        }

        private void moveToThirdLayer()
        {
            WhiteCrossFromMiddleSideWallNonWhiteAndYellowFactory factory = new WhiteCrossFromMiddleSideWallNonWhiteAndYellowFactory();
            IWhiteCrossFromMiddleSideWallNonWhiteAndYellow whiteCrossFromMiddleSideWallNonWhiteAndYellowImpl = null;
            while(true)
            {
                Color color = getCentroidColorWithWhiteSquareOnMiddle();
                if (color == Color.NONE) break;
                whiteCrossFromMiddleSideWallNonWhiteAndYellowImpl = factory.create(color, rubicCubeSides, steps);
                whiteCrossFromMiddleSideWallNonWhiteAndYellowImpl.move();
            }
        }

        private Color getCentroidColorWithWhiteSquareOnMiddle()
        {
            Color orangeGreenCubeOrangeSide = rubicCubeSides[Color.ORANGE].fields[1][2];
            Color orangeGreenCubeGreenSide = rubicCubeSides[Color.GREEN].fields[1][0];

            Color greenRedCubeGreenSide = rubicCubeSides[Color.GREEN].fields[1][2];
            Color greenRedCubeRedSide = rubicCubeSides[Color.RED].fields[1][0];

            Color redBlueCubeRedSide = rubicCubeSides[Color.RED].fields[1][2];
            Color redBlueCubeBlueSide = rubicCubeSides[Color.BLUE].fields[1][0];

            Color blueOrangeCubeRedSide = rubicCubeSides[Color.BLUE].fields[1][2];
            Color blueOrangeCubeBlueSide = rubicCubeSides[Color.ORANGE].fields[1][0];

            bool orangeGreenState = isWhiteSquare(orangeGreenCubeOrangeSide, orangeGreenCubeGreenSide);
            bool greenRedState = isWhiteSquare(greenRedCubeGreenSide, greenRedCubeRedSide);
            bool redBlueState = isWhiteSquare(redBlueCubeRedSide, redBlueCubeBlueSide);
            bool blueOrangeState = isWhiteSquare(blueOrangeCubeRedSide, blueOrangeCubeBlueSide);

            if (orangeGreenState) return Color.ORANGE;
            if (greenRedState) return Color.GREEN;
            if (redBlueState) return Color.RED;
            if (blueOrangeState) return Color.BLUE;

            return Color.NONE;
        }

        private bool isWhiteSquare(Color color1, Color color2)
        {
            return color1 == Color.WHITE || color2 == Color.WHITE;
        }

    }
}