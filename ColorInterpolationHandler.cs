using System.Runtime.CompilerServices;
using System.Text;

namespace ConsolePainter;
[InterpolatedStringHandler]
public readonly ref struct ColorInterpolationHandler
{
	private readonly StringBuilder _builder;
	public ColorInterpolationHandler(int literalLength, int formattedCount)
	{
		_builder = new(literalLength);
	}
	public void AppendLiteral(string literal)
	{
		_builder.Append(literal);
	}
	public void AppendFormatted<T>(T value)
	{
		if (value is ConsoleColor color)
		{
			_builder.Append(color.ToString().ToUpper());
			return;
		}
		_builder.Append(value?.ToString());
	}
	public override string ToString() => _builder.ToString();
}
