using Eto.Forms;
using Eto.Drawing;
using System;

namespace FocusBar
{
    public class FocusBarForm : Form
    {
        private uint timerStart;
        private UITimer timer;
        private TextBox taskTextBox;
        private Label timerLabel;
        private Button startStopButton;
        private Button resetButton;
        private Button exitButton;

        public FocusBarForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Title = "FocusBar";
            
            // Make window always on top and remove decorations for minimal look
            Topmost = true;
            WindowStyle = WindowStyle.None;
            Resizable = false;
            ShowInTaskbar = false;
            
            // Timer initialization
            timerStart = 0;
            timer = new UITimer();
            timer.Interval = 1.0; // 1 second
            timer.Elapsed += Timer_Elapsed;

            // Create controls
            taskTextBox = new TextBox
            {
                PlaceholderText = "What are you focusing on?",
                Width = 300
            };

            timerLabel = new Label
            {
                Text = "00:00:00",
                Font = SystemFonts.Default(),
                TextAlignment = TextAlignment.Center,
                Width = 80
            };

            startStopButton = new Button
            {
                Text = "▶",
                Width = 30,
                Height = 25
            };
            startStopButton.Click += StartStopButton_Click;

            resetButton = new Button
            {
                Text = "⏹",
                Width = 30,
                Height = 25
            };
            resetButton.Click += ResetButton_Click;

            exitButton = new Button
            {
                Text = "✕",
                Width = 30,
                Height = 25
            };
            exitButton.Click += ExitButton_Click;

            // Layout
            var layout = new TableLayout
            {
                Spacing = new Size(5, 5),
                Padding = new Padding(10, 5),
                Rows =
                {
                    new TableRow(
                        new TableCell(taskTextBox, true),
                        new TableCell(timerLabel),
                        new TableCell(startStopButton),
                        new TableCell(resetButton),
                        new TableCell(exitButton)
                    )
                }
            };

            Content = layout;

            // Position window at top of screen
            PositionAtTop();
        }

        private void PositionAtTop()
        {
            // Get screen dimensions
            var screen = Screen.PrimaryScreen;
            var screenBounds = screen.WorkingArea;
            
            // Set window size
            var formSize = new Size(500, 35);
            Size = formSize;
            
            // Position at top center of screen
            Location = new Point(
                (int)((screenBounds.Width - formSize.Width) / 2),
                (int)screenBounds.Y
            );
        }

        private void Timer_Elapsed(object sender, EventArgs e)
        {
            timerStart += 1;
            Application.Instance.AsyncInvoke(() =>
            {
                timerLabel.Text = Utils.FormatTimeElapsed(timerStart);
            });
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            if (!timer.Started)
            {
                timer.Start();
                startStopButton.Text = "⏸";
            }
            else
            {
                timer.Stop();
                startStopButton.Text = "▶";
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timerStart = 0;
            startStopButton.Text = "▶";
            timerLabel.Text = "00:00:00";
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Instance.Quit();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            
            // Ensure window stays on top and is positioned correctly
            PositionAtTop();
            BringToFront();
        }
    }
}