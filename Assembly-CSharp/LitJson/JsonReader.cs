using System;
using System.Collections.Generic;
using System.IO;

namespace LitJson
{
	// Token: 0x020046A8 RID: 18088
	public class JsonReader
	{
		// Token: 0x060199D1 RID: 104913 RVA: 0x0081062D File Offset: 0x0080EA2D
		static JsonReader()
		{
			JsonReader.PopulateParseTable();
		}

		// Token: 0x060199D2 RID: 104914 RVA: 0x00810634 File Offset: 0x0080EA34
		public JsonReader(string json_text) : this(new StringReader(json_text), true)
		{
		}

		// Token: 0x060199D3 RID: 104915 RVA: 0x00810643 File Offset: 0x0080EA43
		public JsonReader(TextReader reader) : this(reader, false)
		{
		}

		// Token: 0x060199D4 RID: 104916 RVA: 0x00810650 File Offset: 0x0080EA50
		private JsonReader(TextReader reader, bool owned)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			this.parser_in_string = false;
			this.parser_return = false;
			this.read_started = false;
			this.automaton_stack = new Stack<int>();
			this.automaton_stack.Push(65553);
			this.automaton_stack.Push(65543);
			this.lexer = new Lexer(reader);
			this.end_of_input = false;
			this.end_of_json = false;
			this.skip_non_members = true;
			this.reader = reader;
			this.reader_is_owned = owned;
		}

		// Token: 0x17002120 RID: 8480
		// (get) Token: 0x060199D5 RID: 104917 RVA: 0x008106E3 File Offset: 0x0080EAE3
		// (set) Token: 0x060199D6 RID: 104918 RVA: 0x008106F0 File Offset: 0x0080EAF0
		public bool AllowComments
		{
			get
			{
				return this.lexer.AllowComments;
			}
			set
			{
				this.lexer.AllowComments = value;
			}
		}

		// Token: 0x17002121 RID: 8481
		// (get) Token: 0x060199D7 RID: 104919 RVA: 0x008106FE File Offset: 0x0080EAFE
		// (set) Token: 0x060199D8 RID: 104920 RVA: 0x0081070B File Offset: 0x0080EB0B
		public bool AllowSingleQuotedStrings
		{
			get
			{
				return this.lexer.AllowSingleQuotedStrings;
			}
			set
			{
				this.lexer.AllowSingleQuotedStrings = value;
			}
		}

		// Token: 0x17002122 RID: 8482
		// (get) Token: 0x060199D9 RID: 104921 RVA: 0x00810719 File Offset: 0x0080EB19
		// (set) Token: 0x060199DA RID: 104922 RVA: 0x00810721 File Offset: 0x0080EB21
		public bool SkipNonMembers
		{
			get
			{
				return this.skip_non_members;
			}
			set
			{
				this.skip_non_members = value;
			}
		}

		// Token: 0x17002123 RID: 8483
		// (get) Token: 0x060199DB RID: 104923 RVA: 0x0081072A File Offset: 0x0080EB2A
		public bool EndOfInput
		{
			get
			{
				return this.end_of_input;
			}
		}

		// Token: 0x17002124 RID: 8484
		// (get) Token: 0x060199DC RID: 104924 RVA: 0x00810732 File Offset: 0x0080EB32
		public bool EndOfJson
		{
			get
			{
				return this.end_of_json;
			}
		}

		// Token: 0x17002125 RID: 8485
		// (get) Token: 0x060199DD RID: 104925 RVA: 0x0081073A File Offset: 0x0080EB3A
		public JsonToken Token
		{
			get
			{
				return this.token;
			}
		}

		// Token: 0x17002126 RID: 8486
		// (get) Token: 0x060199DE RID: 104926 RVA: 0x00810742 File Offset: 0x0080EB42
		public object Value
		{
			get
			{
				return this.token_value;
			}
		}

		// Token: 0x060199DF RID: 104927 RVA: 0x0081074C File Offset: 0x0080EB4C
		private static void PopulateParseTable()
		{
			JsonReader.parse_table = new Dictionary<int, IDictionary<int, int[]>>();
			JsonReader.TableAddRow(ParserToken.Array);
			JsonReader.TableAddCol(ParserToken.Array, 91, new int[]
			{
				91,
				65549
			});
			JsonReader.TableAddRow(ParserToken.ArrayPrime);
			JsonReader.TableAddCol(ParserToken.ArrayPrime, 34, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.TableAddCol(ParserToken.ArrayPrime, 91, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.TableAddCol(ParserToken.ArrayPrime, 93, new int[]
			{
				93
			});
			JsonReader.TableAddCol(ParserToken.ArrayPrime, 123, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.TableAddCol(ParserToken.ArrayPrime, 65537, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.TableAddCol(ParserToken.ArrayPrime, 65538, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.TableAddCol(ParserToken.ArrayPrime, 65539, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.TableAddCol(ParserToken.ArrayPrime, 65540, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.TableAddRow(ParserToken.Object);
			JsonReader.TableAddCol(ParserToken.Object, 123, new int[]
			{
				123,
				65545
			});
			JsonReader.TableAddRow(ParserToken.ObjectPrime);
			JsonReader.TableAddCol(ParserToken.ObjectPrime, 34, new int[]
			{
				65546,
				65547,
				125
			});
			JsonReader.TableAddCol(ParserToken.ObjectPrime, 125, new int[]
			{
				125
			});
			JsonReader.TableAddRow(ParserToken.Pair);
			JsonReader.TableAddCol(ParserToken.Pair, 34, new int[]
			{
				65552,
				58,
				65550
			});
			JsonReader.TableAddRow(ParserToken.PairRest);
			JsonReader.TableAddCol(ParserToken.PairRest, 44, new int[]
			{
				44,
				65546,
				65547
			});
			JsonReader.TableAddCol(ParserToken.PairRest, 125, new int[]
			{
				65554
			});
			JsonReader.TableAddRow(ParserToken.String);
			JsonReader.TableAddCol(ParserToken.String, 34, new int[]
			{
				34,
				65541,
				34
			});
			JsonReader.TableAddRow(ParserToken.Text);
			JsonReader.TableAddCol(ParserToken.Text, 91, new int[]
			{
				65548
			});
			JsonReader.TableAddCol(ParserToken.Text, 123, new int[]
			{
				65544
			});
			JsonReader.TableAddRow(ParserToken.Value);
			JsonReader.TableAddCol(ParserToken.Value, 34, new int[]
			{
				65552
			});
			JsonReader.TableAddCol(ParserToken.Value, 91, new int[]
			{
				65548
			});
			JsonReader.TableAddCol(ParserToken.Value, 123, new int[]
			{
				65544
			});
			JsonReader.TableAddCol(ParserToken.Value, 65537, new int[]
			{
				65537
			});
			JsonReader.TableAddCol(ParserToken.Value, 65538, new int[]
			{
				65538
			});
			JsonReader.TableAddCol(ParserToken.Value, 65539, new int[]
			{
				65539
			});
			JsonReader.TableAddCol(ParserToken.Value, 65540, new int[]
			{
				65540
			});
			JsonReader.TableAddRow(ParserToken.ValueRest);
			JsonReader.TableAddCol(ParserToken.ValueRest, 44, new int[]
			{
				44,
				65550,
				65551
			});
			JsonReader.TableAddCol(ParserToken.ValueRest, 93, new int[]
			{
				65554
			});
		}

		// Token: 0x060199E0 RID: 104928 RVA: 0x00810AC5 File Offset: 0x0080EEC5
		private static void TableAddCol(ParserToken row, int col, params int[] symbols)
		{
			JsonReader.parse_table[(int)row].Add(col, symbols);
		}

		// Token: 0x060199E1 RID: 104929 RVA: 0x00810AD9 File Offset: 0x0080EED9
		private static void TableAddRow(ParserToken rule)
		{
			JsonReader.parse_table.Add((int)rule, new Dictionary<int, int[]>());
		}

		// Token: 0x060199E2 RID: 104930 RVA: 0x00810AEC File Offset: 0x0080EEEC
		private void ProcessNumber(string number)
		{
			double num;
			if ((number.IndexOf('.') != -1 || number.IndexOf('e') != -1 || number.IndexOf('E') != -1) && double.TryParse(number, out num))
			{
				this.token = JsonToken.Double;
				this.token_value = num;
				return;
			}
			int num2;
			if (int.TryParse(number, out num2))
			{
				this.token = JsonToken.Int;
				this.token_value = num2;
				return;
			}
			long num3;
			if (long.TryParse(number, out num3))
			{
				this.token = JsonToken.Long;
				this.token_value = num3;
				return;
			}
			ulong num4;
			if (ulong.TryParse(number, out num4))
			{
				this.token = JsonToken.Long;
				this.token_value = num4;
				return;
			}
			this.token = JsonToken.Int;
			this.token_value = 0;
		}

		// Token: 0x060199E3 RID: 104931 RVA: 0x00810BBC File Offset: 0x0080EFBC
		private void ProcessSymbol()
		{
			if (this.current_symbol == 91)
			{
				this.token = JsonToken.ArrayStart;
				this.parser_return = true;
			}
			else if (this.current_symbol == 93)
			{
				this.token = JsonToken.ArrayEnd;
				this.parser_return = true;
			}
			else if (this.current_symbol == 123)
			{
				this.token = JsonToken.ObjectStart;
				this.parser_return = true;
			}
			else if (this.current_symbol == 125)
			{
				this.token = JsonToken.ObjectEnd;
				this.parser_return = true;
			}
			else if (this.current_symbol == 34)
			{
				if (this.parser_in_string)
				{
					this.parser_in_string = false;
					this.parser_return = true;
				}
				else
				{
					if (this.token == JsonToken.None)
					{
						this.token = JsonToken.String;
					}
					this.parser_in_string = true;
				}
			}
			else if (this.current_symbol == 65541)
			{
				this.token_value = this.lexer.StringValue;
			}
			else if (this.current_symbol == 65539)
			{
				this.token = JsonToken.Boolean;
				this.token_value = false;
				this.parser_return = true;
			}
			else if (this.current_symbol == 65540)
			{
				this.token = JsonToken.Null;
				this.parser_return = true;
			}
			else if (this.current_symbol == 65537)
			{
				this.ProcessNumber(this.lexer.StringValue);
				this.parser_return = true;
			}
			else if (this.current_symbol == 65546)
			{
				this.token = JsonToken.PropertyName;
			}
			else if (this.current_symbol == 65538)
			{
				this.token = JsonToken.Boolean;
				this.token_value = true;
				this.parser_return = true;
			}
		}

		// Token: 0x060199E4 RID: 104932 RVA: 0x00810D84 File Offset: 0x0080F184
		private bool ReadToken()
		{
			if (this.end_of_input)
			{
				return false;
			}
			this.lexer.NextToken();
			if (this.lexer.EndOfInput)
			{
				this.Close();
				return false;
			}
			this.current_input = this.lexer.Token;
			return true;
		}

		// Token: 0x060199E5 RID: 104933 RVA: 0x00810DD4 File Offset: 0x0080F1D4
		public void Close()
		{
			if (this.end_of_input)
			{
				return;
			}
			this.end_of_input = true;
			this.end_of_json = true;
			if (this.reader_is_owned)
			{
				this.reader.Close();
			}
			this.reader = null;
		}

		// Token: 0x060199E6 RID: 104934 RVA: 0x00810E10 File Offset: 0x0080F210
		public bool Read()
		{
			if (this.end_of_input)
			{
				return false;
			}
			if (this.end_of_json)
			{
				this.end_of_json = false;
				this.automaton_stack.Clear();
				this.automaton_stack.Push(65553);
				this.automaton_stack.Push(65543);
			}
			this.parser_in_string = false;
			this.parser_return = false;
			this.token = JsonToken.None;
			this.token_value = null;
			if (!this.read_started)
			{
				this.read_started = true;
				if (!this.ReadToken())
				{
					return false;
				}
			}
			while (!this.parser_return)
			{
				this.current_symbol = this.automaton_stack.Pop();
				this.ProcessSymbol();
				if (this.current_symbol == this.current_input)
				{
					if (!this.ReadToken())
					{
						if (this.automaton_stack.Peek() != 65553)
						{
							throw new JsonException("Input doesn't evaluate to proper JSON text");
						}
						return this.parser_return;
					}
				}
				else
				{
					int[] array;
					try
					{
						array = JsonReader.parse_table[this.current_symbol][this.current_input];
					}
					catch (KeyNotFoundException inner_exception)
					{
						throw new JsonException((ParserToken)this.current_input, inner_exception);
					}
					if (array[0] != 65554)
					{
						for (int i = array.Length - 1; i >= 0; i--)
						{
							this.automaton_stack.Push(array[i]);
						}
					}
				}
			}
			if (this.automaton_stack.Peek() == 65553)
			{
				this.end_of_json = true;
			}
			return true;
		}

		// Token: 0x040123F8 RID: 74744
		private static IDictionary<int, IDictionary<int, int[]>> parse_table;

		// Token: 0x040123F9 RID: 74745
		private Stack<int> automaton_stack;

		// Token: 0x040123FA RID: 74746
		private int current_input;

		// Token: 0x040123FB RID: 74747
		private int current_symbol;

		// Token: 0x040123FC RID: 74748
		private bool end_of_json;

		// Token: 0x040123FD RID: 74749
		private bool end_of_input;

		// Token: 0x040123FE RID: 74750
		private Lexer lexer;

		// Token: 0x040123FF RID: 74751
		private bool parser_in_string;

		// Token: 0x04012400 RID: 74752
		private bool parser_return;

		// Token: 0x04012401 RID: 74753
		private bool read_started;

		// Token: 0x04012402 RID: 74754
		private TextReader reader;

		// Token: 0x04012403 RID: 74755
		private bool reader_is_owned;

		// Token: 0x04012404 RID: 74756
		private bool skip_non_members;

		// Token: 0x04012405 RID: 74757
		private object token_value;

		// Token: 0x04012406 RID: 74758
		private JsonToken token;
	}
}
