using System;

namespace YIMEngine
{
	// Token: 0x02004A79 RID: 19065
	public class JsonException : ApplicationException
	{
		// Token: 0x0601BA13 RID: 113171 RVA: 0x0087C9BA File Offset: 0x0087ADBA
		public JsonException()
		{
		}

		// Token: 0x0601BA14 RID: 113172 RVA: 0x0087C9C2 File Offset: 0x0087ADC2
		internal JsonException(ParserToken token) : base(string.Format("Invalid token '{0}' in input string", token))
		{
		}

		// Token: 0x0601BA15 RID: 113173 RVA: 0x0087C9DA File Offset: 0x0087ADDA
		internal JsonException(ParserToken token, Exception inner_exception) : base(string.Format("Invalid token '{0}' in input string", token), inner_exception)
		{
		}

		// Token: 0x0601BA16 RID: 113174 RVA: 0x0087C9F3 File Offset: 0x0087ADF3
		internal JsonException(int c) : base(string.Format("Invalid character '{0}' in input string", (char)c))
		{
		}

		// Token: 0x0601BA17 RID: 113175 RVA: 0x0087CA0C File Offset: 0x0087AE0C
		internal JsonException(int c, Exception inner_exception) : base(string.Format("Invalid character '{0}' in input string", (char)c), inner_exception)
		{
		}

		// Token: 0x0601BA18 RID: 113176 RVA: 0x0087CA26 File Offset: 0x0087AE26
		public JsonException(string message) : base(message)
		{
		}

		// Token: 0x0601BA19 RID: 113177 RVA: 0x0087CA2F File Offset: 0x0087AE2F
		public JsonException(string message, Exception inner_exception) : base(message, inner_exception)
		{
		}
	}
}
