using System;

namespace Protocol
{
	// Token: 0x02000904 RID: 2308
	[Protocol]
	public class SceneJarPointRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006994 RID: 27028 RVA: 0x00137070 File Offset: 0x00135470
		public uint GetMsgID()
		{
			return 500961U;
		}

		// Token: 0x06006995 RID: 27029 RVA: 0x00137077 File Offset: 0x00135477
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006996 RID: 27030 RVA: 0x0013707F File Offset: 0x0013547F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006997 RID: 27031 RVA: 0x00137088 File Offset: 0x00135488
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.goldPoint);
			BaseDLL.encode_uint32(buffer, ref pos_, this.magPoint);
		}

		// Token: 0x06006998 RID: 27032 RVA: 0x001370A6 File Offset: 0x001354A6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goldPoint);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.magPoint);
		}

		// Token: 0x06006999 RID: 27033 RVA: 0x001370C4 File Offset: 0x001354C4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.goldPoint);
			BaseDLL.encode_uint32(buffer, ref pos_, this.magPoint);
		}

		// Token: 0x0600699A RID: 27034 RVA: 0x001370E2 File Offset: 0x001354E2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goldPoint);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.magPoint);
		}

		// Token: 0x0600699B RID: 27035 RVA: 0x00137100 File Offset: 0x00135500
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002FDB RID: 12251
		public const uint MsgID = 500961U;

		// Token: 0x04002FDC RID: 12252
		public uint Sequence;

		// Token: 0x04002FDD RID: 12253
		public uint goldPoint;

		// Token: 0x04002FDE RID: 12254
		public uint magPoint;
	}
}
