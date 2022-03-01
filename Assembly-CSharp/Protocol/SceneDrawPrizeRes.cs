using System;

namespace Protocol
{
	// Token: 0x02000939 RID: 2361
	[Protocol]
	public class SceneDrawPrizeRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B68 RID: 27496 RVA: 0x0013A2E0 File Offset: 0x001386E0
		public uint GetMsgID()
		{
			return 501007U;
		}

		// Token: 0x06006B69 RID: 27497 RVA: 0x0013A2E7 File Offset: 0x001386E7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B6A RID: 27498 RVA: 0x0013A2EF File Offset: 0x001386EF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B6B RID: 27499 RVA: 0x0013A2F8 File Offset: 0x001386F8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.drawPrizeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.rewardId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06006B6C RID: 27500 RVA: 0x0013A324 File Offset: 0x00138724
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.drawPrizeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rewardId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06006B6D RID: 27501 RVA: 0x0013A350 File Offset: 0x00138750
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.drawPrizeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.rewardId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06006B6E RID: 27502 RVA: 0x0013A37C File Offset: 0x0013877C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.drawPrizeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rewardId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06006B6F RID: 27503 RVA: 0x0013A3A8 File Offset: 0x001387A8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040030AC RID: 12460
		public const uint MsgID = 501007U;

		// Token: 0x040030AD RID: 12461
		public uint Sequence;

		// Token: 0x040030AE RID: 12462
		public uint drawPrizeId;

		// Token: 0x040030AF RID: 12463
		public uint rewardId;

		// Token: 0x040030B0 RID: 12464
		public uint retCode;
	}
}
