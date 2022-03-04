﻿using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlaceOneTakenForWhiteCrossBottomSideWallLayerPackage
{
    class OnePlaceTakenCrossBottomGreenSide : OnePlaceTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private Color centroidColor;
        private List<Step> steps;
        public OnePlaceTakenCrossBottomGreenSide(Dictionary<Color, Side> rubicCubeSides, Color mainSideColor, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.centroidColor = mainSideColor;
            this.steps = steps;
        }

        public override void create()
        {
            rotateLastLayerRelativeCentroidAndYellowNaighbourSquare(rubicCubeSides, centroidColor, steps);
            Movement movement = new Movement(MovementType.F_PRIM, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.U_PRIM, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.R, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.U, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
        }
    }
}