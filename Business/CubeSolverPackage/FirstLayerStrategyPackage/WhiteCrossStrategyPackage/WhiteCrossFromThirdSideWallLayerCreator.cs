﻿using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage
{
    class WhiteCrossFromThirdSideWallLayerCreator
    {
        Dictionary<Color, Side> rubicCubeSides;
        List<Step> steps;
        public WhiteCrossFromThirdSideWallLayerCreator(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
            this.create();
        }

        private void create()
        {
            bool isWhiteOnBlueSide = isWhiteInNeighbourWall(Color.BLUE);
            bool isWhiteOnOrangeSide = isWhiteInNeighbourWall(Color.ORANGE);
            bool isWhiteOnRedSide = isWhiteInNeighbourWall(Color.RED);
            bool isWhiteOnGreenSide = isWhiteInNeighbourWall(Color.GREEN);
            
            if(isWhiteOnBlueSide)
            {
                Movement movement = new Movement(MovementType.B, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.B, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
            }

            if (isWhiteOnOrangeSide)
            {
                Movement movement = new Movement(MovementType.L, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.L, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
            }

            if (isWhiteOnRedSide)
            {
                Movement movement = new Movement(MovementType.R, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.R, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
            }

            if (isWhiteOnGreenSide)
            {
                Movement movement = new Movement(MovementType.F, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.F, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
            }

        }

        private bool isWhiteInNeighbourWall(Color color)
        {
            return rubicCubeSides[color].fields[0][1] == Color.WHITE;
        }
    }
}
