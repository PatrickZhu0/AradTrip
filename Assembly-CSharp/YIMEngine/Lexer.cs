using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace YIMEngine
{
	// Token: 0x02004A8A RID: 19082
	internal class Lexer
	{
		// Token: 0x0601BADE RID: 113374 RVA: 0x0087F679 File Offset: 0x0087DA79
		static Lexer()
		{
			Lexer.PopulateFsmTables();
		}

		// Token: 0x0601BADF RID: 113375 RVA: 0x0087F680 File Offset: 0x0087DA80
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

		// Token: 0x17002535 RID: 9525
		// (get) Token: 0x0601BAE0 RID: 113376 RVA: 0x0087F6E4 File Offset: 0x0087DAE4
		// (set) Token: 0x0601BAE1 RID: 113377 RVA: 0x0087F6EC File Offset: 0x0087DAEC
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

		// Token: 0x17002536 RID: 9526
		// (get) Token: 0x0601BAE2 RID: 113378 RVA: 0x0087F6F5 File Offset: 0x0087DAF5
		// (set) Token: 0x0601BAE3 RID: 113379 RVA: 0x0087F6FD File Offset: 0x0087DAFD
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

		// Token: 0x17002537 RID: 9527
		// (get) Token: 0x0601BAE4 RID: 113380 RVA: 0x0087F706 File Offset: 0x0087DB06
		public bool EndOfInput
		{
			get
			{
				return this.end_of_input;
			}
		}

		// Token: 0x17002538 RID: 9528
		// (get) Token: 0x0601BAE5 RID: 113381 RVA: 0x0087F70E File Offset: 0x0087DB0E
		public int Token
		{
			get
			{
				return this.token;
			}
		}

		// Token: 0x17002539 RID: 9529
		// (get) Token: 0x0601BAE6 RID: 113382 RVA: 0x0087F716 File Offset: 0x0087DB16
		public string StringValue
		{
			get
			{
				return this.string_value;
			}
		}

		// Token: 0x0601BAE7 RID: 113383 RVA: 0x0087F720 File Offset: 0x0087DB20
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

		// Token: 0x0601BAE8 RID: 113384 RVA: 0x0087F78C File Offset: 0x0087DB8C
		private static void PopulateFsmTables()
		{
			Lexer.StateHandler[] array = new Lexer.StateHandler[28];
			array[0] = new Lexer.StateHandler(Lexer.State1);
			array[1] = new Lexer.StateHandler(Lexer.State2);
			//int num = 0;
			//if (Lexer.<>f__mg$cache0 == null)
			//{
			//	Lexer.<>f__mg$cache0 = new Lexer.StateHandler(Lexer.State1);
			//}
			//array[num] = Lexer.<>f__mg$cache0;
			//int num2 = 1;
			//if (Lexer.<>f__mg$cache1 == null)
			//{
			//	Lexer.<>f__mg$cache1 = new Lexer.StateHandler(Lexer.State2);
			//}
			//array[num2] = Lexer.<>f__mg$cache1;
			//int num3 = 2;
			//if (Lexer.<>f__mg$cache2 == null)
			//{
			//	Lexer.<>f__mg$cache2 = new Lexer.StateHandler(Lexer.State3);
			//}
			//array[num3] = Lexer.<>f__mg$cache2;
			//int num4 = 3;
			//if (Lexer.<>f__mg$cache3 == null)
			//{
			//	Lexer.<>f__mg$cache3 = new Lexer.StateHandler(Lexer.State4);
			//}
			//array[num4] = Lexer.<>f__mg$cache3;
			//int num5 = 4;
			//if (Lexer.<>f__mg$cache4 == null)
			//{
			//	Lexer.<>f__mg$cache4 = new Lexer.StateHandler(Lexer.State5);
			//}
			//array[num5] = Lexer.<>f__mg$cache4;
			//int num6 = 5;
			//if (Lexer.<>f__mg$cache5 == null)
			//{
			//	Lexer.<>f__mg$cache5 = new Lexer.StateHandler(Lexer.State6);
			//}
			//array[num6] = Lexer.<>f__mg$cache5;
			//int num7 = 6;
			//if (Lexer.<>f__mg$cache6 == null)
			//{
			//	Lexer.<>f__mg$cache6 = new Lexer.StateHandler(Lexer.State7);
			//}
			//array[num7] = Lexer.<>f__mg$cache6;
			//int num8 = 7;
			//if (Lexer.<>f__mg$cache7 == null)
			//{
			//	Lexer.<>f__mg$cache7 = new Lexer.StateHandler(Lexer.State8);
			//}
			//array[num8] = Lexer.<>f__mg$cache7;
			//int num9 = 8;
			//if (Lexer.<>f__mg$cache8 == null)
			//{
			//	Lexer.<>f__mg$cache8 = new Lexer.StateHandler(Lexer.State9);
			//}
			//array[num9] = Lexer.<>f__mg$cache8;
			//int num10 = 9;
			//if (Lexer.<>f__mg$cache9 == null)
			//{
			//	Lexer.<>f__mg$cache9 = new Lexer.StateHandler(Lexer.State10);
			//}
			//array[num10] = Lexer.<>f__mg$cache9;
			//int num11 = 10;
			//if (Lexer.<>f__mg$cacheA == null)
			//{
			//	Lexer.<>f__mg$cacheA = new Lexer.StateHandler(Lexer.State11);
			//}
			//array[num11] = Lexer.<>f__mg$cacheA;
			//int num12 = 11;
			//if (Lexer.<>f__mg$cacheB == null)
			//{
			//	Lexer.<>f__mg$cacheB = new Lexer.StateHandler(Lexer.State12);
			//}
			//array[num12] = Lexer.<>f__mg$cacheB;
			//int num13 = 12;
			//if (Lexer.<>f__mg$cacheC == null)
			//{
			//	Lexer.<>f__mg$cacheC = new Lexer.StateHandler(Lexer.State13);
			//}
			//array[num13] = Lexer.<>f__mg$cacheC;
			//int num14 = 13;
			//if (Lexer.<>f__mg$cacheD == null)
			//{
			//	Lexer.<>f__mg$cacheD = new Lexer.StateHandler(Lexer.State14);
			//}
			//array[num14] = Lexer.<>f__mg$cacheD;
			//int num15 = 14;
			//if (Lexer.<>f__mg$cacheE == null)
			//{
			//	Lexer.<>f__mg$cacheE = new Lexer.StateHandler(Lexer.State15);
			//}
			//array[num15] = Lexer.<>f__mg$cacheE;
			//int num16 = 15;
			//if (Lexer.<>f__mg$cacheF == null)
			//{
			//	Lexer.<>f__mg$cacheF = new Lexer.StateHandler(Lexer.State16);
			//}
			//array[num16] = Lexer.<>f__mg$cacheF;
			//int num17 = 16;
			//if (Lexer.<>f__mg$cache10 == null)
			//{
			//	Lexer.<>f__mg$cache10 = new Lexer.StateHandler(Lexer.State17);
			//}
			//array[num17] = Lexer.<>f__mg$cache10;
			//int num18 = 17;
			//if (Lexer.<>f__mg$cache11 == null)
			//{
			//	Lexer.<>f__mg$cache11 = new Lexer.StateHandler(Lexer.State18);
			//}
			//array[num18] = Lexer.<>f__mg$cache11;
			//int num19 = 18;
			//if (Lexer.<>f__mg$cache12 == null)
			//{
			//	Lexer.<>f__mg$cache12 = new Lexer.StateHandler(Lexer.State19);
			//}
			//array[num19] = Lexer.<>f__mg$cache12;
			//int num20 = 19;
			//if (Lexer.<>f__mg$cache13 == null)
			//{
			//	Lexer.<>f__mg$cache13 = new Lexer.StateHandler(Lexer.State20);
			//}
			//array[num20] = Lexer.<>f__mg$cache13;
			//int num21 = 20;
			//if (Lexer.<>f__mg$cache14 == null)
			//{
			//	Lexer.<>f__mg$cache14 = new Lexer.StateHandler(Lexer.State21);
			//}
			//array[num21] = Lexer.<>f__mg$cache14;
			//int num22 = 21;
			//if (Lexer.<>f__mg$cache15 == null)
			//{
			//	Lexer.<>f__mg$cache15 = new Lexer.StateHandler(Lexer.State22);
			//}
			//array[num22] = Lexer.<>f__mg$cache15;
			//int num23 = 22;
			//if (Lexer.<>f__mg$cache16 == null)
			//{
			//	Lexer.<>f__mg$cache16 = new Lexer.StateHandler(Lexer.State23);
			//}
			//array[num23] = Lexer.<>f__mg$cache16;
			//int num24 = 23;
			//if (Lexer.<>f__mg$cache17 == null)
			//{
			//	Lexer.<>f__mg$cache17 = new Lexer.StateHandler(Lexer.State24);
			//}
			//array[num24] = Lexer.<>f__mg$cache17;
			//int num25 = 24;
			//if (Lexer.<>f__mg$cache18 == null)
			//{
			//	Lexer.<>f__mg$cache18 = new Lexer.StateHandler(Lexer.State25);
			//}
			//array[num25] = Lexer.<>f__mg$cache18;
			//int num26 = 25;
			//if (Lexer.<>f__mg$cache19 == null)
			//{
			//	Lexer.<>f__mg$cache19 = new Lexer.StateHandler(Lexer.State26);
			//}
			//array[num26] = Lexer.<>f__mg$cache19;
			//int num27 = 26;
			//if (Lexer.<>f__mg$cache1A == null)
			//{
			//	Lexer.<>f__mg$cache1A = new Lexer.StateHandler(Lexer.State27);
			//}
			//array[num27] = Lexer.<>f__mg$cache1A;
			//int num28 = 27;
			//if (Lexer.<>f__mg$cache1B == null)
			//{
			//	Lexer.<>f__mg$cache1B = new Lexer.StateHandler(Lexer.State28);
			//}
			//array[num28] = Lexer.<>f__mg$cache1B;
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

		// Token: 0x0601BAE9 RID: 113385 RVA: 0x0087FB50 File Offset: 0x0087DF50
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

		// Token: 0x0601BAEA RID: 113386 RVA: 0x0087FBC8 File Offset: 0x0087DFC8
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

		// Token: 0x0601BAEB RID: 113387 RVA: 0x0087FDD4 File Offset: 0x0087E1D4
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

		// Token: 0x0601BAEC RID: 113388 RVA: 0x0087FE78 File Offset: 0x0087E278
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

		// Token: 0x0601BAED RID: 113389 RVA: 0x0087FFD8 File Offset: 0x0087E3D8
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

		// Token: 0x0601BAEE RID: 113390 RVA: 0x008800E8 File Offset: 0x0087E4E8
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

		// Token: 0x0601BAEF RID: 113391 RVA: 0x0088014C File Offset: 0x0087E54C
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

		// Token: 0x0601BAF0 RID: 113392 RVA: 0x00880278 File Offset: 0x0087E678
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

		// Token: 0x0601BAF1 RID: 113393 RVA: 0x00880324 File Offset: 0x0087E724
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

		// Token: 0x0601BAF2 RID: 113394 RVA: 0x0088041C File Offset: 0x0087E81C
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

		// Token: 0x0601BAF3 RID: 113395 RVA: 0x0088045C File Offset: 0x0087E85C
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

		// Token: 0x0601BAF4 RID: 113396 RVA: 0x0088049C File Offset: 0x0087E89C
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

		// Token: 0x0601BAF5 RID: 113397 RVA: 0x008804E0 File Offset: 0x0087E8E0
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

		// Token: 0x0601BAF6 RID: 113398 RVA: 0x00880520 File Offset: 0x0087E920
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

		// Token: 0x0601BAF7 RID: 113399 RVA: 0x00880560 File Offset: 0x0087E960
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

		// Token: 0x0601BAF8 RID: 113400 RVA: 0x008805A0 File Offset: 0x0087E9A0
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

		// Token: 0x0601BAF9 RID: 113401 RVA: 0x008805E4 File Offset: 0x0087E9E4
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

		// Token: 0x0601BAFA RID: 113402 RVA: 0x00880624 File Offset: 0x0087EA24
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

		// Token: 0x0601BAFB RID: 113403 RVA: 0x00880664 File Offset: 0x0087EA64
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

		// Token: 0x0601BAFC RID: 113404 RVA: 0x008806A8 File Offset: 0x0087EAA8
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

		// Token: 0x0601BAFD RID: 113405 RVA: 0x0088073C File Offset: 0x0087EB3C
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

		// Token: 0x0601BAFE RID: 113406 RVA: 0x00880780 File Offset: 0x0087EB80
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

		// Token: 0x0601BAFF RID: 113407 RVA: 0x00880838 File Offset: 0x0087EC38
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

		// Token: 0x0601BB00 RID: 113408 RVA: 0x00880948 File Offset: 0x0087ED48
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

		// Token: 0x0601BB01 RID: 113409 RVA: 0x008809DC File Offset: 0x0087EDDC
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

		// Token: 0x0601BB02 RID: 113410 RVA: 0x00880A2C File Offset: 0x0087EE2C
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

		// Token: 0x0601BB03 RID: 113411 RVA: 0x00880A7B File Offset: 0x0087EE7B
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

		// Token: 0x0601BB04 RID: 113412 RVA: 0x00880AAE File Offset: 0x0087EEAE
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

		// Token: 0x0601BB05 RID: 113413 RVA: 0x00880AE4 File Offset: 0x0087EEE4
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

		// Token: 0x0601BB06 RID: 113414 RVA: 0x00880B44 File Offset: 0x0087EF44
		private bool GetChar()
		{
			if ((this.input_char = this.NextChar()) != -1)
			{
				return true;
			}
			this.end_of_input = true;
			return false;
		}

		// Token: 0x0601BB07 RID: 113415 RVA: 0x00880B70 File Offset: 0x0087EF70
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

		// Token: 0x0601BB08 RID: 113416 RVA: 0x00880BA4 File Offset: 0x0087EFA4
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

		// Token: 0x0601BB09 RID: 113417 RVA: 0x00880C87 File Offset: 0x0087F087
		private void UngetChar()
		{
			this.input_buffer = this.input_char;
		}

		// Token: 0x04013487 RID: 78983
		private static int[] fsm_return_table;

		// Token: 0x04013488 RID: 78984
		private static Lexer.StateHandler[] fsm_handler_table;

		// Token: 0x04013489 RID: 78985
		private bool allow_comments;

		// Token: 0x0401348A RID: 78986
		private bool allow_single_quoted_strings;

		// Token: 0x0401348B RID: 78987
		private bool end_of_input;

		// Token: 0x0401348C RID: 78988
		private FsmContext fsm_context;

		// Token: 0x0401348D RID: 78989
		private int input_buffer;

		// Token: 0x0401348E RID: 78990
		private int input_char;

		// Token: 0x0401348F RID: 78991
		private TextReader reader;

		// Token: 0x04013490 RID: 78992
		private int state;

		// Token: 0x04013491 RID: 78993
		private StringBuilder string_buffer;

		// Token: 0x04013492 RID: 78994
		private string string_value;

		// Token: 0x04013493 RID: 78995
		private int token;

		// Token: 0x04013494 RID: 78996
		private int unichar;

		//// Token: 0x04013495 RID: 78997
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache0;

		//// Token: 0x04013496 RID: 78998
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache1;

		//// Token: 0x04013497 RID: 78999
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache2;

		//// Token: 0x04013498 RID: 79000
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache3;

		//// Token: 0x04013499 RID: 79001
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache4;

		//// Token: 0x0401349A RID: 79002
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache5;

		//// Token: 0x0401349B RID: 79003
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache6;

		//// Token: 0x0401349C RID: 79004
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache7;

		//// Token: 0x0401349D RID: 79005
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache8;

		//// Token: 0x0401349E RID: 79006
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache9;

		//// Token: 0x0401349F RID: 79007
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cacheA;

		//// Token: 0x040134A0 RID: 79008
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cacheB;

		//// Token: 0x040134A1 RID: 79009
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cacheC;

		//// Token: 0x040134A2 RID: 79010
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cacheD;

		//// Token: 0x040134A3 RID: 79011
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cacheE;

		//// Token: 0x040134A4 RID: 79012
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cacheF;

		//// Token: 0x040134A5 RID: 79013
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache10;

		//// Token: 0x040134A6 RID: 79014
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache11;

		//// Token: 0x040134A7 RID: 79015
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache12;

		//// Token: 0x040134A8 RID: 79016
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache13;

		//// Token: 0x040134A9 RID: 79017
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache14;

		//// Token: 0x040134AA RID: 79018
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache15;

		//// Token: 0x040134AB RID: 79019
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache16;

		//// Token: 0x040134AC RID: 79020
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache17;

		//// Token: 0x040134AD RID: 79021
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache18;

		//// Token: 0x040134AE RID: 79022
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache19;

		//// Token: 0x040134AF RID: 79023
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache1A;

		//// Token: 0x040134B0 RID: 79024
		//[CompilerGenerated]
		//private static Lexer.StateHandler <>f__mg$cache1B;

		// Token: 0x02004A8B RID: 19083
		// (Invoke) Token: 0x0601BB0B RID: 113419
		private delegate bool StateHandler(FsmContext ctx);
	}
}
