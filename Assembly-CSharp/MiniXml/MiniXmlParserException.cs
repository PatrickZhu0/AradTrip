using System;

namespace MiniXml
{
	// Token: 0x02004808 RID: 18440
	internal class MiniXmlParserException : SystemException
	{
		// Token: 0x0601A7F4 RID: 108532 RVA: 0x00834595 File Offset: 0x00832995
		public MiniXmlParserException(string msg, int line, int column) : base(string.Format("{0}. At ({1},{2})", msg, line, column))
		{
			this.line = line;
			this.column = column;
		}

		// Token: 0x1700227E RID: 8830
		// (get) Token: 0x0601A7F5 RID: 108533 RVA: 0x008345C2 File Offset: 0x008329C2
		public int Line
		{
			get
			{
				return this.line;
			}
		}

		// Token: 0x1700227F RID: 8831
		// (get) Token: 0x0601A7F6 RID: 108534 RVA: 0x008345CA File Offset: 0x008329CA
		public int Column
		{
			get
			{
				return this.column;
			}
		}

		// Token: 0x04012926 RID: 76070
		private int line;

		// Token: 0x04012927 RID: 76071
		private int column;
	}
}
