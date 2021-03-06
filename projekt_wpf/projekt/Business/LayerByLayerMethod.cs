using System;
using System.Collections.Generic;
using System.Text;
using RubicCube.Business;
using RubicCube.Business.CubeSolverPackage;
using RubicCube.Business.CubeSolverPackage.SecondLayerStrategyPackage;
using RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage;
using RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCornerPermutationPackage;
using RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossMiddleSquarePackage;
using RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossPackage;
using RubicCube.Business.CubeSolverPackage.WhiteCornerStrategyPackage;
using RubicCube.Models;

namespace RubicCube.Business
{
    class LayerByLayerMethod
    {
        public LayerByLayerMethod()
        {
            this.steps = new List<Step>();
        }

        public List<Step> steps { get; set; }
        public void solve(PreparationCube preparationCube)
        {
            Dictionary<Color, Side> sides = PreparationCube.copySides(preparationCube.sides);
            ICubeSolverStrategy cubeSolverStrategy = new WhiteCrossStrategy();
            cubeSolverStrategy.solve(sides, steps);
            cubeSolverStrategy = new WhiteCornerStrategy();
            cubeSolverStrategy.solve(sides, steps);
            cubeSolverStrategy = new SecondLayerStrategy();
            cubeSolverStrategy.solve(sides, steps);
            cubeSolverStrategy = new YellowCrossStrategy();
            cubeSolverStrategy.solve(sides, steps);
            cubeSolverStrategy = new YellowCrossMiddleSquareStrategy();
            cubeSolverStrategy.solve(sides, steps);
            cubeSolverStrategy = new YellowCornerOrientationStrategy();
            cubeSolverStrategy.solve(sides, steps);
            cubeSolverStrategy = new YellowCornerPermutationStrategy();
            cubeSolverStrategy.solve(sides, steps);
        }
    }
}
