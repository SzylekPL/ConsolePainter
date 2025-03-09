using System.Runtime.CompilerServices;

namespace ConsolePainter;

public static class ColoredConsole
{
	public static void Write(in ColorInterpolationHandler handler)
	{
		Console.Write(handler);
	}
	public static void WriteLine(in ColorInterpolationHandler handler)
	{
		Console.Write(handler.ToString() + '\n');
	}
}
