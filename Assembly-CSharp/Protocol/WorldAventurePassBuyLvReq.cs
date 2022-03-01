using System;

namespace Protocol
{
	// Token: 0x02000C25 RID: 3109
	[Protocol]
	public class WorldAventurePassBuyLvReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060081CD RID: 33229 RVA: 0x0016E228 File Offset: 0x0016C628
		public uint GetMsgID()
		{
			return 609505U;
		}

		// Token: 0x060081CE RID: 33230 RVA: 0x0016E22F File Offset: 0x0016C62F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060081CF RID: 33231 RVA: 0x0016E237 File Offset: 0x0016C637
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060081D0 RID: 33232 RVA: 0x0016E240 File Offset: 0x0016C640
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lv);
		}

		// Token: 0x060081D1 RID: 33233 RVA: 0x0016E250 File Offset: 0x0016C650
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lv);
		}

		// Token: 0x060081D2 RID: 33234 RVA: 0x0016E260 File Offset: 0x0016C660
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lv);
		}

		// Token: 0x060081D3 RID: 33235 RVA: 0x0016E270 File Offset: 0x0016C670
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lv);
		}

		// Token: 0x060081D4 RID: 33236 RVA: 0x0016E280 File Offset: 0x0016C680
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003DF3 RID: 15859
		public const uint MsgID = 609505U;

		// Token: 0x04003DF4 RID: 15860
		public uint Sequence;

		// Token: 0x04003DF5 RID: 15861
		public uint lv;
	}
}
