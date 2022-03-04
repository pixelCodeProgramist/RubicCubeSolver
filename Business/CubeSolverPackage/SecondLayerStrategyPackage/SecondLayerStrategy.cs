using RubicCube.Business.CubeSolverPackage.SecondLayerStrategyPackage.SecondLayerFactoryPackage;
using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static RubicCube.Business.CubeSolverPackage.SecondLayerStrategyPackage.SecondLayerFactoryPackage.SecondLayerFactoryProvider;

namespace RubicCube.Business.CubeSolverPackage.SecondLayerStrategyPackage
{
    class SecondLayerStrategy : ICubeSolverStrategy
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private SecondLayerFactory abstractFactory;
        private List<Step> steps;
        private List<Color> order = new List<Color>() { Color.ORANGE, Color.GREEN, Color.RED, Color.BLUE };
        public void solve(Dictionary<Color, Side> rubicCubeSides, List<Step> steps) 
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
            this.removeWrongCubes();
            this.setCubesInCorrectPosition();
        }

        private void setCubeInCorrectPosition(Color currentCentroidColor, Color futureCentroidColor)
        {
            if(futureCentroidColor!=Color.YELLOW && futureCentroidColor != Color.WHITE && futureCentroidColor != Color.NONE)
            {
                int currentSideIndex = order.FindIndex(color => color == currentCentroidColor);
                int futureSideIndex = order.FindIndex(color => color == futureCentroidColor);
                int movements = futureSideIndex - currentSideIndex;
                if (movements == -3) movements = 1;
                if (movements == 3) movements = -1;

                for (int i = 0; i < Math.Abs(movements); i++)
                {
                    if (movements < 0)
                    {
                        Movement movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
                        steps.Add(new Step(movement, rubicCubeSides));
                    }
                    else
                    {
                        Movement movement = new Movement(MovementType.D, rubicCubeSides);
                        steps.Add(new Step(movement, rubicCubeSides));
                    }
                }

                Color yellowSideSquareColor = getColorFromYellowSide(futureCentroidColor);

                int indexOfYellowSideSquareColor = order.FindIndex(color => color == yellowSideSquareColor);
                int position = indexOfYellowSideSquareColor - futureSideIndex;
                if (position == -3) position = 1;
                if (position == 3) position = -1;

                if (position < 0) abstractFactory = SecondLayerFactoryProvider.getFactory(SecondLayerFactoryMode.Right);
                if (position > 0) abstractFactory = SecondLayerFactoryProvider.getFactory(SecondLayerFactoryMode.Left);



                if (position != 0) abstractFactory.getAlgorithm(futureCentroidColor, rubicCubeSides, steps).solve();
            }
        }

        private Color getColorFromYellowSide(Color centroidColor)
        {
            
            if (centroidColor == Color.ORANGE) return rubicCubeSides[Color.YELLOW].fields[1][0];
            if (centroidColor == Color.GREEN) return rubicCubeSides[Color.YELLOW].fields[0][1];
            if (centroidColor == Color.RED) return rubicCubeSides[Color.YELLOW].fields[1][2];
            if (centroidColor == Color.BLUE) return rubicCubeSides[Color.YELLOW].fields[2][1];

            return Color.NONE;
        }

        private void setCubesInCorrectPosition()
        {
            while(true)
            {
                bool allMiddleCubesState = checkAllMiddleCubes();
                if (allMiddleCubesState) break;
                Color orangeSideSquareColor = rubicCubeSides[Color.ORANGE].fields[2][1];
                setCubeInCorrectPosition(Color.ORANGE, orangeSideSquareColor);
                Color greenSideSquareColor = rubicCubeSides[Color.GREEN].fields[2][1];
                setCubeInCorrectPosition(Color.GREEN, greenSideSquareColor);
                Color redSideSquareColor = rubicCubeSides[Color.RED].fields[2][1];
                setCubeInCorrectPosition(Color.RED, redSideSquareColor);
                Color blueSideSquareColor = rubicCubeSides[Color.BLUE].fields[2][1];
                setCubeInCorrectPosition(Color.BLUE, blueSideSquareColor);
            }
           
        }

        private bool checkAllMiddleCubes()
        {
            bool orangeGreenCubeState = rubicCubeSides[Color.ORANGE].fields[1][2] == Color.ORANGE && rubicCubeSides[Color.GREEN].fields[1][0] == Color.GREEN;
            bool greenRedCubeState = rubicCubeSides[Color.GREEN].fields[1][2] == Color.GREEN && rubicCubeSides[Color.RED].fields[1][0] == Color.RED;
            bool redBlueCubeState = rubicCubeSides[Color.RED].fields[1][2] == Color.RED && rubicCubeSides[Color.BLUE].fields[1][0] == Color.BLUE;
            bool blueOrangeCubeState = rubicCubeSides[Color.BLUE].fields[1][2] == Color.BLUE && rubicCubeSides[Color.ORANGE].fields[1][0] == Color.ORANGE;
            return orangeGreenCubeState && greenRedCubeState && redBlueCubeState && blueOrangeCubeState;
        }
        private void removeWrongCube(Color mainColor, Color nextMainColor, int rowOnYellowSide, int columnOnYellowSide)
        {
            if (isWrongCube(mainColor, nextMainColor))
            {
                while (true)
                {
                    if (isYellowColorInMember(mainColor, rowOnYellowSide, columnOnYellowSide)) break;
                    Movement movement = new Movement(MovementType.D, rubicCubeSides);
                    steps.Add(new Step(movement, rubicCubeSides));
                }

                abstractFactory = SecondLayerFactoryProvider.getFactory(SecondLayerFactoryMode.Left);
                abstractFactory.getAlgorithm(mainColor, rubicCubeSides, steps).solve();
            }
        }

        private void removeWrongCubes()
        {
            removeWrongCube(Color.ORANGE, Color.GREEN, 1, 0);
            removeWrongCube(Color.GREEN, Color.RED, 0, 1);
            removeWrongCube(Color.RED, Color.BLUE, 1, 2);
            removeWrongCube(Color.BLUE, Color.ORANGE, 2, 1);
        }

        private bool isYellowColorInMember(Color mainSideColor, int i, int j)
        {

            Color color1 = rubicCubeSides[mainSideColor].fields[2][1];
            Color color2 = rubicCubeSides[Color.YELLOW].fields[i][j];
            if (color1 == Color.YELLOW || color2 == Color.YELLOW) return true;
            return false;
        }

        private bool isWrongCube(Color mainColor, Color mainColorNext)
        {
            Color color1 = rubicCubeSides[mainColor].fields[1][2];
            Color color2 = rubicCubeSides[mainColorNext].fields[1][0];
            if (color1 == mainColor && color2 == mainColorNext) return false;
            else if (color1 == Color.YELLOW || color2 == Color.YELLOW) return false;
            return true;
        }
    }
}
