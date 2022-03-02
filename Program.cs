using RubicCube.Business;
using RubicCube.Business.CubeSolverPackage;
using RubicCube.Business.CubeSolverPackage.SecondLayerStrategyPackage;
using RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossMiddleSquarePackage;
using RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossPackage;
using RubicCube.Business.CubeSolverPackage.WhiteCornerStrategyPackage;
using RubicCube.Models;
using System;
using System.Collections.Generic;

namespace RubicCube
{
    class Program
    {
        static void Main(string[] args)
        {
            PreparationCube preparationCube = new PreparationCube();
            Dictionary<Color, Side> sides = preparationCube.sides;
            Dictionary<Color, Side> copySides = preparationCube.copySides();
            ICubeSolverStrategy cubeSolverStrategy = new WhiteCrossStrategy();
            cubeSolverStrategy.solve(copySides);
            cubeSolverStrategy = new WhiteCornerStrategy();
            cubeSolverStrategy.solve(copySides);
            cubeSolverStrategy = new SecondLayerStrategy();
            cubeSolverStrategy.solve(copySides);
            cubeSolverStrategy = new YellowCrossStrategy();
            cubeSolverStrategy.solve(copySides);
            cubeSolverStrategy = new YellowCrossMiddleSquareStrategy();
            cubeSolverStrategy.solve(copySides);
        }
        
        
    }
}
