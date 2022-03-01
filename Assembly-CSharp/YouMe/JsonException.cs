using System;

namespace YouMe
{
	// Token: 0x02004AC8 RID: 19144
	public class JsonException : ApplicationException
	{
		// Token: 0x0601BCE9 RID: 113897 RVA: 0x008847B6 File Offset: 0x00882BB6
		public JsonException()
		{
		}

		// Token: 0x0601BCEA RID: 113898 RVA: 0x008847BE File Offset: 0x00882BBE
		internal JsonException(ParserToken token) : base(string.Format("Invalid token '{0}' in input string", token))
		{
		}

		// Token: 0x0601BCEB RID: 113899 RVA: 0x008847D6 File Offset: 0x00882BD6
		internal JsonException(ParserToken token, Exception inner_exception) : base(string.Format("Invalid token '{0}' in input string", token), inner_exception)
		{
		}

		// Token: 0x0601BCEC RID: 113900 RVA: 0x008847EF File Offset: 0x00882BEF
		internal JsonException(int c) : base(string.Format("Invalid character '{0}' in input string", (char)c))
		{
		}

		// Token: 0x0601BCED RID: 113901 RVA: 0x00884808 File Offset: 0x00882C08
		internal JsonException(int c, Exception inner_exception) : base(string.Format("Invalid character '{0}' in input string", (char)c), inner_exception)
		{
		}

		// Token: 0x0601BCEE RID: 113902 RVA: 0x00884822 File Offset: 0x00882C22
		public JsonException(string message) : base(message)
		{
		}

		// Token: 0x0601BCEF RID: 113903 RVA: 0x0088482B File Offset: 0x00882C2B
		public JsonException(string message, Exception inner_exception) : base(message, inner_exception)
		{
		}
	}
}
