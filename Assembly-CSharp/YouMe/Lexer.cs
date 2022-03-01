using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace YouMe
{
	// Token: 0x02004AD9 RID: 19161
	internal class Lexer
	{
		// Token: 0x0601BDB4 RID: 114100 RVA: 0x00887475 File Offset: 0x00885875
		static Lexer()
		{
			Lexer.PopulateFsmTables();
		}

		// Token: 0x0601BDB5 RID: 114101 RVA: 0x0088747C File Offset: 0x0088587C
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

		// Token: 0x170025E1 RID: 9697
		// (get) Token: 0x0601BDB6 RID: 114102 RVA: 0x008874E0 File Offset: 0x008858E0
		// (set) Token: 0x0601BDB7 RID: 114103 RVA: 0x008874E8 File Offset: 0x008858E8
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

		// Token: 0x170025E2 RID: 9698
		// (get) Token: 0x0601BDB8 RID: 114104 RVA: 0x008874F1 File Offset: 0x008858F1
		// (set) Token: 0x0601BDB9 RID: 114105 RVA: 0x008874F9 File Offset: 0x008858F9
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

		// Token: 0x170025E3 RID: 9699
		// (get) Token: 0x0601BDBA RID: 114106 RVA: 0x00887502 File Offset: 0x00885902
		public bool EndOfInput
		{
			get
			{
				return this.end_of_input;
			}
		}

		// Token: 0x170025E4 RID: 9700
		// (get) Token: 0x0601BDBB RID: 114107 RVA: 0x0088750A File Offset: 0x0088590A
		public int Token
		{
			get
			{
				return this.token;
			}
		}

		// Token: 0x170025E5 RID: 9701
		// (get) Token: 0x0601BDBC RID: 114108 RVA: 0x00887512 File Offset: 0x00885912
		public string StringValue
		{
			get
			{
				return this.string_value;
			}
		}

		// Token: 0x0601BDBD RID: 114109 RVA: 0x0088751C File Offset: 0x0088591C
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

		// Token: 0x0601BDBE RID: 114110 RVA: 0x00887588 File Offset: 0x00885988
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

		// Token: 0x0601BDBF RID: 114111 RVA: 0x0088794C File Offset: 0x00885D4C
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

		// Token: 0x0601BDC0 RID: 114112 RVA: 0x008879C4 File Offset: 0x00885DC4
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

		// Token: 0x0601BDC1 RID: 114113 RVA: 0x00887BD0 File Offset: 0x00885FD0
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

		// Token: 0x0601BDC2 RID: 114114 RVA: 0x00887C74 File Offset: 0x00886074
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

		// Token: 0x0601BDC3 RID: 114115 RVA: 0x00887DD4 File Offset: 0x008861D4
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

		// Token: 0x0601BDC4 RID: 114116 RVA: 0x00887EE4 File Offset: 0x008862E4
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

		// Token: 0x0601BDC5 RID: 114117 RVA: 0x00887F48 File Offset: 0x00886348
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

		// Token: 0x0601BDC6 RID: 114118 RVA: 0x00888074 File Offset: 0x00886474
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

		// Token: 0x0601BDC7 RID: 114119 RVA: 0x00888120 File Offset: 0x00886520
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

		// Token: 0x0601BDC8 RID: 114120 RVA: 0x00888218 File Offset: 0x00886618
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

		// Token: 0x0601BDC9 RID: 114121 RVA: 0x00888258 File Offset: 0x00886658
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

		// Token: 0x0601BDCA RID: 114122 RVA: 0x00888298 File Offset: 0x00886698
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

		// Token: 0x0601BDCB RID: 114123 RVA: 0x008882DC File Offset: 0x008866DC
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

		// Token: 0x0601BDCC RID: 114124 RVA: 0x0088831C File Offset: 0x0088671C
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

		// Token: 0x0601BDCD RID: 114125 RVA: 0x0088835C File Offset: 0x0088675C
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

		// Token: 0x0601BDCE RID: 114126 RVA: 0x0088839C File Offset: 0x0088679C
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

		// Token: 0x0601BDCF RID: 114127 RVA: 0x008883E0 File Offset: 0x008867E0
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

		// Token: 0x0601BDD0 RID: 114128 RVA: 0x00888420 File Offset: 0x00886820
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

		// Token: 0x0601BDD1 RID: 114129 RVA: 0x00888460 File Offset: 0x00886860
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

		// Token: 0x0601BDD2 RID: 114130 RVA: 0x008884A4 File Offset: 0x008868A4
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

		// Token: 0x0601BDD3 RID: 114131 RVA: 0x00888538 File Offset: 0x00886938
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

		// Token: 0x0601BDD4 RID: 114132 RVA: 0x0088857C File Offset: 0x0088697C
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

		// Token: 0x0601BDD5 RID: 114133 RVA: 0x00888634 File Offset: 0x00886A34
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

		// Token: 0x0601BDD6 RID: 114134 RVA: 0x00888744 File Offset: 0x00886B44
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

		// Token: 0x0601BDD7 RID: 114135 RVA: 0x008887D8 File Offset: 0x00886BD8
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

		// Token: 0x0601BDD8 RID: 114136 RVA: 0x00888828 File Offset: 0x00886C28
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

		// Token: 0x0601BDD9 RID: 114137 RVA: 0x00888877 File Offset: 0x00886C77
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

		// Token: 0x0601BDDA RID: 114138 RVA: 0x008888AA File Offset: 0x00886CAA
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

		// Token: 0x0601BDDB RID: 114139 RVA: 0x008888E0 File Offset: 0x00886CE0
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

		// Token: 0x0601BDDC RID: 114140 RVA: 0x00888940 File Offset: 0x00886D40
		private bool GetChar()
		{
			if ((this.input_char = this.NextChar()) != -1)
			{
				return true;
			}
			this.end_of_input = true;
			return false;
		}

		// Token: 0x0601BDDD RID: 114141 RVA: 0x0088896C File Offset: 0x00886D6C
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

		// Token: 0x0601BDDE RID: 114142 RVA: 0x008889A0 File Offset: 0x00886DA0
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

		// Token: 0x0601BDDF RID: 114143 RVA: 0x00888A83 File Offset: 0x00886E83
		private void UngetChar()
		{
			this.input_buffer = this.input_char;
		}

		// Token: 0x0401364D RID: 79437
		private static int[] fsm_return_table;

		// Token: 0x0401364E RID: 79438
		private static Lexer.StateHandler[] fsm_handler_table;

		// Token: 0x0401364F RID: 79439
		private bool allow_comments;

		// Token: 0x04013650 RID: 79440
		private bool allow_single_quoted_strings;

		// Token: 0x04013651 RID: 79441
		private bool end_of_input;

		// Token: 0x04013652 RID: 79442
		private FsmContext fsm_context;

		// Token: 0x04013653 RID: 79443
		private int input_buffer;

		// Token: 0x04013654 RID: 79444
		private int input_char;

		// Token: 0x04013655 RID: 79445
		private TextReader reader;

		// Token: 0x04013656 RID: 79446
		private int state;

		// Token: 0x04013657 RID: 79447
		private StringBuilder string_buffer;

		// Token: 0x04013658 RID: 79448
		private string string_value;

		// Token: 0x04013659 RID: 79449
		private int token;

		// Token: 0x0401365A RID: 79450
		private int unichar;

		// Token: 0x0401365B RID: 79451
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache0;

		// Token: 0x0401365C RID: 79452
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache1;

		// Token: 0x0401365D RID: 79453
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache2;

		// Token: 0x0401365E RID: 79454
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache3;

		// Token: 0x0401365F RID: 79455
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache4;

		// Token: 0x04013660 RID: 79456
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache5;

		// Token: 0x04013661 RID: 79457
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache6;

		// Token: 0x04013662 RID: 79458
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache7;

		// Token: 0x04013663 RID: 79459
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache8;

		// Token: 0x04013664 RID: 79460
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache9;

		// Token: 0x04013665 RID: 79461
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cacheA;

		// Token: 0x04013666 RID: 79462
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cacheB;

		// Token: 0x04013667 RID: 79463
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cacheC;

		// Token: 0x04013668 RID: 79464
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cacheD;

		// Token: 0x04013669 RID: 79465
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cacheE;

		// Token: 0x0401366A RID: 79466
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cacheF;

		// Token: 0x0401366B RID: 79467
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache10;

		// Token: 0x0401366C RID: 79468
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache11;

		// Token: 0x0401366D RID: 79469
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache12;

		// Token: 0x0401366E RID: 79470
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache13;

		// Token: 0x0401366F RID: 79471
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache14;

		// Token: 0x04013670 RID: 79472
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache15;

		// Token: 0x04013671 RID: 79473
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache16;

		// Token: 0x04013672 RID: 79474
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache17;

		// Token: 0x04013673 RID: 79475
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache18;

		// Token: 0x04013674 RID: 79476
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache19;

		// Token: 0x04013675 RID: 79477
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache1A;

		// Token: 0x04013676 RID: 79478
		[CompilerGenerated]
		private static Lexer.StateHandler <>f__mg$cache1B;

		// Token: 0x02004ADA RID: 19162
		// (Invoke) Token: 0x0601BDE1 RID: 114145
		private delegate bool StateHandler(FsmContext ctx);
	}
}
