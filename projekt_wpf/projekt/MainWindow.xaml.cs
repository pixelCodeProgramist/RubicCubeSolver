using projekt.Models;
using RubicCube.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread timerThread;
        PreparationCube preparationCube;
        SquareVisualizationModel squareVisualizationModel;
        bool canExecuteTimer = false;
        bool canResetTimer = true;
        bool canClickButtons = true;
        LayerByLayerMethod layerByLayerMethod;
        public MainWindow()
        {
            InitializeComponent();
            this.preparationCube = new PreparationCube();
            this.squareVisualizationModel = new SquareVisualizationModel();
            this.preparationCube.resetCube();
            this.SetVizualizationModel();
            this.preparationCube.squareVisualizationModel = this.squareVisualizationModel;
            this.preparationCube.UpdateCube(this.squareVisualizationModel);
            this.timerThread = new Thread(ExecuteTimer);
            timerThread.IsBackground = true;
            this.timerThread.Start();
        }

        public void ExecuteTimer()
        {
            int timer = 1;
            while (true)
            {
                if(canExecuteTimer)
                {
                    TimeSpan t = TimeSpan.FromSeconds(timer);
                    this.Dispatcher.Invoke(() =>
                    {
                        TimeLabel.Content = "Czas " + t.ToString("mm\\:ss");
                    });
                    timer++;
                    Thread.Sleep(1000);
                } else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        if (canResetTimer) TimeLabel.Content = "";
                    });
                    if (canResetTimer) timer = 1;
                }
            }
        }

        private void Navigation_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.layerByLayerMethod != null)
            {
                if (this.layerByLayerMethod.steps.Count > 0) this.canClickButtons = false;
                else this.canClickButtons = true;
            }

            if (this.canClickButtons)
            {
                Button button = (Button)sender;
                string type = button.Content.ToString();
                this.preparationCube.Move(type);
                this.preparationCube.UpdateCube(this.squareVisualizationModel);
                this.canResetTimer = true;
                MovementTextBox.Text = "";
                MoveNumberLabel.Content = "";
                TimeLabel.Content = "";
               
            }
        }

        private void SetVizualizationModel()
        {
            this.squareVisualizationModel.OrangeSide = new List<List<Rectangle>>()
            {
                new List<Rectangle>() { Orange00, Orange01, Orange02 },
                new List<Rectangle>() { Orange10, Orange11, Orange12 },
                new List<Rectangle>() { Orange20, Orange21, Orange22 },
            };

            this.squareVisualizationModel.GreenSide = new List<List<Rectangle>>()
            {
                new List<Rectangle>() { Green00, Green01, Green02 },
                new List<Rectangle>() { Green10, Green11, Green12 },
                new List<Rectangle>() { Green20, Green21, Green22 },
            };

            this.squareVisualizationModel.WhiteSide = new List<List<Rectangle>>()
            {
                new List<Rectangle>() { White00, White01, White02 },
                new List<Rectangle>() { White10, White11, White12 },
                new List<Rectangle>() { White20, White21, White22 },
            };

            this.squareVisualizationModel.YellowSide = new List<List<Rectangle>>()
            {
                new List<Rectangle>() { Yellow00, Yellow01, Yellow02 },
                new List<Rectangle>() { Yellow10, Yellow11, Yellow12 },
                new List<Rectangle>() { Yellow20, Yellow21, Yellow22 },
            };

            this.squareVisualizationModel.RedSide = new List<List<Rectangle>>()
            {
                new List<Rectangle>() { Red00, Red01, Red02 },
                new List<Rectangle>() { Red10, Red11, Red12 },
                new List<Rectangle>() { Red20, Red21, Red22 },
            };

            this.squareVisualizationModel.BlueSide = new List<List<Rectangle>>()
            {
                new List<Rectangle>() { Blue00, Blue01, Blue02 },
                new List<Rectangle>() { Blue10, Blue11, Blue12 },
                new List<Rectangle>() { Blue20, Blue21, Blue22 },
            };
        }

        private async void Shuffle_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.layerByLayerMethod != null)
            {
                if (this.layerByLayerMethod.steps.Count > 0) this.canClickButtons = false;
                else this.canClickButtons = true;
            }

            if (this.canClickButtons)
            {
                MovementTextBox.Text = "";
                MoveNumberLabel.Content = "";
                TimeLabel.Content = "";
                int delay = 100;
                int moves = 50;
                this.preparationCube.shuffle(moves, delay);
                this.canResetTimer = true;
                this.canClickButtons = false;
                await Task.Delay(moves*delay);
                this.canClickButtons = true;
            }
        }

        private async void Solve_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.layerByLayerMethod != null)
            {
                if (this.layerByLayerMethod.steps.Count > 0) this.canClickButtons = false;
                else this.canClickButtons = true;
            }

            if (this.canClickButtons)
            {
                MovementTextBox.Text = "";
                MoveNumberLabel.Content = "";
                TimeLabel.Content = "";
                int delay = 1000;
                this.layerByLayerMethod = new LayerByLayerMethod();
                layerByLayerMethod.solve(this.preparationCube);
                this.canResetTimer = false;
                this.canExecuteTimer = true;
                this.preparationCube.solve(layerByLayerMethod.steps, MoveNumberLabel, MovementTextBox, delay);
                await Task.Delay(delay * layerByLayerMethod.steps.Count);
                this.canExecuteTimer = false;
                this.layerByLayerMethod = null;
            }
        }
    }
}
