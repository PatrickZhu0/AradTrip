using System;

namespace Protocol
{
	// Token: 0x02000ABB RID: 2747
	[Protocol]
	public class SceneRetinueUnlockReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007738 RID: 30520 RVA: 0x00158C0C File Offset: 0x0015700C
		public uint GetMsgID()
		{
			return 507007U;
		}

		// Token: 0x06007739 RID: 30521 RVA: 0x00158C13 File Offset: 0x00157013
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600773A RID: 30522 RVA: 0x00158C1B File Offset: 0x0015701B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600773B RID: 30523 RVA: 0x00158C24 File Offset: 0x00157024
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x0600773C RID: 30524 RVA: 0x00158C34 File Offset: 0x00157034
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x0600773D RID: 30525 RVA: 0x00158C44 File Offset: 0x00157044
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x0600773E RID: 30526 RVA: 0x00158C54 File Offset: 0x00157054
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x0600773F RID: 30527 RVA: 0x00158C64 File Offset: 0x00157064
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040037D3 RID: 14291
		public const uint MsgID = 507007U;

		// Token: 0x040037D4 RID: 14292
		public uint Sequence;

		// Token: 0x040037D5 RID: 14293
		public uint id;
	}
}
