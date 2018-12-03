namespace PingPong.Providers.Display.Structures
{
	using System.Runtime.InteropServices;
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct CharInfo
	{
		[FieldOffset(0)] public char Char;
		[FieldOffset(2)] public short Attributes;
	}
}