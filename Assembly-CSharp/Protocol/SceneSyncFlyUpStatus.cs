using System;

namespace Protocol
{
	// Token: 0x02000994 RID: 2452
	[Protocol]
	public class SceneSyncFlyUpStatus : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E86 RID: 28294 RVA: 0x0013FD20 File Offset: 0x0013E120
		public uint GetMsgID()
		{
			return 501070U;
		}

		// Token: 0x06006E87 RID: 28295 RVA: 0x0013FD27 File Offset: 0x0013E127
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E88 RID: 28296 RVA: 0x0013FD2F File Offset: 0x0013E12F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E89 RID: 28297 RVA: 0x0013FD38 File Offset: 0x0013E138
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
		}

		// Token: 0x06006E8A RID: 28298 RVA: 0x0013FD48 File Offset: 0x0013E148
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
		}

		// Token: 0x06006E8B RID: 28299 RVA: 0x0013FD58 File Offset: 0x0013E158
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
		}

		// Token: 0x06006E8C RID: 28300 RVA: 0x0013FD68 File Offset: 0x0013E168
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
		}

		// Token: 0x06006E8D RID: 28301 RVA: 0x0013FD78 File Offset: 0x0013E178
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003210 RID: 12816
		public const uint MsgID = 501070U;

		// Token: 0x04003211 RID: 12817
		public uint Sequence;

		// Token: 0x04003212 RID: 12818
		public byte status;
	}
}
