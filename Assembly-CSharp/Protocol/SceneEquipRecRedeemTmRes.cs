using System;

namespace Protocol
{
	// Token: 0x02000942 RID: 2370
	[Protocol]
	public class SceneEquipRecRedeemTmRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006BB6 RID: 27574 RVA: 0x0013AA94 File Offset: 0x00138E94
		public uint GetMsgID()
		{
			return 501015U;
		}

		// Token: 0x06006BB7 RID: 27575 RVA: 0x0013AA9B File Offset: 0x00138E9B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006BB8 RID: 27576 RVA: 0x0013AAA3 File Offset: 0x00138EA3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006BB9 RID: 27577 RVA: 0x0013AAAC File Offset: 0x00138EAC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.timestmap);
		}

		// Token: 0x06006BBA RID: 27578 RVA: 0x0013AABC File Offset: 0x00138EBC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.timestmap);
		}

		// Token: 0x06006BBB RID: 27579 RVA: 0x0013AACC File Offset: 0x00138ECC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.timestmap);
		}

		// Token: 0x06006BBC RID: 27580 RVA: 0x0013AADC File Offset: 0x00138EDC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.timestmap);
		}

		// Token: 0x06006BBD RID: 27581 RVA: 0x0013AAEC File Offset: 0x00138EEC
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x040030CB RID: 12491
		public const uint MsgID = 501015U;

		// Token: 0x040030CC RID: 12492
		public uint Sequence;

		// Token: 0x040030CD RID: 12493
		public ulong timestmap;
	}
}
