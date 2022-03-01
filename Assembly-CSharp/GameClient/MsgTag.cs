using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001544 RID: 5444
	public class MsgTag
	{
		// Token: 0x17001BF9 RID: 7161
		// (get) Token: 0x0600D4A1 RID: 54433 RVA: 0x00351329 File Offset: 0x0034F729
		// (set) Token: 0x0600D4A2 RID: 54434 RVA: 0x00351331 File Offset: 0x0034F731
		public char Type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
			}
		}

		// Token: 0x17001BFA RID: 7162
		// (get) Token: 0x0600D4A3 RID: 54435 RVA: 0x0035133A File Offset: 0x0034F73A
		public List<string> Parms
		{
			get
			{
				return this._parms;
			}
		}

		// Token: 0x17001BFB RID: 7163
		// (get) Token: 0x0600D4A4 RID: 54436 RVA: 0x00351342 File Offset: 0x0034F742
		// (set) Token: 0x0600D4A5 RID: 54437 RVA: 0x0035134A File Offset: 0x0034F74A
		public string Content
		{
			get
			{
				return this._content;
			}
			set
			{
				this._content = value;
			}
		}

		// Token: 0x17001BFC RID: 7164
		// (get) Token: 0x0600D4A6 RID: 54438 RVA: 0x00351353 File Offset: 0x0034F753
		public static char[] MsgTags
		{
			get
			{
				return MsgTag.s_MSG_TAGS;
			}
		}

		// Token: 0x17001BFD RID: 7165
		// (get) Token: 0x0600D4A7 RID: 54439 RVA: 0x0035135A File Offset: 0x0034F75A
		public static byte TagNum
		{
			get
			{
				return MsgTag.s_tagNum;
			}
		}

		// Token: 0x04007CE1 RID: 31969
		private static readonly byte s_tagNum = 12;

		// Token: 0x04007CE2 RID: 31970
		private static readonly char[] s_MSG_TAGS = new char[]
		{
			'T',
			'L',
			'I',
			'F',
			'W',
			'N',
			'C',
			'E',
			'M',
			'O',
			'P',
			'B'
		};

		// Token: 0x04007CE3 RID: 31971
		protected char _type;

		// Token: 0x04007CE4 RID: 31972
		protected List<string> _parms = new List<string>();

		// Token: 0x04007CE5 RID: 31973
		protected string _content;
	}
}
