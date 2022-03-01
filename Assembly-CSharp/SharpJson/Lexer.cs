using System;
using System.Globalization;
using System.Text;

namespace SharpJson
{
	// Token: 0x020049C7 RID: 18887
	internal class Lexer
	{
		// Token: 0x0601B30B RID: 111371 RVA: 0x0085A8A6 File Offset: 0x00858CA6
		public Lexer(string text)
		{
			this.Reset();
			this.json = text.ToCharArray();
			this.parseNumbersAsFloat = false;
		}

		// Token: 0x17002393 RID: 9107
		// (get) Token: 0x0601B30C RID: 111372 RVA: 0x0085A8DE File Offset: 0x00858CDE
		public bool hasError
		{
			get
			{
				return !this.success;
			}
		}

		// Token: 0x17002394 RID: 9108
		// (get) Token: 0x0601B30D RID: 111373 RVA: 0x0085A8E9 File Offset: 0x00858CE9
		// (set) Token: 0x0601B30E RID: 111374 RVA: 0x0085A8F1 File Offset: 0x00858CF1
		public int lineNumber { get; private set; }

		// Token: 0x17002395 RID: 9109
		// (get) Token: 0x0601B30F RID: 111375 RVA: 0x0085A8FA File Offset: 0x00858CFA
		// (set) Token: 0x0601B310 RID: 111376 RVA: 0x0085A902 File Offset: 0x00858D02
		public bool parseNumbersAsFloat { get; set; }

		// Token: 0x0601B311 RID: 111377 RVA: 0x0085A90B File Offset: 0x00858D0B
		public void Reset()
		{
			this.index = 0;
			this.lineNumber = 1;
			this.success = true;
		}

		// Token: 0x0601B312 RID: 111378 RVA: 0x0085A924 File Offset: 0x00858D24
		public string ParseString()
		{
			int num = 0;
			StringBuilder stringBuilder = null;
			this.SkipWhiteSpaces();
			char c = this.json[this.index++];
			bool flag = false;
			bool flag2 = false;
			while (!flag2 && !flag)
			{
				if (this.index == this.json.Length)
				{
					break;
				}
				c = this.json[this.index++];
				if (c == '"')
				{
					flag2 = true;
					break;
				}
				if (c == '\\')
				{
					if (this.index == this.json.Length)
					{
						break;
					}
					c = this.json[this.index++];
					switch (c)
					{
					case 'r':
						this.stringBuffer[num++] = '\r';
						break;
					default:
						if (c != '"')
						{
							if (c != '/')
							{
								if (c != '\\')
								{
									if (c != 'b')
									{
										if (c != 'f')
										{
											if (c == 'n')
											{
												this.stringBuffer[num++] = '\n';
											}
										}
										else
										{
											this.stringBuffer[num++] = '\f';
										}
									}
									else
									{
										this.stringBuffer[num++] = '\b';
									}
								}
								else
								{
									this.stringBuffer[num++] = '\\';
								}
							}
							else
							{
								this.stringBuffer[num++] = '/';
							}
						}
						else
						{
							this.stringBuffer[num++] = '"';
						}
						break;
					case 't':
						this.stringBuffer[num++] = '\t';
						break;
					case 'u':
					{
						int num2 = this.json.Length - this.index;
						if (num2 >= 4)
						{
							string value = new string(this.json, this.index, 4);
							this.stringBuffer[num++] = (char)Convert.ToInt32(value, 16);
							this.index += 4;
						}
						else
						{
							flag = true;
						}
						break;
					}
					}
				}
				else
				{
					this.stringBuffer[num++] = c;
				}
				if (num >= this.stringBuffer.Length)
				{
					if (stringBuilder == null)
					{
						stringBuilder = new StringBuilder();
					}
					stringBuilder.Append(this.stringBuffer, 0, num);
					num = 0;
				}
			}
			if (!flag2)
			{
				this.success = false;
				return null;
			}
			if (stringBuilder != null)
			{
				return stringBuilder.ToString();
			}
			return new string(this.stringBuffer, 0, num);
		}

		// Token: 0x0601B313 RID: 111379 RVA: 0x0085AB94 File Offset: 0x00858F94
		private string GetNumberString()
		{
			this.SkipWhiteSpaces();
			int lastIndexOfNumber = this.GetLastIndexOfNumber(this.index);
			int length = lastIndexOfNumber - this.index + 1;
			string result = new string(this.json, this.index, length);
			this.index = lastIndexOfNumber + 1;
			return result;
		}

		// Token: 0x0601B314 RID: 111380 RVA: 0x0085ABDC File Offset: 0x00858FDC
		public float ParseFloatNumber()
		{
			string numberString = this.GetNumberString();
			float result;
			if (!float.TryParse(numberString, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
			{
				return 0f;
			}
			return result;
		}

		// Token: 0x0601B315 RID: 111381 RVA: 0x0085AC10 File Offset: 0x00859010
		public double ParseDoubleNumber()
		{
			string numberString = this.GetNumberString();
			double result;
			if (!double.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
			{
				return 0.0;
			}
			return result;
		}

		// Token: 0x0601B316 RID: 111382 RVA: 0x0085AC48 File Offset: 0x00859048
		private int GetLastIndexOfNumber(int index)
		{
			int i;
			for (i = index; i < this.json.Length; i++)
			{
				char c = this.json[i];
				if ((c < '0' || c > '9') && c != '+' && c != '-' && c != '.' && c != 'e' && c != 'E')
				{
					break;
				}
			}
			return i - 1;
		}

		// Token: 0x0601B317 RID: 111383 RVA: 0x0085ACB8 File Offset: 0x008590B8
		private void SkipWhiteSpaces()
		{
			while (this.index < this.json.Length)
			{
				char c = this.json[this.index];
				if (c == '\n')
				{
					this.lineNumber++;
				}
				if (!char.IsWhiteSpace(this.json[this.index]))
				{
					break;
				}
				this.index++;
			}
		}

		// Token: 0x0601B318 RID: 111384 RVA: 0x0085AD2C File Offset: 0x0085912C
		public Lexer.Token LookAhead()
		{
			this.SkipWhiteSpaces();
			int num = this.index;
			return Lexer.NextToken(this.json, ref num);
		}

		// Token: 0x0601B319 RID: 111385 RVA: 0x0085AD53 File Offset: 0x00859153
		public Lexer.Token NextToken()
		{
			this.SkipWhiteSpaces();
			return Lexer.NextToken(this.json, ref this.index);
		}

		// Token: 0x0601B31A RID: 111386 RVA: 0x0085AD6C File Offset: 0x0085916C
		private static Lexer.Token NextToken(char[] json, ref int index)
		{
			if (index == json.Length)
			{
				return Lexer.Token.None;
			}
			char c = json[index++];
			switch (c)
			{
			case ',':
				return Lexer.Token.Comma;
			case '-':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				return Lexer.Token.Number;
			default:
				switch (c)
				{
				case '[':
					return Lexer.Token.SquaredOpen;
				default:
					switch (c)
					{
					case '{':
						return Lexer.Token.CurlyOpen;
					default:
					{
						if (c == '"')
						{
							return Lexer.Token.String;
						}
						index--;
						int num = json.Length - index;
						if (num >= 5 && json[index] == 'f' && json[index + 1] == 'a' && json[index + 2] == 'l' && json[index + 3] == 's' && json[index + 4] == 'e')
						{
							index += 5;
							return Lexer.Token.False;
						}
						if (num >= 4 && json[index] == 't' && json[index + 1] == 'r' && json[index + 2] == 'u' && json[index + 3] == 'e')
						{
							index += 4;
							return Lexer.Token.True;
						}
						if (num >= 4 && json[index] == 'n' && json[index + 1] == 'u' && json[index + 2] == 'l' && json[index + 3] == 'l')
						{
							index += 4;
							return Lexer.Token.Null;
						}
						return Lexer.Token.None;
					}
					case '}':
						return Lexer.Token.CurlyClose;
					}
					break;
				case ']':
					return Lexer.Token.SquaredClose;
				}
				break;
			case ':':
				return Lexer.Token.Colon;
			}
		}

		// Token: 0x04012F3A RID: 77626
		private char[] json;

		// Token: 0x04012F3B RID: 77627
		private int index;

		// Token: 0x04012F3C RID: 77628
		private bool success = true;

		// Token: 0x04012F3D RID: 77629
		private char[] stringBuffer = new char[4096];

		// Token: 0x020049C8 RID: 18888
		public enum Token
		{
			// Token: 0x04012F3F RID: 77631
			None,
			// Token: 0x04012F40 RID: 77632
			Null,
			// Token: 0x04012F41 RID: 77633
			True,
			// Token: 0x04012F42 RID: 77634
			False,
			// Token: 0x04012F43 RID: 77635
			Colon,
			// Token: 0x04012F44 RID: 77636
			Comma,
			// Token: 0x04012F45 RID: 77637
			String,
			// Token: 0x04012F46 RID: 77638
			Number,
			// Token: 0x04012F47 RID: 77639
			CurlyOpen,
			// Token: 0x04012F48 RID: 77640
			CurlyClose,
			// Token: 0x04012F49 RID: 77641
			SquaredOpen,
			// Token: 0x04012F4A RID: 77642
			SquaredClose
		}
	}
}
