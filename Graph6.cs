using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace ZedGraphSample
{
	public class Graph6
	{
		public List<Points6> CreateGraph6(ZedGraphControl zgc, AllParam ap1, List<Points5> inputlist56)
		{
			GraphPane myPane = zgc.GraphPane;

			// Set the titles and axis labels
			myPane.Title.Text = "My Test Graph";
			//myPane.XAxis.Title.Text = "Длина волны, нМ";
			myPane.YAxis.Title.Text = "Интенсивность, у.е.";

			// Make up some data points from the Sine function


			double t6;
			double r6;
			double etalon6;
			double wave1;
			double n6;
			double fromLym;
			double toLym;
			double stapGet;
			int dt6;

			// взятие параметров из label-ов
			dt6 = ap1.Dt6;
			r6 = Convert.ToDouble(ap1.Otr6.Replace(".", ",")); // коэф отражения
			t6 = 1 - r6; ;   //
			etalon6 = Convert.ToDouble(ap1.Etal6.Replace(".", ",")) * 1000000 + dt6;
			wave1 = Convert.ToDouble(ap1.Wave.Replace(".", ","));
			n6 = Convert.ToDouble(ap1.Prel6.Replace(".", ","));
			fromLym = Convert.ToDouble(ap1.FromLym.Replace(".", ","));
			toLym = Convert.ToDouble(ap1.ToLym.Replace(".", ","));
			stapGet = Convert.ToDouble(ap1.Staps) / 10000;

			/*
			 * n - показатель преломления
			 * r - коэф пропускания
			 * t - коэф отражения
			 * 
			 */



			double dlym = (wave1 * wave1) / (2 * etalon6 * n6); //расстояние между спектральными максимумами 

			PointPairList list6 = new PointPairList();
			List<Points6> list67 = new List<Points6>();

			int i = 0;
			//double dwave2 = wave1 * 0.001;

			double dwave1 = 0;
			double dwave2 = 0;

			if (fromLym == 0 && toLym == 0)
			{

				if (wave1 < 150)
				{
					dwave1 = 2;
					dwave2 = 2;
				}
				if (wave1 >= 150 && wave1 < 3000)
				{
					dwave1 = wave1 * 0.001;
					dwave2 = wave1 * 0.001;
				}
				if (wave1 >= 3000)
				{
					dwave1 = wave1 * 0.01;
					dwave2 = wave1 * 0.01;
				}
			}

			else
			{
				dwave1 = fromLym;
				dwave2 = toLym;
			}


			double dwave1k = 0;
			double dwave2k = 0;

			if (fromLym == 0 && toLym == 0)
			{


				dwave1k = 2;
				dwave2k = 2;


			}
			else
			{
				dwave1k = fromLym;
				dwave2k = toLym;
			}

			double stap;

			if (ap1.Indicator == 1)
			{

				if (stapGet == 0)
				{
					stap = 0.01;
				}
				else
				{
					stap = stapGet;
				}

				for (double x = wave1 - dwave1; x <= wave1 + dwave2; x += stap)
				{

					double undcos = (2 * Math.PI / x) * 2 * etalon6 * n6;
					double y = inputlist56[i].y56 * (Math.Pow(t6, 2) / (1 + Math.Pow(r6, 4) - 2 * Math.Pow(r6, 2) * Math.Cos(undcos)));
					Points6 p67 = new Points6();
					p67.x67 = x;
					p67.y67 = y;
					list67.Add(p67);
					list6.Add(x, y);
					i++;
				}
				myPane.XAxis.Title.Text = "Длина волны, нМ";
			}





			if (ap1.Indicator == 0)
			{

				if (stapGet == 0.01)
				{
					stap = 0.000000001;
				}
				else
				{
					stap = stapGet / 100000000;
				}

				//(double x = (2 * Math.PI) / (wave1 + 2); x <= (2 * Math.PI) / (wave1 - 2); x += 0.000000001)
				for (double x = (1 / wave1) - (dwave1k / 1000000); x <= (1 / wave1) + (dwave2k / 1000000); x += stap)

				{

					double undcos = (2 * Math.PI * x) * 2 * etalon6 * n6;
					double y = inputlist56[i].y56 * (Math.Pow(t6, 2) / (1 + Math.Pow(r6, 4) - 2 * Math.Pow(r6, 2) * Math.Cos(undcos)));
					Points6 p67 = new Points6();
					p67.x67 = x;
					p67.y67 = y;
					list67.Add(p67);
					list6.Add(x, y);
					i++;
				}
				myPane.XAxis.Title.Text = "Волновые числа, -1 см";
			}


			// Generate a blue curve with circle symbols, and "My Curve 2" in the legend
			myPane.CurveList.Clear();
			LineItem myCurve = myPane.AddCurve("6 эталонов", list6, Color.Blue,
									SymbolType.Circle);

			// Fill the area under the curve with a white-red gradient at 45 degrees
			myCurve.Line.Fill = new Fill(Color.White, Color.Black, 45F);
			// Make the symbols opaque by filling them with white
			myCurve.Symbol.Fill = new Fill(Color.White);

			// Fill the axis background with a color gradient
			myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(228, 227, 237), 45F);

			// Fill the pane background with a color gradient

			myPane.Fill = new Fill(Color.White);

			//myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);

			// Calculate the Axis Scale Ranges
			zgc.AxisChange();
			zgc.Refresh();
			return list67;
		}
	}
}