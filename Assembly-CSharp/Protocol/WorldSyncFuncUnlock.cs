using System;

namespace Protocol
{
	// Token: 0x02000B48 RID: 2888
	[Protocol]
	public class WorldSyncFuncUnlock : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007B4F RID: 31567 RVA: 0x00160E54 File Offset: 0x0015F254
		public uint GetMsgID()
		{
			return 601201U;
		}

		// Token: 0x06007B50 RID: 31568 RVA: 0x00160E5B File Offset: 0x0015F25B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B51 RID: 31569 RVA: 0x00160E63 File Offset: 0x0015F263
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B52 RID: 31570 RVA: 0x00160E6C File Offset: 0x0015F26C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.funcId);
		}

		// Token: 0x06007B53 RID: 31571 RVA: 0x00160E7C File Offset: 0x0015F27C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.funcId);
		}

		// Token: 0x06007B54 RID: 31572 RVA: 0x00160E8C File Offset: 0x0015F28C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.funcId);
		}

		// Token: 0x06007B55 RID: 31573 RVA: 0x00160E9C File Offset: 0x0015F29C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.funcId);
		}

		// Token: 0x06007B56 RID: 31574 RVA: 0x00160EAC File Offset: 0x0015F2AC
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003A65 RID: 14949
		public const uint MsgID = 601201U;

		// Token: 0x04003A66 RID: 14950
		public uint Sequence;

		// Token: 0x04003A67 RID: 14951
		public byte funcId;
	}
}
