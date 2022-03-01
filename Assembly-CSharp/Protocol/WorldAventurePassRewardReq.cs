using System;

namespace Protocol
{
	// Token: 0x02000C29 RID: 3113
	[Protocol]
	public class WorldAventurePassRewardReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060081F1 RID: 33265 RVA: 0x0016E3F8 File Offset: 0x0016C7F8
		public uint GetMsgID()
		{
			return 609509U;
		}

		// Token: 0x060081F2 RID: 33266 RVA: 0x0016E3FF File Offset: 0x0016C7FF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060081F3 RID: 33267 RVA: 0x0016E407 File Offset: 0x0016C807
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060081F4 RID: 33268 RVA: 0x0016E410 File Offset: 0x0016C810
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lv);
		}

		// Token: 0x060081F5 RID: 33269 RVA: 0x0016E420 File Offset: 0x0016C820
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lv);
		}

		// Token: 0x060081F6 RID: 33270 RVA: 0x0016E430 File Offset: 0x0016C830
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lv);
		}

		// Token: 0x060081F7 RID: 33271 RVA: 0x0016E440 File Offset: 0x0016C840
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lv);
		}

		// Token: 0x060081F8 RID: 33272 RVA: 0x0016E450 File Offset: 0x0016C850
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003DFF RID: 15871
		public const uint MsgID = 609509U;

		// Token: 0x04003E00 RID: 15872
		public uint Sequence;

		// Token: 0x04003E01 RID: 15873
		public uint lv;
	}
}
