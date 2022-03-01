using System;
using System.Collections.Generic;

namespace SharpJson
{
	// Token: 0x020049C9 RID: 18889
	public class JsonDecoder
	{
		// Token: 0x0601B31B RID: 111387 RVA: 0x0085AEFE File Offset: 0x008592FE
		public JsonDecoder()
		{
			this.errorMessage = null;
			this.parseNumbersAsFloat = false;
		}

		// Token: 0x17002396 RID: 9110
		// (get) Token: 0x0601B31C RID: 111388 RVA: 0x0085AF14 File Offset: 0x00859314
		// (set) Token: 0x0601B31D RID: 111389 RVA: 0x0085AF1C File Offset: 0x0085931C
		public string errorMessage { get; private set; }

		// Token: 0x17002397 RID: 9111
		// (get) Token: 0x0601B31E RID: 111390 RVA: 0x0085AF25 File Offset: 0x00859325
		// (set) Token: 0x0601B31F RID: 111391 RVA: 0x0085AF2D File Offset: 0x0085932D
		public bool parseNumbersAsFloat { get; set; }

		// Token: 0x0601B320 RID: 111392 RVA: 0x0085AF36 File Offset: 0x00859336
		public object Decode(string text)
		{
			this.errorMessage = null;
			this.lexer = new Lexer(text);
			this.lexer.parseNumbersAsFloat = this.parseNumbersAsFloat;
			return this.ParseValue();
		}

		// Token: 0x0601B321 RID: 111393 RVA: 0x0085AF64 File Offset: 0x00859364
		public static object DecodeText(string text)
		{
			JsonDecoder jsonDecoder = new JsonDecoder();
			return jsonDecoder.Decode(text);
		}

		// Token: 0x0601B322 RID: 111394 RVA: 0x0085AF80 File Offset: 0x00859380
		private IDictionary<string, object> ParseObject()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			this.lexer.NextToken();
			for (;;)
			{
				Lexer.Token token = this.lexer.LookAhead();
				if (token == Lexer.Token.None)
				{
					break;
				}
				if (token != Lexer.Token.Comma)
				{
					if (token == Lexer.Token.CurlyClose)
					{
						goto IL_56;
					}
					string key = this.EvalLexer<string>(this.lexer.ParseString());
					if (this.errorMessage != null)
					{
						goto Block_4;
					}
					token = this.lexer.NextToken();
					if (token != Lexer.Token.Colon)
					{
						goto Block_5;
					}
					object value = this.ParseValue();
					if (this.errorMessage != null)
					{
						goto Block_6;
					}
					dictionary[key] = value;
				}
				else
				{
					this.lexer.NextToken();
				}
			}
			this.TriggerError("Invalid token");
			return null;
			IL_56:
			this.lexer.NextToken();
			return dictionary;
			Block_4:
			return null;
			Block_5:
			this.TriggerError("Invalid token; expected ':'");
			return null;
			Block_6:
			return null;
		}

		// Token: 0x0601B323 RID: 111395 RVA: 0x0085B058 File Offset: 0x00859458
		private IList<object> ParseArray()
		{
			List<object> list = new List<object>();
			this.lexer.NextToken();
			for (;;)
			{
				Lexer.Token token = this.lexer.LookAhead();
				if (token == Lexer.Token.None)
				{
					break;
				}
				if (token != Lexer.Token.Comma)
				{
					if (token == Lexer.Token.SquaredClose)
					{
						goto IL_56;
					}
					object item = this.ParseValue();
					if (this.errorMessage != null)
					{
						goto Block_4;
					}
					list.Add(item);
				}
				else
				{
					this.lexer.NextToken();
				}
			}
			this.TriggerError("Invalid token");
			return null;
			IL_56:
			this.lexer.NextToken();
			return list;
			Block_4:
			return null;
		}

		// Token: 0x0601B324 RID: 111396 RVA: 0x0085B0F0 File Offset: 0x008594F0
		private object ParseValue()
		{
			switch (this.lexer.LookAhead())
			{
			case Lexer.Token.Null:
				this.lexer.NextToken();
				return null;
			case Lexer.Token.True:
				this.lexer.NextToken();
				return true;
			case Lexer.Token.False:
				this.lexer.NextToken();
				return false;
			case Lexer.Token.String:
				return this.EvalLexer<string>(this.lexer.ParseString());
			case Lexer.Token.Number:
				if (this.parseNumbersAsFloat)
				{
					return this.EvalLexer<float>(this.lexer.ParseFloatNumber());
				}
				return this.EvalLexer<double>(this.lexer.ParseDoubleNumber());
			case Lexer.Token.CurlyOpen:
				return this.ParseObject();
			case Lexer.Token.SquaredOpen:
				return this.ParseArray();
			}
			this.TriggerError("Unable to parse value");
			return null;
		}

		// Token: 0x0601B325 RID: 111397 RVA: 0x0085B1DE File Offset: 0x008595DE
		private void TriggerError(string message)
		{
			this.errorMessage = string.Format("Error: '{0}' at line {1}", message, this.lexer.lineNumber);
		}

		// Token: 0x0601B326 RID: 111398 RVA: 0x0085B201 File Offset: 0x00859601
		private T EvalLexer<T>(T value)
		{
			if (this.lexer.hasError)
			{
				this.TriggerError("Lexical error ocurred");
			}
			return value;
		}

		// Token: 0x04012F4D RID: 77645
		private Lexer lexer;
	}
}
