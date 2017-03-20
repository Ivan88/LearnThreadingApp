using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearnThreadingApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var counter = new Counter(6, 4);
			var thread = new Thread(counter.Count);
			thread.Start();
			Console.Read();
		}

		static void StartFirstThread()
		{
			var firstThread = new Thread(new ParameterizedThreadStart(Count));
			firstThread.Start(4);

			firstThread.Priority = ThreadPriority.Highest;

			for (int i = 1; i < 9; i++)
			{
				Console.WriteLine("Главный поток:");
				Console.WriteLine(i * i);
				Thread.Sleep(400);
			}

			Console.ReadLine();
		}

		static void Count(object x)
		{
			var c = (int)x;
			for (int i = 1; i < c; i++)
			{
				Console.WriteLine("Второй поток:");
				Console.WriteLine(i * i);
				Thread.Sleep(300);
			}
		}

		static void ShowThreadInfo()
		{
			// получаем текущий поток
			var t = Thread.CurrentThread;

			//получаем имя потока
			Console.WriteLine("Имя потока: {0}", t.Name);
			t.Name = "Метод Main";
			Console.WriteLine("Имя потока: {0}", t.Name);

			Console.WriteLine("Запущен ли поток: {0}", t.IsAlive);
			Console.WriteLine("Приоритет потока: {0}", t.Priority);
			Console.WriteLine("Статус потока: {0}", t.ThreadState);

			// получаем домен приложения
			Console.WriteLine("Домен приложения: {0}", Thread.GetDomain().FriendlyName);

			Console.ReadLine();
		}

		public class Counter
		{
			private int x;
			private int y;
			public Counter(int x, int y)
			{
				this.x = x;
				this.y = y;
			}

			public void Count()
			{
				for (int i = 0; i < 9; i++)
				{
					Console.WriteLine(x * y);
					Thread.Sleep(500);
				}
			}
		}
	}
}
