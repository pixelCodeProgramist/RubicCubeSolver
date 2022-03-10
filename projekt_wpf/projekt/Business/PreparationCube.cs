using projekt.Models;
using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace RubicCube.Business
{

    class PreparationCube
    {

        public Dictionary<Color, Side> sides { get; }

        public SquareVisualizationModel squareVisualizationModel { get; set; }
        public PreparationCube()
        {
            this.sides = new Dictionary<Color, Side>();
        }

        public void resetCube()
        {
            this.sides[Color.ORANGE] = new Side(new List<Color[]>{
                new Color[]{ Color.ORANGE, Color.ORANGE, Color.ORANGE },
                new Color[]{ Color.ORANGE, Color.ORANGE, Color.ORANGE },
                new Color[]{ Color.ORANGE, Color.ORANGE, Color.ORANGE }
            });

            this.sides[Color.GREEN] = new Side(new List<Color[]>{
                new Color[]{ Color.GREEN, Color.GREEN, Color.GREEN },
                new Color[]{ Color.GREEN, Color.GREEN, Color.GREEN },
                new Color[]{ Color.GREEN, Color.GREEN, Color.GREEN }
            });

            this.sides[Color.WHITE] = new Side(new List<Color[]>{
                new Color[]{ Color.WHITE, Color.WHITE, Color.WHITE },
                new Color[]{ Color.WHITE, Color.WHITE, Color.WHITE },
                new Color[]{ Color.WHITE, Color.WHITE, Color.WHITE }
            });

            this.sides[Color.YELLOW] = new Side(new List<Color[]>{
                new Color[]{ Color.YELLOW, Color.YELLOW, Color.YELLOW },
                new Color[]{ Color.YELLOW, Color.YELLOW, Color.YELLOW },
                new Color[]{ Color.YELLOW, Color.YELLOW, Color.YELLOW }
            });

            this.sides[Color.RED] = new Side(new List<Color[]>{
                new Color[]{ Color.RED, Color.RED, Color.RED },
                new Color[]{ Color.RED, Color.RED, Color.RED },
                new Color[]{ Color.RED, Color.RED, Color.RED }
            });

            this.sides[Color.BLUE] = new Side(new List<Color[]>{
                new Color[]{ Color.BLUE, Color.BLUE, Color.BLUE },
                new Color[]{ Color.BLUE, Color.BLUE, Color.BLUE },
                new Color[]{ Color.BLUE, Color.BLUE, Color.BLUE }
            });
        }

        public void Move(string type)
        {
            MovementType movementType = MovementType.NONE;
            type = type.ToLower();
            if (type == "f") movementType = MovementType.F;
            if (type == "f'") movementType = MovementType.F_PRIM;
            if (type == "r") movementType = MovementType.R;
            if (type == "r'") movementType = MovementType.R_PRIM;
            if (type == "u") movementType = MovementType.U;
            if (type == "u'") movementType = MovementType.U_PRIM;
            if (type == "b") movementType = MovementType.B;
            if (type == "b'") movementType = MovementType.B_PRIM;
            if (type == "l") movementType = MovementType.L;
            if (type == "l'") movementType = MovementType.L_PRIM;
            if (type == "d") movementType = MovementType.D;
            if (type == "d'") movementType = MovementType.D_PRIM;
            Movement movement = new Movement(movementType, this.sides, null, false);
        }

        public async void shuffle(int moves, int delay)
        {
            
            for(int i = 0; i<moves; i++)
            {
                Array values = Enum.GetValues(typeof(MovementType));
                Random random = new Random();
                MovementType randomMovement = (MovementType)values.GetValue(random.Next(values.Length-1));
                Movement movement = new Movement(randomMovement, this.sides, null, false);
                this.UpdateCube(this.squareVisualizationModel);
                await Task.Delay(delay);
            }
        }

        public async void solve(List<Step> steps, System.Windows.Controls.Label moveNumberLabel, System.Windows.Controls.TextBox movementTextBox, int delay)
        {
            int movementNumber = 1;
            foreach(Step step in steps)
            {
                Movement movement = new Movement(step.movementType, this.sides, null, false);
                this.UpdateCube(this.squareVisualizationModel);
                moveNumberLabel.Content = "Liczba ruchów: " + movementNumber;
                movementTextBox.Text += step.movementType.ToString() + ", ";
                movementNumber++;
                movementTextBox.ScrollToEnd();
                await Task.Delay(delay);
            }
            
        }

        private void UpdateSideOfCube(Color color, List<List<Rectangle>> side)
        {
            for (int i = 0; i < side.Count; i++)
            {
                for (int j = 0; j < side[i].Count; j++)
                {
                    side[i][j].Fill = GetColor(this.sides[color].fields[i][j]);
                }
            }

           
        }
        public void UpdateCube(SquareVisualizationModel squareVisualizationModel)
        {
            
            foreach (KeyValuePair<Color, Side> map in this.sides)
            {
                if (map.Key == Color.ORANGE)
                {
                    this.UpdateSideOfCube(Color.ORANGE, squareVisualizationModel.OrangeSide);
                }
                if (map.Key == Color.GREEN)
                {
                    this.UpdateSideOfCube(Color.GREEN, squareVisualizationModel.GreenSide);
                }
                if (map.Key == Color.WHITE)
                {
                    this.UpdateSideOfCube(Color.WHITE, squareVisualizationModel.WhiteSide);
                }
                if (map.Key == Color.YELLOW)
                {
                    this.UpdateSideOfCube(Color.YELLOW, squareVisualizationModel.YellowSide);
                }
                if (map.Key == Color.RED)
                {
                    this.UpdateSideOfCube(Color.RED, squareVisualizationModel.RedSide);
                }
                if (map.Key == Color.BLUE)
                {
                    this.UpdateSideOfCube(Color.BLUE, squareVisualizationModel.BlueSide);
                }
            }
        }

        private System.Windows.Media.SolidColorBrush GetColor(Color color)
        {
            if (color == Color.ORANGE) return System.Windows.Media.Brushes.Orange;
            if (color == Color.GREEN) return System.Windows.Media.Brushes.Green;
            if (color == Color.WHITE) return System.Windows.Media.Brushes.White;
            if (color == Color.YELLOW) return System.Windows.Media.Brushes.Yellow;
            if (color == Color.RED) return System.Windows.Media.Brushes.Red;
            if (color == Color.BLUE) return System.Windows.Media.Brushes.Blue;
            return System.Windows.Media.Brushes.Transparent;
        }

        public static Dictionary<Color, Side> copySides(Dictionary<Color, Side> sides)
        {
            Dictionary<Color, Side> ret = new Dictionary<Color, Side>(sides.Count);
            foreach (KeyValuePair<Color, Side> entry in sides)
            {
                Side newSide = entry.Value.clone();
                ret.Add(entry.Key, newSide);
            }

            return ret;
        }

    }
}
