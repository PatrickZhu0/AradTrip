using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace LitJson
{
	// Token: 0x020046AD RID: 18093
	internal class Lexer
	{
		// Token: 0x06019A0B RID: 104971 RVA: 0x00811961 File Offset: 0x0080FD61
		static Lexer()
		{
			Lexer.PopulateFsmTables();
		}

		// Token: 0x06019A0C RID: 104972 RVA: 0x00811968 File Offset: 0x0080FD68
		public Lexer(TextReader reader)
		{
			this.allow_comments = true;
			this.allow_single_quoted_strings = true;
			this.input_buffer = 0;
			this.string_buffer = new StringBuilder(128);
			this.state = 1;
			this.end_of_input = false;
			this.reader = reader;
			this.fsm_context = new FsmContext();
			this.fsm_context.L = this;
		}

		// Token: 0x1700212B RID: 8491
		// (get) Token: 0x06019A0D RID: 104973 RVA: 0x008119CC File Offset: 0x0080FDCC
		// (set) Token: 0x06019A0E RID: 104974 RVA: 0x008119D4 File Offset: 0x0080FDD4
		public bool AllowComments
		{
			get
			{
				return this.allow_comments;
			}
			set
			{
				this.allow_comments = value;
			}
		}

		// Token: 0x1700212C RID: 8492
		// (get) Token: 0x06019A0F RID: 104975 RVA: 0x008119DD File Offset: 0x0080FDDD
		// (set) Token: 0x06019A10 RID: 104976 RVA: 0x008119E5 File Offset: 0x0080FDE5
		public bool AllowSingleQuotedStrings
		{
			get
			{
				return this.allow_single_quoted_strings;
			}
			set
			{
				this.allow_single_quoted_strings = value;
			}
		}

		// Token: 0x1700212D RID: 8493
		// (get) Token: 0x06019A11 RID: 104977 RVA: 0x008119EE File Offset: 0x0080FDEE
		public bool EndOfInput
		{
			get
			{
				return this.end_of_input;
			}
		}

		// Token: 0x1700212E RID: 8494
		// (get) Token: 0x06019A12 RID: 104978 RVA: 0x008119F6 File Offset: 0x0080FDF6
		public int Token
		{
			get
			{
				return this.token;
			}
		}

		// Token: 0x1700212F RID: 8495
		// (get) Token: 0x06019A13 RID: 104979 RVA: 0x008119FE File Offset: 0x0080FDFE
		public string StringValue
		{
			get
			{
				return this.string_value;
			}
		}

		// Token: 0x06019A14 RID: 104980 RVA: 0x00811A08 File Offset: 0x0080FE08
		private static int HexValue(int digit)
		{
			switch (digit)
			{
			case 65:
				break;
			case 66:
				return 11;
			case 67:
				return 12;
			case 68:
				return 13;
			case 69:
				return 14;
			case 70:
				return 15;
			default:
				switch (digit)
				{
				case 97:
					break;
				case 98:
					return 11;
				case 99:
					return 12;
				case 100:
					return 13;
				case 101:
					return 14;
				case 102:
					return 15;
				default:
					return digit - 48;
				}
				break;
			}
			return 10;
		}

		// Token: 0x06019A15 RID: 104981 RVA: 0x00811A74 File Offset: 0x0080FE74
		private static void PopulateFsmTables()
		{
			Lexer.StateHandler[] array = new Lexer.StateHandler[28];
			int num = 0;
			if (Lexer.<>f__mg$cache0 == null)
			{
				Lexer.<>f__mg$cache0 = new Lexer.StateHandler(Lexer.State1);
			}
			array[num] = Lexer.<>f__mg$cache0;
			int num2 = 1;
			if (Lexer.<>f__mg$cache1 == null)
			{
				Lexer.<>f__mg$cache1 = new Lexer.StateHandler(Lexer.State2);
			}
			array[num2] = Lexer.<>f__mg$cache1;
			int num3 = 2;
			if (Lexer.<>f__mg$cache2 == null)
			{
				Lexer.<>f__mg$cache2 = new Lexer.StateHandler(Lexer.State3);
			}
			array[num3] = Lexer.<>f__mg$cache2;
			int num4 = 3;
			if (Lexer.<>f__mg$cache3 == null)
			{
				Lexer.<>f__mg$cache3 = new Lexer.StateHandler(Lexer.State4);
			}
			array[num4] = Lexer.<>f__mg$cache3;
			int num5 = 4;
			if (Lexer.<>f__mg$cache4 == null)
			{
				Lexer.<>f__mg$cache4 = new Lexer.StateHandler(Lexer.State5);
			}
			array[num5] = Lexer.<>f__mg$cache4;
			int num6 = 5;
			if (Lexer.<>f__mg$cache5 == null)
			{
				Lexer.<>f__mg$cache5 = new Lexer.StateHandler(Lexer.State6);
			}
			array[num6] = Lexer.<>f__mg$cache5;
			int num7 = 6;
			if (Lexer.<>f__mg$cache6 == null)
			{
				Lexer.<>f__mg$cache6 = new Lexer.StateHandler(Lexer.State7);
			}
			array[num7] = Lexer.<>f__mg$cache6;
			int num8 = 7;
			if (Lexer.<>f__mg$cache7 == null)
			{
				Lexer.<>f__mg$cache7 = new Lexer.StateHandler(Lexer.State8);
			}
			array[num8] = Lexer.<>f__mg$cache7;
			int num9 = 8;
			if (Lexer.<>f__mg$cache8 == null)
			{
				Lexer.<>f__mg$cache8 = new Lexer.StateHandler(Lexer.State9);
			}
			array[num9] = Lexer.<>f__mg$cache8;
			int num10 = 9;
			if (Lexer.<>f__mg$cache9 == null)
			{
				Lexer.<>f__mg$cache9 = new Lexer.StateHandler(Lexer.State10);
			}
			array[num10] = Lexer.<>f__mg$cache9;
			int num11 = 10;
			if (Lexer.<>f__mg$cacheA == null)
			{
				Lexer.<>f__mg$cacheA = new Lexer.StateHandler(Lexer.State11);
			}
			array[num11] = Lexer.<>f__mg$cacheA;
			int num12 = 11;
			if (Lexer.<>f__mg$cacheB == null)
			{
				Lexer.<>f__mg$cacheB = new Lexer.StateHandler(Lexer.State12);
			}
			array[num12] = Lexer.<>f__mg$cacheB;
			int num13 = 12;
			if (Lexer.<>f__mg$cacheC == null)
			{
				Lexer.<>f__mg$cacheC = new Lexer.StateHandler(Lexer.State13);
			}
			array[num13] = Lexer.<>f__mg$cacheC;
			int num14 = 13;
			if (Lexer.<>f__mg$cacheD == null)
			{
				Lexer.<>f__mg$cacheD = new Lexer.StateHandler(Lexer.State14);
			}
			array[num14] = Lexer.<>f__mg$cacheD;
			int num15 = 14;
			if (Lexer.<>f__mg$cacheE == null)
			{
				Lexer.<>f__mg$cacheE = new Lexer.StateHandler(Lexer.State15);
			}
			array[num15] = Lexer.<>f__mg$cacheE;
			int num16 = 15;
			if (Lexer.<>f__mg$cacheF == null)
			{
				Lexer.<>f__mg$cacheF = new Lexer.StateHandler(Lexer.State16);
			}
			array[num16] = Lexer.<>f__mg$cacheF;
			int num17 = 16;
			if (Lexer.<>f__mg$cache10 == null)
			{
				Lexer.<>f__mg$cache10 = new Lexer.StateHandler(Lexer.State17);
			}
			array[num17] = Lexer.<>f__mg$cache10;
			int num18 = 17;
			if (Lexer.<>f__mg$cache11 == null)
			{
				Lexer.<>f__mg$cache11 = new Lexer.StateHandler(Lexer.State18);
			}
			array[num18] = Lexer.<>f__mg$cache11;
			int num19 = 18;
			if (Lexer.<>f__mg$cache12 == null)
			{
				Lexer.<>f__mg$cache12 = new Lexer.StateHandler(Lexer.State19);
			}
			array[num19] = Lexer.<>f__mg$cache12;
			int num20 = 19;
			if (Lexer.<>f__mg$cache13 == null)
			{
				Lexer.<>f__mg$cache13 = new Lexer.StateHandler(Lexer.State20);
			}
			array[num20] = Lexer.<>f__mg$cache13;
			int num21 = 20;
			if (Lexer.<>f__mg$cache14 == null)
			{
				Lexer.<>f__mg$cache14 = new Lexer.StateHandler(Lexer.State21);
			}
			array[num21] = Lexer.<>f__mg$cache14;
			int num22 = 21;
			if (Lexer.<>f__mg$cache15 == null)
			{
				Lexer.<>f__mg$cache15 = new Lexer.StateHandler(Lexer.State22);
			}
			array[num22] = Lexer.<>f__mg$cache15;
			int num23 = 22;
			if (Lexer.<>f__mg$cache16 == null)
			{
				Lexer.<>f__mg$cache16 = new Lexer.StateHandler(Lexer.State23);
			}
			array[num23] = Lexer.<>f__mg$cache16;
			int num24 = 23;
			if (Lexer.<>f__mg$cache17 == null)
			{
				Lexer.<>f__mg$cache17 = new Lexer.StateHandler(Lexer.State24);
			}
			array[num24] = Lexer.<>f__mg$cache17;
			int num25 = 24;
			if (Lexer.<>f__mg$cache18 == null)
			{
				Lexer.<>f__mg$cache18 = new Lexer.StateHandler(Lexer.State25);
			}
			array[num25] = Lexer.<>f__mg$cache18;
			int num26 = 25;
			if (Lexer.<>f__mg$cache19 == null)
			{
				Lexer.<>f__mg$cache19 = new Lexer.StateHandler(Lexer.State26);
			}
			array[num26] = Lexer.<>f__mg$cache19;
			int num27 = 26;
			if (Lexer.<>f__mg$cache1A == null)
			{
				Lexer.<>f__mg$cache1A = new Lexer.StateHandler(Lexer.State27);
			}
			array[num27] = Lexer.<>f__mg$cache1A;
			int num28 = 27;
			if (Lexer.<>f__mg$cache1B == null)
			{
				Lexer.<>f__mg$cache1B = new Lexer.StateHandler(Lexer.State28);
			}
			array[num28] = Lexer.<>f__mg$cache1B;
			Lexer.fsm_handler_table = array;
			Lexer.fsm_return_table = new int[]
			{
				65542,
				0,
				65537,
				65537,
				0,
				65537,
				0,
				65537,
				0,
				0,
				65538,
				0,
				0,
				0,
				65539,
				0,
				0,
				65540,
				65541,
				65542,
				0,
				0,
				65541,
				65542,
				0,
				0,
				0,
				0
			};
		}

		// Token: 0x06019A16 RID: 104982 RVA: 0x00811E38 File Offset: 0x00810238
		private static char ProcessEscChar(int esc_char)
		{
			switch (esc_char)
			{
			case 114:
				return '\r';
			default:
				if (esc_char == 34 || esc_char == 39 || esc_char == 47 || esc_char == 92)
				{
					return Convert.ToChar(esc_char);
				}
				if (esc_char == 98)
				{
					return '\b';
				}
				if (esc_char == 102)
				{
					return '\f';
				}
				if (esc_char != 110)
				{
					return '?';
				}
				return '\n';
			case 116:
				return '\t';
			}
		}

		// Token: 0x06019A17 RID: 104983 RVA: 0x00811EB0 File Offset: 0x008102B0
		private static bool State1(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				if (ctx.L.input_char != 32 && (ctx.L.input_char < 9 || ctx.L.input_char > 13))
				{
					if (ctx.L.input_char >= 49 && ctx.L.input_char <= 57)
					{
						ctx.L.string_buffer.Append((char)ctx.L.input_char);
						ctx.NextState = 3;
						return true;
					}
					int num = ctx.L.input_char;
					switch (num)
					{
					case 44:
						break;
					case 45:
						ctx.L.string_buffer.Append((char)ctx.L.input_char);
						ctx.NextState = 2;
						return true;
					default:
						switch (num)
						{
						case 91:
						case 93:
							break;
						default:
							switch (num)
							{
							case 123:
							case 125:
								break;
							default:
								if (num == 34)
								{
									ctx.NextState = 19;
									ctx.Return = true;
									return true;
								}
								if (num != 39)
								{
									if (num != 58)
									{
										if (num == 102)
										{
											ctx.NextState = 12;
											return true;
										}
										if (num == 110)
										{
											ctx.NextState = 16;
											return true;
										}
										if (num != 116)
										{
											return false;
										}
										ctx.NextState = 9;
										return true;
									}
								}
								else
								{
									if (!ctx.L.allow_single_quoted_strings)
									{
										return false;
									}
									ctx.L.input_char = 34;
									ctx.NextState = 23;
									ctx.Return = true;
									return true;
								}
								break;
							}
							break;
						}
						break;
					case 47:
						if (!ctx.L.allow_comments)
						{
							return false;
						}
						ctx.NextState = 25;
						return true;
					case 48:
						ctx.L.string_buffer.Append((char)ctx.L.input_char);
						ctx.NextState = 4;
						return true;
					}
					ctx.NextState = 1;
					ctx.Return = true;
					return true;
				}
			}
			return true;
		}

		// Token: 0x06019A18 RID: 104984 RVA: 0x008120BC File Offset: 0x008104BC
		private static bool State2(FsmContext ctx)
		{
			ctx.L.GetChar();
			if (ctx.L.input_char >= 49 && ctx.L.input_char <= 57)
			{
				ctx.L.string_buffer.Append((char)ctx.L.input_char);
				ctx.NextState = 3;
				return true;
			}
			int num = ctx.L.input_char;
			if (num != 48)
			{
				return false;
			}
			ctx.L.string_buffer.Append((char)ctx.L.input_char);
			ctx.NextState = 4;
			return true;
		}

		// Token: 0x06019A19 RID: 104985 RVA: 0x00812160 File Offset: 0x00810560
		private static bool State3(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				if (ctx.L.input_char >= 48 && ctx.L.input_char <= 57)
				{
					ctx.L.string_buffer.Append((char)ctx.L.input_char);
				}
				else
				{
					if (ctx.L.input_char == 32 || (ctx.L.input_char >= 9 && ctx.L.input_char <= 13))
					{
						ctx.Return = true;
						ctx.NextState = 1;
						return true;
					}
					int num = ctx.L.input_char;
					switch (num)
					{
					case 44:
						break;
					default:
						if (num != 69)
						{
							if (num == 93)
							{
								break;
							}
							if (num != 101)
							{
								if (num != 125)
								{
									return false;
								}
								break;
							}
						}
						ctx.L.string_buffer.Append((char)ctx.L.input_char);
						ctx.NextState = 7;
						return true;
					case 46:
						ctx.L.string_buffer.Append((char)ctx.L.input_char);
						ctx.NextState = 5;
						return true;
					}
					ctx.L.UngetChar();
					ctx.Return = true;
					ctx.NextState = 1;
					return true;
				}
			}
			return true;
		}

		// Token: 0x06019A1A RID: 104986 RVA: 0x008122C0 File Offset: 0x008106C0
		private static bool State4(FsmContext ctx)
		{
			ctx.L.GetChar();
			if (ctx.L.input_char == 32 || (ctx.L.input_char >= 9 && ctx.L.input_char <= 13))
			{
				ctx.Return = true;
				ctx.NextState = 1;
				return true;
			}
			int num = ctx.L.input_char;
			switch (num)
			{
			case 44:
				break;
			default:
				if (num != 69)
				{
					if (num == 93)
					{
						break;
					}
					if (num != 101)
					{
						if (num != 125)
						{
							return false;
						}
						break;
					}
				}
				ctx.L.string_buffer.Append((char)ctx.L.input_char);
				ctx.NextState = 7;
				return true;
			case 46:
				ctx.L.string_buffer.Append((char)ctx.L.input_char);
				ctx.NextState = 5;
				return true;
			}
			ctx.L.UngetChar();
			ctx.Return = true;
			ctx.NextState = 1;
			return true;
		}

		// Token: 0x06019A1B RID: 104987 RVA: 0x008123D0 File Offset: 0x008107D0
		private static bool State5(FsmContext ctx)
		{
			ctx.L.GetChar();
			if (ctx.L.input_char >= 48 && ctx.L.input_char <= 57)
			{
				ctx.L.string_buffer.Append((char)ctx.L.input_char);
				ctx.NextState = 6;
				return true;
			}
			return false;
		}

		// Token: 0x06019A1C RID: 104988 RVA: 0x00812434 File Offset: 0x00810834
		private static bool State6(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				if (ctx.L.input_char >= 48 && ctx.L.input_char <= 57)
				{
					ctx.L.string_buffer.Append((char)ctx.L.input_char);
				}
				else
				{
					if (ctx.L.input_char == 32 || (ctx.L.input_char >= 9 && ctx.L.input_char <= 13))
					{
						ctx.Return = true;
						ctx.NextState = 1;
						return true;
					}
					int num = ctx.L.input_char;
					if (num != 44)
					{
						if (num != 69)
						{
							if (num == 93)
							{
								goto IL_CA;
							}
							if (num != 101)
							{
								if (num != 125)
								{
									return false;
								}
								goto IL_CA;
							}
						}
						ctx.L.string_buffer.Append((char)ctx.L.input_char);
						ctx.NextState = 7;
						return true;
					}
					IL_CA:
					ctx.L.UngetChar();
					ctx.Return = true;
					ctx.NextState = 1;
					return true;
				}
			}
			return true;
		}

		// Token: 0x06019A1D RID: 104989 RVA: 0x00812560 File Offset: 0x00810960
		private static bool State7(FsmContext ctx)
		{
			ctx.L.GetChar();
			if (ctx.L.input_char >= 48 && ctx.L.input_char <= 57)
			{
				ctx.L.string_buffer.Append((char)ctx.L.input_char);
				ctx.NextState = 8;
				return true;
			}
			int num = ctx.L.input_char;
			if (num != 43 && num != 45)
			{
				return false;
			}
			ctx.L.string_buffer.Append((char)ctx.L.input_char);
			ctx.NextState = 8;
			return true;
		}

		// Token: 0x06019A1E RID: 104990 RVA: 0x0081260C File Offset: 0x00810A0C
		private static bool State8(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				if (ctx.L.input_char >= 48 && ctx.L.input_char <= 57)
				{
					ctx.L.string_buffer.Append((char)ctx.L.input_char);
				}
				else
				{
					if (ctx.L.input_char == 32 || (ctx.L.input_char >= 9 && ctx.L.input_char <= 13))
					{
						ctx.Return = true;
						ctx.NextState = 1;
						return true;
					}
					int num = ctx.L.input_char;
					if (num != 44 && num != 93 && num != 125)
					{
						return false;
					}
					ctx.L.UngetChar();
					ctx.Return = true;
					ctx.NextState = 1;
					return true;
				}
			}
			return true;
		}

		// Token: 0x06019A1F RID: 104991 RVA: 0x00812704 File Offset: 0x00810B04
		private static bool State9(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num != 114)
			{
				return false;
			}
			ctx.NextState = 10;
			return true;
		}

		// Token: 0x06019A20 RID: 104992 RVA: 0x00812744 File Offset: 0x00810B44
		private static bool State10(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num != 117)
			{
				return false;
			}
			ctx.NextState = 11;
			return true;
		}

		// Token: 0x06019A21 RID: 104993 RVA: 0x00812784 File Offset: 0x00810B84
		private static bool State11(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num != 101)
			{
				return false;
			}
			ctx.Return = true;
			ctx.NextState = 1;
			return true;
		}

		// Token: 0x06019A22 RID: 104994 RVA: 0x008127C8 File Offset: 0x00810BC8
		private static bool State12(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num != 97)
			{
				return false;
			}
			ctx.NextState = 13;
			return true;
		}

		// Token: 0x06019A23 RID: 104995 RVA: 0x00812808 File Offset: 0x00810C08
		private static bool State13(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num != 108)
			{
				return false;
			}
			ctx.NextState = 14;
			return true;
		}

		// Token: 0x06019A24 RID: 104996 RVA: 0x00812848 File Offset: 0x00810C48
		private static bool State14(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num != 115)
			{
				return false;
			}
			ctx.NextState = 15;
			return true;
		}

		// Token: 0x06019A25 RID: 104997 RVA: 0x00812888 File Offset: 0x00810C88
		private static bool State15(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num != 101)
			{
				return false;
			}
			ctx.Return = true;
			ctx.NextState = 1;
			return true;
		}

		// Token: 0x06019A26 RID: 104998 RVA: 0x008128CC File Offset: 0x00810CCC
		private static bool State16(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num != 117)
			{
				return false;
			}
			ctx.NextState = 17;
			return true;
		}

		// Token: 0x06019A27 RID: 104999 RVA: 0x0081290C File Offset: 0x00810D0C
		private static bool State17(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num != 108)
			{
				return false;
			}
			ctx.NextState = 18;
			return true;
		}

		// Token: 0x06019A28 RID: 105000 RVA: 0x0081294C File Offset: 0x00810D4C
		private static bool State18(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num != 108)
			{
				return false;
			}
			ctx.Return = true;
			ctx.NextState = 1;
			return true;
		}

		// Token: 0x06019A29 RID: 105001 RVA: 0x00812990 File Offset: 0x00810D90
		private static bool State19(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				int num = ctx.L.input_char;
				if (num == 34)
				{
					ctx.L.UngetChar();
					ctx.Return = true;
					ctx.NextState = 20;
					return true;
				}
				if (num == 92)
				{
					ctx.StateStack = 19;
					ctx.NextState = 21;
					return true;
				}
				ctx.L.string_buffer.Append((char)ctx.L.input_char);
			}
			return true;
		}

		// Token: 0x06019A2A RID: 105002 RVA: 0x00812A24 File Offset: 0x00810E24
		private static bool State20(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num != 34)
			{
				return false;
			}
			ctx.Return = true;
			ctx.NextState = 1;
			return true;
		}

		// Token: 0x06019A2B RID: 105003 RVA: 0x00812A68 File Offset: 0x00810E68
		private static bool State21(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			switch (num)
			{
			case 114:
			case 116:
				break;
			default:
				if (num != 34 && num != 39 && num != 47 && num != 92 && num != 98 && num != 102 && num != 110)
				{
					return false;
				}
				break;
			case 117:
				ctx.NextState = 22;
				return true;
			}
			ctx.L.string_buffer.Append(Lexer.ProcessEscChar(ctx.L.input_char));
			ctx.NextState = ctx.StateStack;
			return true;
		}

		// Token: 0x06019A2C RID: 105004 RVA: 0x00812B20 File Offset: 0x00810F20
		private static bool State22(FsmContext ctx)
		{
			int num = 0;
			int num2 = 4096;
			ctx.L.unichar = 0;
			while (ctx.L.GetChar())
			{
				if ((ctx.L.input_char < 48 || ctx.L.input_char > 57) && (ctx.L.input_char < 65 || ctx.L.input_char > 70) && (ctx.L.input_char < 97 || ctx.L.input_char > 102))
				{
					return false;
				}
				ctx.L.unichar += Lexer.HexValue(ctx.L.input_char) * num2;
				num++;
				num2 /= 16;
				if (num == 4)
				{
					ctx.L.string_buffer.Append(Convert.ToChar(ctx.L.unichar));
					ctx.NextState = ctx.StateStack;
					return true;
				}
			}
			return true;
		}

		// Token: 0x06019A2D RID: 105005 RVA: 0x00812C30 File Offset: 0x00811030
		private static bool State23(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				int num = ctx.L.input_char;
				if (num == 39)
				{
					ctx.L.UngetChar();
					ctx.Return = true;
					ctx.NextState = 24;
					return true;
				}
				if (num == 92)
				{
					ctx.StateStack = 23;
					ctx.NextState = 21;
					return true;
				}
				ctx.L.string_buffer.Append((char)ctx.L.input_char);
			}
			return true;
		}

		// Token: 0x06019A2E RID: 105006 RVA: 0x00812CC4 File Offset: 0x008110C4
		private static bool State24(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num != 39)
			{
				return false;
			}
			ctx.L.input_char = 34;
			ctx.Return = true;
			ctx.NextState = 1;
			return true;
		}

		// Token: 0x06019A2F RID: 105007 RVA: 0x00812D14 File Offset: 0x00811114
		private static bool State25(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num == 42)
			{
				ctx.NextState = 27;
				return true;
			}
			if (num != 47)
			{
				return false;
			}
			ctx.NextState = 26;
			return true;
		}

		// Token: 0x06019A30 RID: 105008 RVA: 0x00812D63 File Offset: 0x00811163
		private static bool State26(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				if (ctx.L.input_char == 10)
				{
					ctx.NextState = 1;
					return true;
				}
			}
			return true;
		}

		// Token: 0x06019A31 RID: 105009 RVA: 0x00812D96 File Offset: 0x00811196
		private static bool State27(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				if (ctx.L.input_char == 42)
				{
					ctx.NextState = 28;
					return true;
				}
			}
			return true;
		}

		// Token: 0x06019A32 RID: 105010 RVA: 0x00812DCC File Offset: 0x008111CC
		private static bool State28(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				if (ctx.L.input_char != 42)
				{
					if (ctx.L.input_char == 47)
					{
						ctx.NextState = 1;
						return true;
					}
					ctx.NextState = 27;
					return true;
				}
			}
			return true;
		}

		// Token: 0x06019A33 RID: 105011 RVA: 0x00812E2C File Offset: 0x0081122C
		private bool GetChar()
		{
			if ((this.input_char = this.NextChar()) != -1)
			{
				return true;
			}
			this.end_of_input = true;
			return false;
		}

		// Token: 0x06019A34 RID: 105012 RVA: 0x00812E58 File Offset: 0x00811258
		private int NextChar()
		{
			if (this.input_buffer != 0)
			{
				int result = this.input_buffer;
				this.input_buffer = 0;
				return result;
			}
			return this.reader.Read();
		}

		// Token: 0x06019A35 RID: 105013 RVA: 0x00812E8C File Offset: 0x0081128C
		public bool NextToken()
		{
			this.fsm_context.Return = false;
			for (;;)
			{
				Lexer.StateHandler stateHandler = Lexer.fsm_handler_table[this.state - 1];
				if (!stateHandler(this.fsm_context))
				{
					break;
				}
				if (this.end_of_input)
				{
					return false;
				}
				if (this.fsm_context.Return)
				{
					goto Block_3;
				}
				this.state = this.fsm_context.NextState;
			}
			throw new JsonException(this.input_char);
			Block_3:
			this.string_value = this.string_buffer.ToString();
			this.string_buffer.Remove(0, this.string_buffer.Length);
			this.token = Lexer.fsm_return_table[this.state - 1];
			if (this.token == 65542)
			{
				this.token = this.input_char;
			}
			this.state = this.fsm_context.NextState;
			return true;
		}

		// Token: 0x06019A36 RID: 105014 RVA: 0x00812F6F File Offset: 0x0081136F
		private void UngetChar()
		{
			this.input_buffer = this.input_char;
		}

		// Token: 0x04012421 RID: 74785
		private static int[] fsm_return_table;

		// Token: 0x04012422 RID: 74786
		private static Lexer.StateHandler[] fsm_handler_table;

		// Token: 0x04012423 RID: 74787
		private bool allow_comments;

		// Token: 0x04012424 RID: 74788
		private bool allow_single_quoted_strings;

		// Token: 0x04012425 RID: 74789
		private bool end_of_input;

		// Token: 0x04012426 RID: 74790
		private FsmContext fsm_context;

		// Token: 0x04012427 RID: 74791
		private int input_buffer;

		// Token: 0x04012428 RID: 74792
		private int input_char;

		// Token: 0x04012429 RID: 74793
		private TextReader reader;

		// Token: 0x0401242A RID: 74794
		private int state;

		// Token: 0x0401242B RID: 74795
		private StringBuilder string_buffer;

		// Token: 0x0401242C RID: 74796
		private string string_value;

		// Token: 0x0401242D RID: 74797
		private int token;

		// Token: 0x0401242E RID: 74798
		private int unichar;

		// Token: 0x0401242F RID: 74799
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache0;

		// Token: 0x04012430 RID: 74800
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache1;

		// Token: 0x04012431 RID: 74801
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache2;

		// Token: 0x04012432 RID: 74802
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache3;

		// Token: 0x04012433 RID: 74803
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache4;

		// Token: 0x04012434 RID: 74804
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache5;

		// Token: 0x04012435 RID: 74805
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache6;

		// Token: 0x04012436 RID: 74806
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache7;

		// Token: 0x04012437 RID: 74807
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache8;

		// Token: 0x04012438 RID: 74808
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache9;

		// Token: 0x04012439 RID: 74809
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cacheA;

		// Token: 0x0401243A RID: 74810
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cacheB;

		// Token: 0x0401243B RID: 74811
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cacheC;

		// Token: 0x0401243C RID: 74812
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cacheD;

		// Token: 0x0401243D RID: 74813
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cacheE;

		// Token: 0x0401243E RID: 74814
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cacheF;

		// Token: 0x0401243F RID: 74815
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache10;

		// Token: 0x04012440 RID: 74816
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache11;

		// Token: 0x04012441 RID: 74817
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache12;

		// Token: 0x04012442 RID: 74818
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache13;

		// Token: 0x04012443 RID: 74819
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache14;

		// Token: 0x04012444 RID: 74820
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache15;

		// Token: 0x04012445 RID: 74821
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache16;

		// Token: 0x04012446 RID: 74822
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache17;

		// Token: 0x04012447 RID: 74823
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache18;

		// Token: 0x04012448 RID: 74824
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache19;

		// Token: 0x04012449 RID: 74825
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache1A;

		// Token: 0x0401244A RID: 74826
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache1B;

		// Token: 0x020046AE RID: 18094
		// (Invoke) Token: 0x06019A38 RID: 105016
		private delegate bool StateHandler(FsmContext ctx);
	}
}
