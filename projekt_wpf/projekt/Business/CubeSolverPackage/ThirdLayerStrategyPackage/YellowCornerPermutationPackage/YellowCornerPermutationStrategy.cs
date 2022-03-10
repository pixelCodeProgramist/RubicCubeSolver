using RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCornerPermutationPackage.YellowCornerPermutationFactoryPackage;
using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCornerPermutationPackage
{
    class YellowCornerPermutationStrategy : ICubeSolverStrategy
    {
        private Dictionary<Color, Side> rubicCubeSides;

        private List<Step> steps;

        private List<Color> order = new List<Color>() { Color.ORANGE, Color.BLUE, Color.RED, Color.GREEN };
        public void solve(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;

            Color color = findCorrectCorner();
            if(color != Color.NONE)
            {
                YellowCornerPermutationFactory yellowCornerPermutationFactory = new YellowCornerPermutationFactory();
                IYellowCornerPermutation yellowCornerPermutationImpl = 
                    yellowCornerPermutationImpl = yellowCornerPermutationFactory.create(color, rubicCubeSides, steps);
                yellowCornerPermutationImpl.solve();
                Movement movement = new Movement(MovementType.D, rubicCubeSides, steps);
                
                yellowCornerPermutationImpl.solve();
                movement = new Movement(MovementType.D, rubicCubeSides, steps);
                
                int currentIndex = order.FindIndex(col => col == color);
                int nextIndex = (currentIndex + 2) % 4;
                if(checkRow(order[nextIndex]))
                {
                    movement = new Movement(MovementType.D, rubicCubeSides, steps);
                    
                } else
                {
                    yellowCornerPermutationImpl.solve();
                }

                movement = new Movement(MovementType.D, rubicCubeSides, steps);
                
                nextIndex = (currentIndex + 1) % 4;
                if (checkRow(order[nextIndex]))
                {
                    movement = new Movement(MovementType.D, rubicCubeSides, steps);
                    
                }
                else
                {
                    yellowCornerPermutationImpl.solve();
                }

                Color thirdLayerBottomColor = rubicCubeSides[order[currentIndex]].fields[2][1];
                int futureIndex = order.FindIndex(col => col == thirdLayerBottomColor);
                int movements = futureIndex - currentIndex;
                if (movements == 3) movements = -1;
                if (movements == -3) movements = 1;
                for(int i=0; i< Math.Abs(movements); i++)
                {
                    if (movements > 0)
                    {
                        movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
                        
                    }
                    if (movements < 0)
                    {
                        movement = new Movement(MovementType.D, rubicCubeSides, steps);
                        
                    }
                }
            }
        }

        private bool checkRow(Color centroidColor)
        {
            return rubicCubeSides[centroidColor].fields[2][0] == centroidColor;
        }

        private bool isCubeLastNotCorrect(bool prevState, bool currState)
        {
            if (prevState && !currState) return true;
            return false;
        }

        private Color findCorrectCorner()
        {
            List<List<Color>> cubes = getCubes();

            bool yellowOrangeGreenCubeState = checkCorner(cubes[0], new List<Color>() { Color.YELLOW, Color.ORANGE, Color.GREEN });

            bool yellowGreenRedCubeState = checkCorner(cubes[1], new List<Color>() { Color.YELLOW, Color.GREEN, Color.RED });

            bool yellowOrangeBlueCubeState = checkCorner(cubes[2], new List<Color>() { Color.YELLOW, Color.ORANGE, Color.BLUE });

            bool yellowBlueRedCubeState = checkCorner(cubes[3], new List<Color>() { Color.YELLOW, Color.BLUE, Color.RED });

            if (!yellowOrangeGreenCubeState && !yellowGreenRedCubeState && !yellowOrangeBlueCubeState && !yellowBlueRedCubeState) return Color.GREEN;
            
            if(isCubeLastNotCorrect(yellowGreenRedCubeState, yellowOrangeGreenCubeState)) return Color.GREEN;
            if(isCubeLastNotCorrect(yellowOrangeGreenCubeState, yellowOrangeBlueCubeState)) return Color.ORANGE;
            if(isCubeLastNotCorrect(yellowOrangeBlueCubeState, yellowBlueRedCubeState)) return Color.BLUE;
            if(isCubeLastNotCorrect(yellowBlueRedCubeState, yellowGreenRedCubeState)) return Color.RED;

            return Color.NONE;
        }

        

        private bool checkCorner(List<Color> realColors, List<Color> cubeCentroidsCombination)
        {
            if (realColors.Count != cubeCentroidsCombination.Count) return false;

            for (int i = 0; i < realColors.Count; i++)
            {
                if (realColors[i] != cubeCentroidsCombination[i]) return false;
            }

            return true;
        }

        private List<List<Color>> getCubes()
        {

            Color yellowOrangeGreenCubeYellowSide = rubicCubeSides[Color.YELLOW].fields[0][0];
            Color yellowOrangeGreenCubeOrangeSide = rubicCubeSides[Color.ORANGE].fields[2][2];
            Color yellowOrangeGreenCubeGreenSide = rubicCubeSides[Color.GREEN].fields[2][0];

            Color yellowGreenRedCubeYellowSide = rubicCubeSides[Color.YELLOW].fields[0][2];
            Color yellowGreenRedCubeGreenSide = rubicCubeSides[Color.GREEN].fields[2][2];
            Color yellowGreenRedCubeRedSide = rubicCubeSides[Color.RED].fields[2][0];

            Color yellowOrangeBlueCubeYellowSide = rubicCubeSides[Color.YELLOW].fields[2][0];
            Color yellowOrangeBlueCubeOrangeSide = rubicCubeSides[Color.ORANGE].fields[2][0];
            Color yellowOrangeBlueCubeBlueSide = rubicCubeSides[Color.BLUE].fields[2][2];

            Color yellowBlueRedCubeYellowSide = rubicCubeSides[Color.YELLOW].fields[2][2];
            Color yellowBlueRedCubeBlueSide = rubicCubeSides[Color.BLUE].fields[2][0];
            Color yellowBlueRedCubeRedSide = rubicCubeSides[Color.RED].fields[2][2];

            List<Color> yellowOrangeGreenCube = new List<Color>() {
                yellowOrangeGreenCubeYellowSide, yellowOrangeGreenCubeOrangeSide, yellowOrangeGreenCubeGreenSide
            };

            List<Color> yellowGreenRedCube = new List<Color>
            {
                yellowGreenRedCubeYellowSide, yellowGreenRedCubeGreenSide, yellowGreenRedCubeRedSide
            };

            List<Color> yellowOrangeBlueCube = new List<Color>
            {
                yellowOrangeBlueCubeYellowSide, yellowOrangeBlueCubeOrangeSide, yellowOrangeBlueCubeBlueSide
            };

            List<Color> yellowBlueRedCube = new List<Color>
            {
                yellowBlueRedCubeYellowSide, yellowBlueRedCubeBlueSide, yellowBlueRedCubeRedSide
            };


            return new List<List<Color>>() { yellowOrangeGreenCube, yellowGreenRedCube, yellowOrangeBlueCube, yellowBlueRedCube };
        }
    }
}
