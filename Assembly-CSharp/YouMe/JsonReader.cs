using System;
using System.Collections.Generic;
using System.IO;

namespace YouMe
{
	// Token: 0x02004AD4 RID: 19156
	public class JsonReader
	{
		// Token: 0x0601BD7A RID: 114042 RVA: 0x00886141 File Offset: 0x00884541
		static JsonReader()
		{
			JsonReader.PopulateParseTable();
		}

		// Token: 0x0601BD7B RID: 114043 RVA: 0x00886148 File Offset: 0x00884548
		public JsonReader(string json_text) : this(new StringReader(json_text), true)
		{
		}

		// Token: 0x0601BD7C RID: 114044 RVA: 0x00886157 File Offset: 0x00884557
		public JsonReader(TextReader reader) : this(reader, false)
		{
		}

		// Token: 0x0601BD7D RID: 114045 RVA: 0x00886164 File Offset: 0x00884564
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

		// Token: 0x170025D6 RID: 9686
		// (get) Token: 0x0601BD7E RID: 114046 RVA: 0x008861F7 File Offset: 0x008845F7
		// (set) Token: 0x0601BD7F RID: 114047 RVA: 0x00886204 File Offset: 0x00884604
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

		// Token: 0x170025D7 RID: 9687
		// (get) Token: 0x0601BD80 RID: 114048 RVA: 0x00886212 File Offset: 0x00884612
		// (set) Token: 0x0601BD81 RID: 114049 RVA: 0x0088621F File Offset: 0x0088461F
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

		// Token: 0x170025D8 RID: 9688
		// (get) Token: 0x0601BD82 RID: 114050 RVA: 0x0088622D File Offset: 0x0088462D
		// (set) Token: 0x0601BD83 RID: 114051 RVA: 0x00886235 File Offset: 0x00884635
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

		// Token: 0x170025D9 RID: 9689
		// (get) Token: 0x0601BD84 RID: 114052 RVA: 0x0088623E File Offset: 0x0088463E
		public bool EndOfInput
		{
			get
			{
				return this.end_of_input;
			}
		}

		// Token: 0x170025DA RID: 9690
		// (get) Token: 0x0601BD85 RID: 114053 RVA: 0x00886246 File Offset: 0x00884646
		public bool EndOfJson
		{
			get
			{
				return this.end_of_json;
			}
		}

		// Token: 0x170025DB RID: 9691
		// (get) Token: 0x0601BD86 RID: 114054 RVA: 0x0088624E File Offset: 0x0088464E
		public JsonToken Token
		{
			get
			{
				return this.token;
			}
		}

		// Token: 0x170025DC RID: 9692
		// (get) Token: 0x0601BD87 RID: 114055 RVA: 0x00886256 File Offset: 0x00884656
		public object Value
		{
			get
			{
				return this.token_value;
			}
		}

		// Token: 0x0601BD88 RID: 114056 RVA: 0x00886260 File Offset: 0x00884660
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

		// Token: 0x0601BD89 RID: 114057 RVA: 0x008865D9 File Offset: 0x008849D9
		private static void TableAddCol(ParserToken row, int col, params int[] symbols)
		{
			JsonReader.parse_table[(int)row].Add(col, symbols);
		}

		// Token: 0x0601BD8A RID: 114058 RVA: 0x008865ED File Offset: 0x008849ED
		private static void TableAddRow(ParserToken rule)
		{
			JsonReader.parse_table.Add((int)rule, new Dictionary<int, int[]>());
		}

		// Token: 0x0601BD8B RID: 114059 RVA: 0x00886600 File Offset: 0x00884A00
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

		// Token: 0x0601BD8C RID: 114060 RVA: 0x008866D0 File Offset: 0x00884AD0
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

		// Token: 0x0601BD8D RID: 114061 RVA: 0x00886898 File Offset: 0x00884C98
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

		// Token: 0x0601BD8E RID: 114062 RVA: 0x008868E8 File Offset: 0x00884CE8
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

		// Token: 0x0601BD8F RID: 114063 RVA: 0x00886924 File Offset: 0x00884D24
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

		// Token: 0x04013624 RID: 79396
		private static IDictionary<int, IDictionary<int, int[]>> parse_table;

		// Token: 0x04013625 RID: 79397
		private Stack<int> automaton_stack;

		// Token: 0x04013626 RID: 79398
		private int current_input;

		// Token: 0x04013627 RID: 79399
		private int current_symbol;

		// Token: 0x04013628 RID: 79400
		private bool end_of_json;

		// Token: 0x04013629 RID: 79401
		private bool end_of_input;

		// Token: 0x0401362A RID: 79402
		private Lexer lexer;

		// Token: 0x0401362B RID: 79403
		private bool parser_in_string;

		// Token: 0x0401362C RID: 79404
		private bool parser_return;

		// Token: 0x0401362D RID: 79405
		private bool read_started;

		// Token: 0x0401362E RID: 79406
		private TextReader reader;

		// Token: 0x0401362F RID: 79407
		private bool reader_is_owned;

		// Token: 0x04013630 RID: 79408
		private bool skip_non_members;

		// Token: 0x04013631 RID: 79409
		private object token_value;

		// Token: 0x04013632 RID: 79410
		private JsonToken token;
	}
}
