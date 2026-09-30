using System;
using System.Drawing;
using System.Windows.Forms;

Form screen = new Form();

TextBox midXInput = new TextBox();
TextBox midYInput = new TextBox();
TextBox scaleInput = new TextBox();
TextBox iterationsInput = new TextBox();

Label midXLabel = new Label();
Label midYLabel = new Label();
Label scaleLabel = new Label();
Label iterationsLabel = new Label();

Button goBtn = new Button();

int maxIterations = 250;
float scale = 0.01f;




void init()
{
    screen.Text = "Mandelbrot";
    screen.BackColor = Color.LightYellow;
    screen.ClientSize = new Size(500, 500);

    midXInput.Location = new Point(250 - midXInput.Width / 2, 0);
    midYInput.Location = new Point(250 - midYInput.Width / 2, midXInput.Location.Y + midXInput.Height + 10);
    scaleInput.Location = new Point(250 - scaleInput.Width / 2, midYInput.Location.Y + midYInput.Height + 10);
    iterationsInput.Location = new Point(250 - iterationsInput.Width / 2, scaleInput.Location.Y + scaleInput.Height + 10);

    midXLabel.Location = new Point(midXInput.Location.X - midXLabel.Width / 2 - 10, 0);
    midXLabel.Text = "Midden x: ";

    midYLabel.Location = new Point(midYInput.Location.X - midYLabel.Width / 2 - 10, midYInput.Location.Y);
    midYLabel.Text = "Midden y: ";

    scaleLabel.Location = new Point(scaleInput.Location.X - scaleInput.Width / 2 - 10, scaleInput.Location.Y);
    scaleLabel.Text = "Schaal: ";

    iterationsLabel.Location = new Point(iterationsInput.Location.X - iterationsInput.Width / 2 - 10, iterationsInput.Location.Y);
    iterationsLabel.Text = "Aantal: ";

    goBtn.Location = new Point(250 - goBtn.Width / 2, iterationsInput.Location.Y + iterationsInput.Height + 10);
    goBtn.Text = "Go!";
    goBtn.BackColor = Color.White;

    screen.Controls.Add(midXInput);
    screen.Controls.Add(midYInput);
    screen.Controls.Add(scaleInput);
    screen.Controls.Add(iterationsInput);

    screen.Controls.Add(midXLabel);
    screen.Controls.Add(midYLabel);
    screen.Controls.Add(scaleLabel);
    screen.Controls.Add(iterationsLabel);

    screen.Controls.Add(goBtn);
}


void getInput()
{
    float midX = float.Parse(midXInput.Text);
    float midY = float.Parse(midYInput.Text);
    float scale = float.Parse(scaleInput.Text);
    int maxIterations = int.Parse(iterationsInput.Text);

    return 
}


double CalcDist(double x, double y)
{
    double dist = Math.Sqrt(Math.Pow(0 - x, 2) + Math.Pow(0 - y, 2));
    return dist;
}


int MandelNumber(double x, double y)
{
    double a = 0;
    double b = 0;
    int i = 0;

    while (CalcDist(a, b) < 2 && i < maxIterations) {
        double newA = a * a - b * b + x;
        b = 2*a*b + y;
        a = newA;

        i++;
    }

    return i;
}


void DrawMandelBrot()
{
    Label mandelBrotLabel = new Label();
    mandelBrotLabel.BringToFront();
    mandelBrotLabel.Location = new Point(100, iterationsInput.Location.Y + iterationsInput.Height + 25);
    mandelBrotLabel.Size = new Size(400, 400);

    Bitmap img = new Bitmap(400, 400);

    for (int i = 0; i < 400; i++)
    {
        for (int j = 0; j < 400; j++)
        {
            float x = (i -200) * scale;
            float y = (j -200) * scale;

            int mandelNumber = MandelNumber(x, y);

            if (mandelNumber % 2 == 0)
            {
                img.SetPixel(i, j, Color.Black);
            } else
            {
                if (mandelNumber > 15)
                {
                    img.SetPixel(i, j, Color.Red);
                } else
                {
                    img.SetPixel(i, j, Color.White);
                }
            }
        }
    }
    mandelBrotLabel.Image = img;
    mandelBrotLabel.BringToFront();


    screen.Controls.Add(mandelBrotLabel);
}


init();

DrawMandelBrot();

Application.Run(screen);