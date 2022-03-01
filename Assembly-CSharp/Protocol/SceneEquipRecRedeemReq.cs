using System;

namespace Protocol
{
	// Token: 0x0200093D RID: 2365
	[Protocol]
	public class SceneEquipRecRedeemReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B89 RID: 27529 RVA: 0x0013A811 File Offset: 0x00138C11
		public uint GetMsgID()
		{
			return 501010U;
		}

		// Token: 0x06006B8A RID: 27530 RVA: 0x0013A818 File Offset: 0x00138C18
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B8B RID: 27531 RVA: 0x0013A820 File Offset: 0x00138C20
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B8C RID: 27532 RVA: 0x0013A829 File Offset: 0x00138C29
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.equid);
		}

		// Token: 0x06006B8D RID: 27533 RVA: 0x0013A839 File Offset: 0x00138C39
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equid);
		}

		// Token: 0x06006B8E RID: 27534 RVA: 0x0013A849 File Offset: 0x00138C49
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.equid);
		}

		// Token: 0x06006B8F RID: 27535 RVA: 0x0013A859 File Offset: 0x00138C59
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equid);
		}

		// Token: 0x06006B90 RID: 27536 RVA: 0x0013A86C File Offset: 0x00138C6C
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x040030BB RID: 12475
		public const uint MsgID = 501010U;

		// Token: 0x040030BC RID: 12476
		public uint Sequence;

		// Token: 0x040030BD RID: 12477
		public ulong equid;
	}
}
