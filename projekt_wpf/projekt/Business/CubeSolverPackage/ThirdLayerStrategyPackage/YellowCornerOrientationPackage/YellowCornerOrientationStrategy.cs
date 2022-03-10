using RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCornerOrientationPackage.YellowCornerOrientationFactoryPackage;
using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage
{
    class YellowCornerOrientationStrategy : ICubeSolverStrategy
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;
        public void solve(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;

            YellowCornerOrientationFactory whiteCornerMovementFactory = new YellowCornerOrientationFactory();
            IYellowCornerOrientation yellowCornerOrientation = null;

            while (true)
            {
                int correctedCornersNumber = getCorrectedCorners();
                
                if (correctedCornersNumber == 4) break;
                
                if (correctedCornersNumber == 0)
                {
                    yellowCornerOrientation = whiteCornerMovementFactory.create(Color.BLUE, rubicCubeSides, steps);
                }

                if(correctedCornersNumber == 1)
                {
                    Color color = findCorrectCorner();
                    yellowCornerOrientation = whiteCornerMovementFactory.create(color, rubicCubeSides, steps);
                }

                yellowCornerOrientation.solve();
            }
        }

        private Color findCorrectCorner()
        {
            List<List<Color>> cubes = getCubes();

            bool yellowOrangeGreenCubeState = checkCorner(cubes[0], new List<Color>() { Color.YELLOW, Color.ORANGE, Color.GREEN });

            bool yellowGreenRedCubeState = checkCorner(cubes[1], new List<Color>() { Color.YELLOW, Color.GREEN, Color.RED });

            bool yellowOrangeBlueCubeState = checkCorner(cubes[2], new List<Color>() { Color.YELLOW, Color.ORANGE, Color.BLUE });

            bool yellowBlueRedCubeState = checkCorner(cubes[3], new List<Color>() { Color.YELLOW, Color.BLUE, Color.RED });

            if (yellowOrangeGreenCubeState) return Color.GREEN;
            if (yellowGreenRedCubeState) return Color.RED;
            if (yellowOrangeBlueCubeState) return Color.ORANGE;
            if (yellowBlueRedCubeState) return Color.BLUE;

            return Color.NONE;
        } 

        private bool checkCorner(List<Color> realColors, List<Color> cubeCentroidsCombination)
        {
            if (realColors.Count != cubeCentroidsCombination.Count) return false;

            for(int i=0; i<realColors.Count; i++)
            {
                if (!realColors.Contains(cubeCentroidsCombination[i])) return false;
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


        private int getCorrectedCorners()
        {
            List<List<Color>> cubes = getCubes();

            int yellowOrangeGreenCubeState = checkCorner(cubes[0], new List<Color>() { Color.YELLOW, Color.ORANGE, Color.GREEN }) ? 1 : 0;

            int yellowGreenRedCubeState = checkCorner(cubes[1], new List<Color>() { Color.YELLOW, Color.GREEN, Color.RED }) ? 1 : 0;

            int yellowOrangeBlueCubeState = checkCorner(cubes[2], new List<Color>() { Color.YELLOW, Color.ORANGE, Color.BLUE }) ? 1 : 0;

            int yellowBlueRedCubeState = checkCorner(cubes[3], new List<Color>() { Color.YELLOW, Color.BLUE, Color.RED }) ? 1 : 0;

            return yellowOrangeGreenCubeState + yellowGreenRedCubeState + yellowOrangeBlueCubeState + yellowBlueRedCubeState;
        }
    }
}
