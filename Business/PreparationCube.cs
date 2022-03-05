using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace RubicCube.Business
{

    class PreparationCube
    {
        public Dictionary<Color, Side> sides { get; }

        public PreparationCube()
        {
            this.sides = new Dictionary<Color, Side>();
            this.prepare();
            this.shuffle();
            this.saveToFile();
        }

        private void prepare()
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

        public void shuffle()
        {
            
            for(int i = 0; i<1000; i++)
            {
                Array values = Enum.GetValues(typeof(MovementType));
                Random random = new Random();
                MovementType randomMovement = (MovementType)values.GetValue(random.Next(values.Length-1));
                Movement movement = new Movement(randomMovement, this.sides);
            }
        }

        private void saveToFile()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
            {
                /*this.sides[Color.ORANGE] = new Side(new List<Color[]>{
                    new Color[]{ Color.ORANGE, Color.YELLOW, Color.RED },
                    new Color[]{ Color.YELLOW, Color.ORANGE, Color.BLUE },
                    new Color[]{ Color.ORANGE, Color.ORANGE, Color.ORANGE }
                });*/
                foreach (KeyValuePair<Color, Side> row in this.sides)
                {
                    outputFile.WriteLine("this.sides[Color." + row.Key + "] = new Side(new List<Color[]>{");
                    outputFile.WriteLine("");
                    for (int i = 0; i < row.Value.fields.Count; i++)
                    {
                        outputFile.Write("new Color[]{ ");
                        for (int j = 0; j < row.Value.fields[i].Length; j++)
                        {
                            outputFile.Write("Color." + row.Value.fields[i][j]);
                            if (j == row.Value.fields[i].Length - 1) outputFile.Write(" },\n");
                            if (j < row.Value.fields[i].Length - 1) outputFile.Write(", ");
                        }
                    }
                    outputFile.WriteLine("});");

                }

            }
        }
        public Dictionary<Color, Side> copySides() 
        {
            Dictionary<Color, Side> ret = new Dictionary<Color, Side>(this.sides.Count,
                                                            this.sides.Comparer);
            foreach (KeyValuePair<Color, Side> entry in this.sides)
            {
                Side newSide = entry.Value.clone();
                ret.Add(entry.Key, newSide);
            }

            return ret;
        }

    }
}
