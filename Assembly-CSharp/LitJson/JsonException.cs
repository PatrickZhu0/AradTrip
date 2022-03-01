using System;

namespace LitJson
{
	// Token: 0x0200469C RID: 18076
	public class JsonException : ApplicationException
	{
		// Token: 0x06019940 RID: 104768 RVA: 0x0080ECA2 File Offset: 0x0080D0A2
		public JsonException()
		{
		}

		// Token: 0x06019941 RID: 104769 RVA: 0x0080ECAA File Offset: 0x0080D0AA
		internal JsonException(ParserToken token) : base(string.Format("Invalid token '{0}' in input string", token))
		{
		}

		// Token: 0x06019942 RID: 104770 RVA: 0x0080ECC2 File Offset: 0x0080D0C2
		internal JsonException(ParserToken token, Exception inner_exception) : base(string.Format("Invalid token '{0}' in input string", token), inner_exception)
		{
		}

		// Token: 0x06019943 RID: 104771 RVA: 0x0080ECDB File Offset: 0x0080D0DB
		internal JsonException(int c) : base(string.Format("Invalid character '{0}' in input string", (char)c))
		{
		}

		// Token: 0x06019944 RID: 104772 RVA: 0x0080ECF4 File Offset: 0x0080D0F4
		internal JsonException(int c, Exception inner_exception) : base(string.Format("Invalid character '{0}' in input string", (char)c), inner_exception)
		{
		}

		// Token: 0x06019945 RID: 104773 RVA: 0x0080ED0E File Offset: 0x0080D10E
		public JsonException(string message) : base(message)
		{
		}

		// Token: 0x06019946 RID: 104774 RVA: 0x0080ED17 File Offset: 0x0080D117
		public JsonException(string message, Exception inner_exception) : base(message, inner_exception)
		{
		}
	}
}
