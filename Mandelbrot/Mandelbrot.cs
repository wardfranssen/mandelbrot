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
Label mandelBrotLabel = new Label();

Button presetA = new Button();
Button presetB = new Button();
Button presetC = new Button();
Button presetD = new Button();
Button presetE = new Button();

ColorDialog colorDlg = new ColorDialog();
Button chsColor = new Button();
Color chsnColor = new Color();
chsnColor = Color.White;

double midX = 0f;
double midY = 0f;
double scale = 0.01f;
int maxIterations = 250;

void init()
{
	screen.Text = "Mandelbrot";
	screen.BackColor = Color.LightYellow;
	screen.ClientSize = new Size(500, 600);

	midXInput.Location = new Point(250 - midXInput.Width / 2, 10);
	midXInput.Text = "0";
	midYInput.Location = new Point(250 - midYInput.Width / 2, midXInput.Location.Y + midXInput.Height + 10);
	midYInput.Text = "0";
	scaleInput.Location = new Point(250 - scaleInput.Width / 2, midYInput.Location.Y + midYInput.Height + 10);
	scaleInput.Text = "0.01";
	iterationsInput.Location = new Point(250 - iterationsInput.Width / 2, scaleInput.Location.Y + scaleInput.Height + 10);
	iterationsInput.Text = "250";

	midXLabel.Location = new Point(midXInput.Location.X - midXLabel.Width / 2 - 10, 10);
	midXLabel.Text = "Midden x: ";

	midYLabel.Location = new Point(midYInput.Location.X - midYLabel.Width / 2 - 10, midYInput.Location.Y);
	midYLabel.Text = "Midden y: ";

	scaleLabel.Location = new Point(scaleInput.Location.X - scaleInput.Width / 2 - 10, scaleInput.Location.Y);
	scaleLabel.Text = "Schaal: ";

	iterationsLabel.Location = new Point(iterationsInput.Location.X - iterationsInput.Width / 2 - 10, iterationsInput.Location.Y);
	iterationsLabel.Text = "Aantal: ";

	chsColor.Location = new Point(170 - chsColor.Width / 2, iterationsInput.Location.Y + chsColor.Height + 10);
	chsColor.Text = "Kies kleur";
	chsColor.Click += chsClrClick;

	goBtn.Location = new Point(250 - goBtn.Width / 2, iterationsInput.Location.Y + iterationsInput.Height + 10);
	goBtn.Text = "Go!";
	goBtn.BackColor = Color.White;
	goBtn.Click += btnClick;
	mandelBrotLabel.MouseClick += mandelClick;

	presetA.Location = new Point(350, 0);
	presetB.Location = new Point(350, 20);
	presetC.Location = new Point(350, 40);
	presetD.Location = new Point(350, 60);
	presetE.Location = new Point(350, 80);
	presetA.Text = "A";
	presetB.Text = "B";
	presetC.Text = "C";
	presetD.Text = "D";
	presetE.Text = "E";






	mandelBrotLabel.Location = new Point(50, goBtn.Location.Y + goBtn.Height + 15);
	mandelBrotLabel.Size = new Size(400, 400);

	screen.Controls.Add(presetA);
	screen.Controls.Add(presetB);
	screen.Controls.Add(presetC);
	screen.Controls.Add(presetD);
	screen.Controls.Add(presetE);

	screen.Controls.Add(midXInput);
	screen.Controls.Add(midYInput);
	screen.Controls.Add(scaleInput);
	screen.Controls.Add(iterationsInput);

	screen.Controls.Add(midXLabel);
	screen.Controls.Add(midYLabel);
	screen.Controls.Add(scaleLabel);
	screen.Controls.Add(iterationsLabel);

	screen.Controls.Add(goBtn);
	screen.Controls.Add(mandelBrotLabel);
	screen.Controls.Add(chsColor);


}

void chsClrClick(object? o, EventArgs ea)
{
	colorDlg.AllowFullOpen = true;

	if (colorDlg.ShowDialog() == DialogResult.OK)
	{
		chsnColor = colorDlg.Color;
	}
}

void btnClick(object o, EventArgs ea)
{
	getInput();
	DrawMandelBrot();
}

void mandelClick(object o, MouseEventArgs mea)
{
	midX = midX + (mea.X - 200) * scale;
	midY = midY + (mea.Y - 200) * scale;

	if (mea.Button == MouseButtons.Left)
	{
		scale /= 2;
	}
	else if (mea.Button == MouseButtons.Right)
	{
		scale *= 2;
	}

	midXInput.Text = midX.ToString();
	midYInput.Text = midY.ToString();
	scaleInput.Text = scale.ToString();

	DrawMandelBrot();
}

void getInput()
{
	midX = double.Parse(midXInput.Text);
	midY = double.Parse(midYInput.Text);
	scale = double.Parse(scaleInput.Text);
	maxIterations = int.Parse(iterationsInput.Text);
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

	while (CalcDist(a, b) < 2 && i < maxIterations)
	{
		double newA = a * a - b * b + x;
		b = 2 * a * b + y;
		a = newA;

		i++;
	}

	return i;
}


void DrawMandelBrot()
{
	Bitmap img = new Bitmap(400, 400);
	for (int i = 0; i < 400; i++)
	{
		for (int j = 0; j < 400; j++)
		{
			double x = midX + (i - 200) * scale;
			double y = midY + (j - 200) * scale;

			int mandelNumber = MandelNumber(x, y);


			if (mandelNumber % 2 == 0)
			{
				img.SetPixel(i, j, chsnColor);
			}
			if (mandelNumber == maxIterations)
			{
				img.SetPixel(i, j, Color.FromArgb(0, 0, 0));
			}
			else
			{
				double factor = 0.2 + ((mandelNumber * 15) % 200) / 200.0;

				int r = Math.Clamp((int)(chsnColor.R * factor), 0, 255);
				int g = Math.Clamp((int)(chsnColor.G * factor), 0, 255);
				int b = Math.Clamp((int)(chsnColor.B * factor), 0, 255);

				img.SetPixel(i, j, Color.FromArgb(r, g, b));
			}
		}
	}
	mandelBrotLabel.Image = img;
}


init();

DrawMandelBrot();

Application.Run(screen);


// preset 1: -0.6025226465088581, 0.43666940855418046, 3.1820738254087074e-10