using System;
using System.Collections.Generic;

namespace PingPong.Providers.Contracts
{
	public interface IDisplayWritable
	{
		void SetCursorAt(int x, int y);
		void Write<T>(T msg);
		void WriteAt<T>(int x, int y, T msg);
		void WriteLine<T>(T msg);
		void WriteLine();
		void WriteLineAt<T>(int x, int y, T msg);
        /// <summary>
        /// Writes a whole buffer matrix at once. Use a dictionary to specify which symbols to color with what color.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="defaultColor"></param>
        /// <param name="symbolsToColor"></param>
		void WriteBufferMatrix(char[,] matrix, string defaultColor, Dictionary<char, string> symbolsToColor);
        /// <summary>
        /// Writes a whole buffer matrix at once until a condition is met.
        /// Use a dictionary to specify which symbols to color with what color.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="defaultColor"></param>
        /// <param name="symbolsToColor"></param>
        /// <param name="predicate"></param>
		void WriteBufferMatrixUntil(char[,] matrix, string defaultColor, Dictionary<char, string> symbolsToColor, Func<bool> predicate);
        /// <summary>
        /// Clears the whole windows.
        /// </summary>
		void Clear();
	}
}
