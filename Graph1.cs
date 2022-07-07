using System;
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
    public class Graph1 
    {

		/// <summary>
		/// График для одного эталона
		/// </summary>
		/// <param name="zgc"></param>
		/// <param name="ap"> все параметры </param>
		/// 


		public  List<Points> CreateGraph1(ZedGraphControl zgc, AllParam ap)
		{
			GraphPane myPane = zgc.GraphPane;

			// Set the titles and axis labels
			myPane.Title.Text = "My Test Graph";
			//myPane.XAxis.Title.Text = "Длина волны, нМ";
			myPane.YAxis.Title.Text = "Интенсивность, у.е.";

			// Make up some data points from the Sine function






			
				double t1;
				double r1;
				double etalon1;
				double wave;
				double n1;
				double fromLym;
				double toLym;
				double stapGet;
				int dt1;




				dt1 = ap.Dt1;
				r1 = Convert.ToDouble(ap.Otr1.Replace("." , ",")); // коэф отражения
				t1 = 1 - r1;   // пропускание 
				etalon1 = Convert.ToDouble(ap.Etal1.Replace(".", ",")) * 1000000 + dt1;
				wave = Convert.ToDouble(ap.Wave.Replace(".", ","));
				n1 = Convert.ToDouble(ap.Prel1.Replace(".", ","));
				fromLym = Convert.ToDouble(ap.FromLym.Replace(".", ","));
				toLym = Convert.ToDouble(ap.ToLym.Replace(".", ","));
				stapGet = Convert.ToDouble(ap.Staps) / 10000;
				



				/*
				 * n - показатель преломления
				 * t - коэф пропускания  
				 * r - коэф отражения
				 */



				double dlym1 = (wave * wave) / (2 * etalon1 * n1); //расстояние между спектральными максимумами 


				PointPairList list1 = new PointPairList();
				List<Points> list12 = new List<Points>();

				double dwave1 = 0;
				double dwave2 = 0;
				if (fromLym == 0 && toLym == 0)
				{

					if (wave < 150)
					{
						dwave1 = 2;
						dwave2 = 2;
					}
					if (wave >= 150 && wave < 3000)
					{
						dwave1 = wave * 0.001;
						dwave2 = wave * 0.001;
					}
					if (wave >= 3000)
					{
						dwave1 = wave * 0.01;
						dwave2 = wave * 0.01;
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
				//double k = (2 * Math.PI) / wave;    // длина волны в волновые числа 

				//if (indicator == 1)
				if (ap.Indicator == 1)
				{



					if (stapGet == 0)
					{
						stap = 0.01;
					}
					else
					{
						stap = stapGet;
					}

					//for (double x = wave - dwave1; x <= wave + dwave2; x += 0.01)
					for (double x = wave - dwave1; x <= wave + dwave2; x += stap)
					{

						double undcos = (2 * Math.PI / x) * 2 * etalon1 * n1;
						double y = Math.Pow(t1, 2) / (1 + Math.Pow(r1, 4) - 2 * Math.Pow(r1, 2) * Math.Cos(undcos));
						Points p12 = new Points();
						p12.x12 = x;
						p12.y12 = y;
						list12.Add(p12);
						list1.Add(x, y);

					}

					///// нормировка по интенсивности



					myPane.XAxis.Title.Text = "Длина волны, нМ";
				}
				//double x = wave - 2; x <= wave + 2; x += 0.001
				//double x = (2 * Math.PI) / (wave + 2); x <= (2 * Math.PI) / (wave - 2); x += 0.000000001
				//if (ap.Indicator == 0)
				//if ( indicator == 0)
				if (ap.Indicator == 0)
				{


					if (stapGet == 0.01)
					{
						stap = 0.000000001;
					}
					else
					{
						stap = stapGet/100000000;
					}
			//	x <= 1 / (wave - dwave1)
					for (double x = (1 / (wave )) - (dwave1k / 1000000); x <= (1 / (wave)) + (dwave2k / 1000000); x += stap)
					{

						double undcos = (2 * Math.PI * x) * 2 * etalon1 * n1;
						double y = Math.Pow(t1, 2) / (1 + Math.Pow(r1, 4) - 2 * Math.Pow(r1, 2) * Math.Cos(undcos));

						Points p12 = new Points();
						p12.x12 = x;
						p12.y12 = y;
						list12.Add(p12);
						list1.Add(x, y);
					}
					myPane.XAxis.Title.Text = "Волновые числа, -1 см";
				}

				// Generate a blue curve with circle symbols, and "My Curve 2" in the legend
				myPane.CurveList.Clear();
				LineItem myCurve = myPane.AddCurve("1 эталон", list1, Color.FromArgb(61, 68, 206),
										SymbolType.Circle);
				// Fill the area under the curve with a white-red gradient at 45 degrees
				myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
				// Make the symbols opaque by filling them with white
				myCurve.Symbol.Fill = new Fill(Color.White);

				// Fill the axis background with a color gradient
				myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(228, 227, 237), 45F);

				// Fill the pane background with a color gradient
				myPane.Fill = new Fill(Color.White);

				// Calculate the Axis Scale Ranges
				zgc.AxisChange();
				zgc.Refresh();





				return list12;
			
			
		}
		
			
		
	}
}
