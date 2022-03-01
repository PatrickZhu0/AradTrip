using System;
using System.Reflection;
using System.Text;
using UnityEngine.UI;

// Token: 0x0200154F RID: 5455
public class SpeedString
{
	// Token: 0x0600D536 RID: 54582 RVA: 0x00354F60 File Offset: 0x00353360
	public SpeedString(int capacity)
	{
		this.string_builder = new StringBuilder(capacity, capacity);
		this.string_base = (string)this.string_builder.GetType().GetField("_str", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this.string_builder);
	}

	// Token: 0x0600D537 RID: 54583 RVA: 0x00354FBC File Offset: 0x003533BC
	public void Clear()
	{
		this.string_builder.Length = 0;
		this.i = 0;
		while (this.i < this.string_builder.Capacity)
		{
			this.string_builder.Append(' ');
			this.i++;
		}
		this.string_builder.Length = 0;
	}

	// Token: 0x0600D538 RID: 54584 RVA: 0x0035501F File Offset: 0x0035341F
	public void Draw(ref Text text)
	{
		text.text = string.Empty;
		text.text = this.string_base;
		text.cachedTextGenerator.Invalidate();
	}

	// Token: 0x0600D539 RID: 54585 RVA: 0x00355046 File Offset: 0x00353446
	public void Append(string value)
	{
		this.string_builder.Append(value);
	}

	// Token: 0x0600D53A RID: 54586 RVA: 0x00355058 File Offset: 0x00353458
	public void Append(int value)
	{
		if (value >= 0)
		{
			this.count = SpeedString.ToCharArray((uint)value, this.int_parser, 0);
		}
		else
		{
			this.int_parser[0] = '-';
			this.count = SpeedString.ToCharArray((uint)(-(uint)value), this.int_parser, 1) + 1;
		}
		this.i = 0;
		while (this.i < this.count)
		{
			this.string_builder.Append(this.int_parser[this.i]);
			this.i++;
		}
	}

	// Token: 0x0600D53B RID: 54587 RVA: 0x003550E8 File Offset: 0x003534E8
	private static int ToCharArray(uint value, char[] buffer, int bufferIndex)
	{
		if (value == 0U)
		{
			buffer[bufferIndex] = '0';
			return 1;
		}
		int num = 1;
		for (uint num2 = value / 10U; num2 > 0U; num2 /= 10U)
		{
			num++;
		}
		for (int i = num - 1; i >= 0; i--)
		{
			buffer[bufferIndex + i] = (char)(48U + value % 10U);
			value /= 10U;
		}
		return num;
	}

	// Token: 0x04007D35 RID: 32053
	public string string_base;

	// Token: 0x04007D36 RID: 32054
	public StringBuilder string_builder;

	// Token: 0x04007D37 RID: 32055
	private char[] int_parser = new char[11];

	// Token: 0x04007D38 RID: 32056
	private int i;

	// Token: 0x04007D39 RID: 32057
	private int count;
}
