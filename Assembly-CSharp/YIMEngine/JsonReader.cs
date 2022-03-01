using System;
using System.Collections.Generic;
using System.IO;

namespace YIMEngine
{
	// Token: 0x02004A85 RID: 19077
	public class JsonReader
	{
		// Token: 0x0601BAA4 RID: 113316 RVA: 0x0087E345 File Offset: 0x0087C745
		static JsonReader()
		{
			JsonReader.PopulateParseTable();
		}

		// Token: 0x0601BAA5 RID: 113317 RVA: 0x0087E34C File Offset: 0x0087C74C
		public JsonReader(string json_text) : this(new StringReader(json_text), true)
		{
		}

		// Token: 0x0601BAA6 RID: 113318 RVA: 0x0087E35B File Offset: 0x0087C75B
		public JsonReader(TextReader reader) : this(reader, false)
		{
		}

		// Token: 0x0601BAA7 RID: 113319 RVA: 0x0087E368 File Offset: 0x0087C768
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

		// Token: 0x1700252A RID: 9514
		// (get) Token: 0x0601BAA8 RID: 113320 RVA: 0x0087E3FB File Offset: 0x0087C7FB
		// (set) Token: 0x0601BAA9 RID: 113321 RVA: 0x0087E408 File Offset: 0x0087C808
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

		// Token: 0x1700252B RID: 9515
		// (get) Token: 0x0601BAAA RID: 113322 RVA: 0x0087E416 File Offset: 0x0087C816
		// (set) Token: 0x0601BAAB RID: 113323 RVA: 0x0087E423 File Offset: 0x0087C823
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

		// Token: 0x1700252C RID: 9516
		// (get) Token: 0x0601BAAC RID: 113324 RVA: 0x0087E431 File Offset: 0x0087C831
		// (set) Token: 0x0601BAAD RID: 113325 RVA: 0x0087E439 File Offset: 0x0087C839
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

		// Token: 0x1700252D RID: 9517
		// (get) Token: 0x0601BAAE RID: 113326 RVA: 0x0087E442 File Offset: 0x0087C842
		public bool EndOfInput
		{
			get
			{
				return this.end_of_input;
			}
		}

		// Token: 0x1700252E RID: 9518
		// (get) Token: 0x0601BAAF RID: 113327 RVA: 0x0087E44A File Offset: 0x0087C84A
		public bool EndOfJson
		{
			get
			{
				return this.end_of_json;
			}
		}

		// Token: 0x1700252F RID: 9519
		// (get) Token: 0x0601BAB0 RID: 113328 RVA: 0x0087E452 File Offset: 0x0087C852
		public JsonToken Token
		{
			get
			{
				return this.token;
			}
		}

		// Token: 0x17002530 RID: 9520
		// (get) Token: 0x0601BAB1 RID: 113329 RVA: 0x0087E45A File Offset: 0x0087C85A
		public object Value
		{
			get
			{
				return this.token_value;
			}
		}

		// Token: 0x0601BAB2 RID: 113330 RVA: 0x0087E464 File Offset: 0x0087C864
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

		// Token: 0x0601BAB3 RID: 113331 RVA: 0x0087E7DD File Offset: 0x0087CBDD
		private static void TableAddCol(ParserToken row, int col, params int[] symbols)
		{
			JsonReader.parse_table[(int)row].Add(col, symbols);
		}

		// Token: 0x0601BAB4 RID: 113332 RVA: 0x0087E7F1 File Offset: 0x0087CBF1
		private static void TableAddRow(ParserToken rule)
		{
			JsonReader.parse_table.Add((int)rule, new Dictionary<int, int[]>());
		}

		// Token: 0x0601BAB5 RID: 113333 RVA: 0x0087E804 File Offset: 0x0087CC04
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

		// Token: 0x0601BAB6 RID: 113334 RVA: 0x0087E8D4 File Offset: 0x0087CCD4
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

		// Token: 0x0601BAB7 RID: 113335 RVA: 0x0087EA9C File Offset: 0x0087CE9C
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

		// Token: 0x0601BAB8 RID: 113336 RVA: 0x0087EAEC File Offset: 0x0087CEEC
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

		// Token: 0x0601BAB9 RID: 113337 RVA: 0x0087EB28 File Offset: 0x0087CF28
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

		// Token: 0x0401345E RID: 78942
		private static IDictionary<int, IDictionary<int, int[]>> parse_table;

		// Token: 0x0401345F RID: 78943
		private Stack<int> automaton_stack;

		// Token: 0x04013460 RID: 78944
		private int current_input;

		// Token: 0x04013461 RID: 78945
		private int current_symbol;

		// Token: 0x04013462 RID: 78946
		private bool end_of_json;

		// Token: 0x04013463 RID: 78947
		private bool end_of_input;

		// Token: 0x04013464 RID: 78948
		private Lexer lexer;

		// Token: 0x04013465 RID: 78949
		private bool parser_in_string;

		// Token: 0x04013466 RID: 78950
		private bool parser_return;

		// Token: 0x04013467 RID: 78951
		private bool read_started;

		// Token: 0x04013468 RID: 78952
		private TextReader reader;

		// Token: 0x04013469 RID: 78953
		private bool reader_is_owned;

		// Token: 0x0401346A RID: 78954
		private bool skip_non_members;

		// Token: 0x0401346B RID: 78955
		private object token_value;

		// Token: 0x0401346C RID: 78956
		private JsonToken token;
	}
}
