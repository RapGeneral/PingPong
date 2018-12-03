using PingPong.Providers.Contracts;
using System;
using System.IO;

namespace PingPong.Providers.Data
{
	public class FileWriter : IDataWriter
	{
		public const string DEFAULT_FILE_PATH = @"..\..\..\data.txt";
		public void AddNewItem(string item, string type)
		{
			if (File.Exists(DEFAULT_FILE_PATH))
			{
				using (StreamWriter w = File.AppendText(DEFAULT_FILE_PATH))
				{
					w.WriteLine(item + " " + type);
				}
			}
			//else log error
		}

		public void WriteCoins(int coins)
		{
			try
			{
				string[] lines = File.ReadAllLines(DEFAULT_FILE_PATH);
				lines[0] = $"coins {coins}";
				File.WriteAllLines(DEFAULT_FILE_PATH, lines);
			}
			catch (Exception)
			{
				//log error
			}
		}
	}
}
