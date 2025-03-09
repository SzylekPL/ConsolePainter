using System.Runtime.CompilerServices;
using System.Text;

namespace ConsolePainter;
[InterpolatedStringHandler]
public readonly struct ColorInterpolationHandler(int literalLength, int formattedCount)
{
	private readonly StringBuilder _builder = new(literalLength);

	private static string GetAnsiColorCode(ConsoleColor color) => color switch
	{
		ConsoleColor.Black => "\u001b[30m",
		ConsoleColor.DarkBlue => "\u001b[34m",
		ConsoleColor.DarkGreen => "\u001b[32m",
		ConsoleColor.DarkCyan => "\u001b[36m",
		ConsoleColor.DarkRed => "\u001b[31m",
		ConsoleColor.DarkMagenta => "\u001b[35m",
		ConsoleColor.DarkYellow => "\u001b[33m",
		ConsoleColor.Gray => "\u001b[37m",
		ConsoleColor.DarkGray => "\u001b[90m",
		ConsoleColor.Blue => "\u001b[94m",
		ConsoleColor.Green => "\u001b[92m",
		ConsoleColor.Cyan => "\u001b[96m",
		ConsoleColor.Red => "\u001b[91m",
		ConsoleColor.Magenta => "\u001b[95m",
		ConsoleColor.Yellow => "\u001b[93m",
		ConsoleColor.White => "\u001b[97m",
		_ => "\u001b[97m"
	};

	public void AppendLiteral(string literal)
	{
		_builder.Append(literal);
	}
	public void AppendFormatted<T>(T value)
	{
		if (value is ConsoleColor color)
		{
			_builder.Append(GetAnsiColorCode(color));
			return;
		}
		_builder.Append(value?.ToString());
	}
	public override string ToString() => _builder.ToString();
}
