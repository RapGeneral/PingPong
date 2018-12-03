namespace PingPong.Core.Menus.MenuChoices
{
	using PingPong.Core.Contracts;
	using PingPong.Providers.Contracts;
	using PingPong.Providers.Validation;

	public class MenuChoice : Choice
    {
        private const string NAME_TO_PRINT_NULL = "NameToPrint cannot be null!";
        public string[] NameToPrint { get; }
		public MenuChoice(int top, string[] nameToPrint, ICommandHolder commandHolder, IDisplay display) 
			: base(top, 
				  (display.WindowWidth - nameToPrint[0].Length) / 2 + (display.WindowWidth - nameToPrint[0].Length) % 2, 
				  commandHolder, 
				  nameToPrint.Length, 
				  display)
		{
			Validator.IfNull(nameToPrint, NAME_TO_PRINT_NULL);
			this.NameToPrint = nameToPrint;
		}
		public override void PrintChoice()
		{
			this.display.SetCursorAt(0, this.Top - (NameToPrint.Length - 1));
			for (int i = 0; i < NameToPrint.Length; i++)
				this.display.WriteLine(new string(' ', this.Left) + this.NameToPrint[i]);
		}
	}
}
