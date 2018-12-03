using Microsoft.Win32.SafeHandles;
using PingPong.Providers.Contracts;
using PingPong.Providers.Display.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace PingPong.Providers.Display
{
	public class ConsoleDisplay : IDisplay, IDisplayWritable, IDisplaySize, IDisplayColor
	{
		[DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		static extern SafeFileHandle CreateFile(
			string fileName,
			[MarshalAs(UnmanagedType.U4)] uint fileAccess,
			[MarshalAs(UnmanagedType.U4)] uint fileShare,
			IntPtr securityAttributes,
			[MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
			[MarshalAs(UnmanagedType.U4)] int flags,
			IntPtr template);

		[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		static extern bool WriteConsoleOutput(
		  SafeFileHandle hConsoleOutput,
		  CharInfo[] lpBuffer,
		  Coord dwBufferSize,
		  Coord dwBufferCoord,
		  ref SmallRect lpWriteRegion);

		private readonly SafeFileHandle h;
		private CharInfo[] buf;
		private SmallRect rect;

		public ConsoleDisplay()
		{
			h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
		}
		public int WindowWidth { get => Console.WindowWidth; set => Console.WindowWidth = value; }
		public int WindowHeight { get => Console.WindowHeight; set => Console.WindowHeight = value; }
		public int BufferHeight { get => Console.BufferHeight; set => Console.BufferHeight = value; }
		public bool CursorVisible { get => Console.CursorVisible; set => Console.CursorVisible = value; }

		public void ChangeBackgroundColor(string color)
		{
			Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
		}

		public void ChangeBufferSize(int x, int y)
		{
			Console.SetBufferSize(x, y);
		}

		public void ChangeForegroundColor(string color)
		{
			Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
		}

		public void ChangeSize(int x, int y)
		{
			Console.SetWindowSize(x, y);
		}

		public void Clear()
		{
			Console.Clear();
		}

		public void ResetColor()
		{
			Console.ResetColor();
		}

		public void SetCursorAt(int x, int y)
		{
			Console.SetCursorPosition(x, y);
		}

		public void SetOutputEncodingToUTF8()
		{
			Console.OutputEncoding = Encoding.UTF8;
		}

		public void Write<T>(T msg)
		{
			Console.Write(msg);
		}

		public void WriteAt<T>(int x, int y, T msg)
		{
			Console.SetCursorPosition(x, y);
			Console.Write(msg);
		}
		public void WriteBufferMatrix(char[,] matrix, string defaultColor, Dictionary<char, string> symbolsToColor)
		{
			buf = new CharInfo[matrix.GetLength(1) * matrix.GetLength(0)];
			rect = new SmallRect() { Left = 0, Top = 0, Right = (short)(matrix.GetLength(1)), Bottom = (short)(matrix.GetLength(0)) };
			this.WriteBuffer(matrix, defaultColor, symbolsToColor);
		}
		private void WriteBuffer(char[,] matrix, string defaultColor, Dictionary<char, string> symbolsToColor)
		{
			if (h.IsInvalid)
				throw new ArgumentNullException("The safe file handle is invalid!");
			int br = 0;
			for (int i = 0; i < matrix.GetLength(0); i++)
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (symbolsToColor.ContainsKey(matrix[i, j]))
						buf[br].Attributes = (short)(int)Enum.Parse(typeof(ConsoleColor), symbolsToColor.GetValueOrDefault(matrix[i, j]), true);
					else
						buf[br].Attributes = (short)(int)Enum.Parse(typeof(ConsoleColor), defaultColor, true);
					buf[br].Char = matrix[i, j];
					br++;
				}
			bool b = WriteConsoleOutput(h, buf,
			  new Coord() { X = (short)matrix.GetLength(1), Y = (short)matrix.GetLength(0) },
			  new Coord() { X = 0, Y = 0 },
			  ref rect);
		}
		public void WriteBufferMatrixUntil(char[,] matrix, string defaultColor, Dictionary<char, string> symbolsToColor, Func<bool> predicate)
		{
			buf = new CharInfo[matrix.GetLength(1) * matrix.GetLength(0)];
			rect = new SmallRect() { Left = 0, Top = 0, Right = (short)(matrix.GetLength(1)), Bottom = (short)(matrix.GetLength(0)) };

			while (predicate())
				this.WriteBuffer(matrix, defaultColor, symbolsToColor);
		}
		public void WriteLine<T>(T msg)
		{
			Console.WriteLine(msg);
		}

		public void WriteLine()
		{
			Console.WriteLine();
		}

		public void WriteLineAt<T>(int x, int y, T msg)
		{
			Console.SetCursorPosition(x, y);
			Console.WriteLine(msg);
		}
	}
}
