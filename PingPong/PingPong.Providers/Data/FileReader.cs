using PingPong.Providers.Contracts;
using System.IO;
using System;
namespace PingPong.Providers.Data
{
	public class FileReader : IDataReader
	{
		public const string DEFAULT_FILE_PATH = @"..\..\..\data.txt";
		public bool CheckIfItemExists(string item, string type)
		{
			string[] lines = File.ReadAllLines(DEFAULT_FILE_PATH);
			foreach (var line in lines)
				if ((item + " " + type).Equals(line))
					return true;
			return false;
		}

		public int TryReadCoins()
		{
			try
			{
				string[] coinLine = File.ReadAllLines(DEFAULT_FILE_PATH)[0].Trim().Split(' ');
				return Int32.Parse(coinLine[1]);
			}
			catch(Exception)
			{
				//log error
				return 0;
			}
		}
	}
}
