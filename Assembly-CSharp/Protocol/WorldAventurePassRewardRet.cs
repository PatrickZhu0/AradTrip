using System;

namespace Protocol
{
	// Token: 0x02000C2A RID: 3114
	[Protocol]
	public class WorldAventurePassRewardRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060081FA RID: 33274 RVA: 0x0016E46C File Offset: 0x0016C86C
		public uint GetMsgID()
		{
			return 609510U;
		}

		// Token: 0x060081FB RID: 33275 RVA: 0x0016E473 File Offset: 0x0016C873
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060081FC RID: 33276 RVA: 0x0016E47B File Offset: 0x0016C87B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060081FD RID: 33277 RVA: 0x0016E484 File Offset: 0x0016C884
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lv);
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x060081FE RID: 33278 RVA: 0x0016E4A2 File Offset: 0x0016C8A2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lv);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x060081FF RID: 33279 RVA: 0x0016E4C0 File Offset: 0x0016C8C0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lv);
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x06008200 RID: 33280 RVA: 0x0016E4DE File Offset: 0x0016C8DE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lv);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x06008201 RID: 33281 RVA: 0x0016E4FC File Offset: 0x0016C8FC
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003E02 RID: 15874
		public const uint MsgID = 609510U;

		// Token: 0x04003E03 RID: 15875
		public uint Sequence;

		// Token: 0x04003E04 RID: 15876
		public uint lv;

		// Token: 0x04003E05 RID: 15877
		public uint errorCode;
	}
}
