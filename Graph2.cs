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
    public class Graph2
    {
		/// <summary>
		/// график для двух эталонов 
		/// </summary>
		/// <param name="zgc"></param>
		/// <param name="ap"></param>

		public List<Points2> CreateGraph2(ZedGraphControl zgc, AllParam ap, List<Points> inputlist12)
		{
			GraphPane myPane = zgc.GraphPane;

			// Set the titles and axis labels
			myPane.Title.Text = "My Test Graph";
			//myPane.XAxis.Title.Text = "Длина волны, нМ";
			myPane.YAxis.Title.Text = "Интенсивность, у.е.";

			// Make up some data points from the Sine function





			double t2;
			double r2;
			double etalon2;
			double wave1;
			double n2;
			double fromLym;
			double toLym;
			double stapGet;
			int dt2;

			// взятие параметров из AllParam
			r2 = Convert.ToDouble(ap.Otr2.Replace(".", ",")); // коэф отражения
			t2 = 1 - r2;   
			n2 = Convert.ToDouble(ap.Prel2.Replace(".", ","));
			dt2 = ap.Dt2;
			/*	t1 = 0.18;
				r1 = 0.78;
				n1 = 2.44;*/

			wave1 = Convert.ToDouble(ap.Wave.Replace(".", ","));
			etalon2 = Convert.ToDouble(ap.Etal2.Replace(".", ",")) * 1000000 + dt2;
			fromLym = Convert.ToDouble(ap.FromLym.Replace(".", ","));
			toLym = Convert.ToDouble(ap.ToLym.Replace(".", ","));
			stapGet = Convert.ToDouble(ap.Staps) / 10000;
			




			/*
			 * n - показатель преломления
			 * r - коэф отражения
			 * t - коэф пропускания
			 * 
			 */



			double dlym2 = (wave1 * wave1) / (2 * etalon2 * n2); //расстояние между спектральными максимумами 
			

			PointPairList list2 = new PointPairList();
			List<Points2> list23 = new List<Points2>();
			int i = 0;
			//double dwave1 = wave1 * 0.001;
			

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

				for (double x = wave1 - dwave1; x <= wave1 + dwave2; x += stap)
				{

					double undcos = (2 * Math.PI / x) * 2 * etalon2 * n2;
					double y = inputlist12[i].y12 * (Math.Pow(t2, 2) / (1 + Math.Pow(r2, 4) - 2 * Math.Pow(r2, 2) * Math.Cos(undcos)));
					Points2 p23 = new Points2();
					p23.x23 = x;
					p23.y23 = y;
					list23.Add(p23);
					list2.Add(x, y);
					i++;
				}
				myPane.XAxis.Title.Text = "Длина волны, нМ";
			}
			//list2.RemoveAll(PointPairList list2.Min<double>());
			//double max = PointPairList.list2.Max<int>(i);
			//double x = (2 * Math.PI) / (wave1 + 2); x <= (2 * Math.PI) / (wave1 - 2); x += 0.00000001


			//if (ap1.Indicator == 0)
			if (ap.Indicator == 0)
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
					i = 0;
					double undcos = (2 * Math.PI * x) * 2 * etalon2 * n2;
					double y = (inputlist12[i].y12) * (Math.Pow(t2, 2) / (1 + Math.Pow(r2, 4) - 2 * Math.Pow(r2, 2) * Math.Cos(undcos)));
					
					Points2 p23 = new Points2();
					p23.x23 = x;
					p23.y23 = y;
					list23.Add(p23);
					list2.Add(x, y);
				}
				myPane.XAxis.Title.Text = "Волновые числа, -1 см";
			}



			// Generate a blue curve with circle symbols, and "My Curve 2" in the legend
			myPane.CurveList.Clear();
			LineItem myCurve = myPane.AddCurve("2 эталона", list2, Color.Blue,
									SymbolType.Circle);
			
			// Fill the area under the curve with a white-red gradient at 45 degrees
			myCurve.Line.Fill = new Fill(Color.White, Color.Green, 45F);
			// Make the symbols opaque by filling them with white
			myCurve.Symbol.Fill = new Fill(Color.White);

			// Fill the axis background with a color gradient
			myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(228, 227, 237), 45F);

			// Fill the pane background with a color gradient
			myPane.Fill = new Fill(Color.White);

			// Calculate the Axis Scale Ranges
			zgc.AxisChange();
			zgc.Refresh();
			return list23;
			
		}
	}
}
