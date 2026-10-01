using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;


Form screen = new Form();

TextBox midXInput = new TextBox();
TextBox midYInput = new TextBox();
TextBox scaleInput = new TextBox();
TextBox iterationsInput = new TextBox();

Label midXLabel = new Label();
Label midYLabel = new Label();
Label scaleLabel = new Label();
Label iterationsLabel = new Label();

Label rLabel = new Label();
Label gLabel = new Label();
Label bLabel = new Label();
Label brightnessLabel = new Label();
Label bgBrightnessLabel = new Label();

Button goBtn = new Button();
Label mandelBrotLabel = new Label();

Button presetA = new Button();
Button presetB = new Button();
Button presetC = new Button();

TrackBar rSlider = new TrackBar();
TrackBar gSlider = new TrackBar();
TrackBar bSlider = new TrackBar();
TrackBar bgBrightnessSlider = new TrackBar();
TrackBar brightnessSlider = new TrackBar();

double midX = 0f;
double midY = 0f;
double scale = 0.01f;
int maxIterations = 250;
int userR = 255;
int userB = 255;
int userG = 255;
int userBrightness = 100;
int userBgBrightness = 100;


void Init()
{
	screen.Text = "Mandelbrot";
	screen.BackColor = Color.LightYellow;
	screen.ClientSize = new Size(500, 750);


	midXInput.Location = new Point(screen.Width / 2 - midXInput.Width / 2, 10);
	midXInput.Text = "0";
	midYInput.Location = new Point(screen.Width / 2 - midYInput.Width / 2, midXInput.Location.Y + midXInput.Height + 10);
	midYInput.Text = "0";
	scaleInput.Location = new Point(screen.Width / 2 - scaleInput.Width / 2, midYInput.Location.Y + midYInput.Height + 10);
	scaleInput.Text = 0.01.ToString();
	iterationsInput.Location = new Point(screen.Width / 2 - iterationsInput.Width / 2, scaleInput.Location.Y + scaleInput.Height + 10);
	iterationsInput.Text = "250";

	midXLabel.Location = new Point(midXInput.Location.X - midXLabel.Width / 2 - 10, 10);
	midXLabel.Text = "Midden x: ";

	midYLabel.Location = new Point(midYInput.Location.X - midYLabel.Width / 2 - 10, midYInput.Location.Y);
	midYLabel.Text = "Midden y: ";

	scaleLabel.Location = new Point(scaleInput.Location.X - scaleInput.Width / 2 - 10, scaleInput.Location.Y);
	scaleLabel.Text = "Schaal: ";

	iterationsLabel.Location = new Point(iterationsInput.Location.X - iterationsInput.Width / 2 - 10, iterationsInput.Location.Y);
	iterationsLabel.Text = "Aantal: ";


    rSlider.Location = new Point(screen.Width/2 - rSlider.Width / 2, iterationsInput.Location.Y + 25);
	gSlider.Location = new Point(screen.Width / 2 - rSlider.Width / 2, rSlider.Location.Y + 30);
	bSlider.Location = new Point(screen.Width / 2 - rSlider.Width / 2, gSlider.Location.Y + 30);
    bgBrightnessSlider.Location = new Point(screen.Width / 2 - rSlider.Width / 2, bSlider.Location.Y + 30);
	brightnessSlider.Location = new Point(screen.Width / 2 - rSlider.Width / 2, bgBrightnessSlider.Location.Y + 30);

	rSlider.TickStyle = TickStyle.None;
	rSlider.Maximum = 255;
	rSlider.Value = userR;

    gSlider.TickStyle = TickStyle.None;
    gSlider.Maximum = 255;
    gSlider.Value = userG;

    bSlider.TickStyle = TickStyle.None;
    bSlider.Maximum = 255;
    bSlider.Value = userB;

    bgBrightnessSlider.TickStyle = TickStyle.None;
    bgBrightnessSlider.Maximum = 100;
    bgBrightnessSlider.Value = userBgBrightness;

    brightnessSlider.TickStyle = TickStyle.None;
    brightnessSlider.Maximum = 100;
    brightnessSlider.RightToLeft = RightToLeft.Yes;
    brightnessSlider.Value = userBrightness;


	rLabel.Location = new Point(rSlider.Location.X-rSlider.Width/2, rSlider.Location.Y);
	rLabel.Text = "R: ";

    gLabel.Location = new Point(gSlider.Location.X - gSlider.Width / 2, gSlider.Location.Y);
    gLabel.Text = "G: ";

    bLabel.Location = new Point(bSlider.Location.X - bSlider.Width / 2, bSlider.Location.Y);
    bLabel.Text = "B: ";

	bgBrightnessLabel.Location = new Point(bgBrightnessSlider.Location.X - bgBrightnessSlider.Width / 2 - 100, bgBrightnessSlider.Location.Y);
	bgBrightnessLabel.Text = "Helderheid achtergrond: ";
	bgBrightnessLabel.Width = 250;

    brightnessLabel.Location = new Point(brightnessSlider.Location.X - brightnessSlider.Width / 2 - 100, brightnessSlider.Location.Y);
    brightnessLabel.Text = "Helderheid rest: ";
    brightnessLabel.Width = 250;


    goBtn.Location = new Point(screen.Width / 2 - goBtn.Width / 2, brightnessSlider.Location.Y + brightnessSlider.Height + 10);
	goBtn.Text = "Go!";

	goBtn.BackColor = Color.White;
	goBtn.Click += BtnClick;
	mandelBrotLabel.MouseClick += MandelClick;

	presetA.Location = new Point(350, 0);
	presetB.Location = new Point(350, 20);
	presetC.Location = new Point(350, 40);
	presetA.Text = "A";
	presetB.Text = "B";
	presetC.Text = "C";
	presetA.Click += PresetA;
	presetB.Click += PresetB;
	presetC.Click += PresetC;

    mandelBrotLabel.Location = new Point(50, goBtn.Location.Y + goBtn.Height + 15);
	mandelBrotLabel.Size = new Size(400, 400);

	screen.Controls.Add(presetA);
	screen.Controls.Add(presetB);
	screen.Controls.Add(presetC);

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

	screen.Controls.Add(rSlider);
	screen.Controls.Add(gSlider);
	screen.Controls.Add(bSlider);
	screen.Controls.Add(bgBrightnessSlider);
	screen.Controls.Add(brightnessSlider);

	screen.Controls.Add(rLabel);
	screen.Controls.Add(gLabel);
	screen.Controls.Add(bLabel);
    screen.Controls.Add(bgBrightnessLabel);
    screen.Controls.Add(brightnessLabel);

    // De sliders zijn aan de onderkant groter dan verwacht wegens de tickstyle die ontzichbaar is
    // Daarom moeten we ze op de voorgrond zetten zodat ze over elkaar heen kunnen en minder ruimte innemen
    gSlider.BringToFront();
    bSlider.BringToFront();
    bgBrightnessSlider.BringToFront();
    brightnessSlider.BringToFront();
}

void BtnClick(object o, EventArgs ea)
{
	GetInput();
	DrawMandelBrot();
}

void MandelClick(object o, MouseEventArgs mea)
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


void GetInput()
{
	midX = double.Parse(midXInput.Text);
	midY = double.Parse(midYInput.Text);
	scale = double.Parse(scaleInput.Text);
	maxIterations = int.Parse(iterationsInput.Text);
	userR = rSlider.Value;
	userG = gSlider.Value;
	userB = bSlider.Value;
	userBrightness = brightnessSlider.Value;
	userBgBrightness = bgBrightnessSlider.Value;
}


double CalcDist(double x, double y)
{
	double dist = Math.Sqrt(Math.Pow(0 - x, 2) + Math.Pow(0 - y, 2));
	return dist;
}


(int, double) MandelNumber(double x, double y)
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

	return (i, CalcDist(a, b));
}


// Maakt een verschuiving van kleur a naar kleur b, t geeft aan hoeveel de verschuiving moet zijn
Color Lerp(Color a, Color b, double t)
{
    int r = (int)(a.R + (b.R - a.R) * t);
    int g = (int)(a.G + (b.G - a.G) * t);
    int bValue = (int)(a.B + (b.B - a.B) * t);

    return Color.FromArgb(r, g, bValue);
}


void DrawMandelBrot()
{
	// Maak een kleurenpalet waarbij de helder
	List<Color> customPalette = [];
	for (int i = 0; i < 10; i++)
	{
		float brightnessMultiplier = brightnessSlider.Value / 30;

		int r = Math.Clamp((int)(userR * (i / brightnessMultiplier)), 0, 255);
		int g = Math.Clamp((int)(userG * (i / brightnessMultiplier)), 0, 255);
		int b = Math.Clamp((int)(userB * (i / brightnessMultiplier)), 0, 255);

		customPalette.Add(Color.FromArgb(r, g, b));
	}


	Bitmap img = new Bitmap(400, 400);
	for (int i = 0; i < 400; i++)
	{
		for (int j = 0; j < 400; j++)
		{
			double x = midX + (i - 200) * scale;
			double y = midY + (j - 200) * scale;

			var (mandelNumber, dist) = MandelNumber(x, y);

			// Online gevonden formule voor smooth coloring
			double smooth = mandelNumber - Math.Log(Math.Log(dist)) / Math.Log(2);

            // Bepaald hoe snel we door het kleurenpalet gaan
            double position = smooth * 0.2;

			// Zorg ervoor dat we binnen de range van het palet blijven
            position %= customPalette.Count;

            if (position < 0)
                position += customPalette.Count;

            int index = (int)position;
            double fraction = position - index;

            Color color1 = customPalette[index];
            Color color2 = customPalette[(index + 1) % customPalette.Count];

			// Maak een kleur die tussen de huidige en de volgende kleur van het palet in zit, zodat we een smooth gradient kunnen maken
			Color color = Lerp(color1, color2, fraction);


            if (mandelNumber == maxIterations)
			{
				color = Color.Black;
			} else if (mandelNumber < Math.Max(maxIterations / 15, 10))
			{
				// Als het mandelgetal kleiner is dan 1/15de van de maximale iteraties(minstens 10) dan valt onder de "achtergrond" van het figuur
				// De helderheid van de "achtergrond" kan je dan zelf instellen
				double brightness = userBgBrightness / 100.0;

                int r = (int)(color.R * brightness);
                int g = (int)(color.G * brightness);
                int b = (int)(color.B * brightness);

                color = Color.FromArgb(r, g, b);
            }
            img.SetPixel(i, j, color);
        }
    }
	mandelBrotLabel.Image = img;
}


void PresetA(object o, EventArgs ea)
{
	midXInput.Text = "-" + 0.60252264;
	midYInput.Text = 0.43666940855418046.ToString();
	scaleInput.Text = 3.1820738254087074e-10.ToString();
	iterationsInput.Text = 500.ToString();

    bgBrightnessSlider.Value = 0;
    brightnessSlider.Value = 100;

    BtnClick(o, ea);
}

void PresetB(object o, EventArgs ea)
{
    midXInput.Text = 0.30422.ToString();
    midYInput.Text = 0.022075.ToString();
    scaleInput.Text = 2.5e-5.ToString();
    iterationsInput.Text = 750.ToString();

    bgBrightnessSlider.Value = 0;
    brightnessSlider.Value = 100;

    BtnClick(o, ea);
}

void PresetC(object o, EventArgs ea)
{
    midXInput.Text = "-" + 1.25067154585;
    midYInput.Text = 0.02012043845.ToString();
    scaleInput.Text = 1.4615e-7.ToString();
    iterationsInput.Text = 2000.ToString();

	rSlider.Value = 50;
	gSlider.Value = 50;
	bSlider.Value = 50;

	bgBrightnessSlider.Value = 100;
	brightnessSlider.Value = 75;

    BtnClick(o, ea);
}


Init();

DrawMandelBrot();

Application.Run(screen);
