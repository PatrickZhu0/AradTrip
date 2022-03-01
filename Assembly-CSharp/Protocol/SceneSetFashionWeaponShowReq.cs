using System;

namespace Protocol
{
	// Token: 0x02000956 RID: 2390
	[Protocol]
	public class SceneSetFashionWeaponShowReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C6A RID: 27754 RVA: 0x0013BE64 File Offset: 0x0013A264
		public uint GetMsgID()
		{
			return 501027U;
		}

		// Token: 0x06006C6B RID: 27755 RVA: 0x0013BE6B File Offset: 0x0013A26B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C6C RID: 27756 RVA: 0x0013BE73 File Offset: 0x0013A273
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C6D RID: 27757 RVA: 0x0013BE7C File Offset: 0x0013A27C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isShow);
		}

		// Token: 0x06006C6E RID: 27758 RVA: 0x0013BE8C File Offset: 0x0013A28C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isShow);
		}

		// Token: 0x06006C6F RID: 27759 RVA: 0x0013BE9C File Offset: 0x0013A29C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isShow);
		}

		// Token: 0x06006C70 RID: 27760 RVA: 0x0013BEAC File Offset: 0x0013A2AC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isShow);
		}

		// Token: 0x06006C71 RID: 27761 RVA: 0x0013BEBC File Offset: 0x0013A2BC
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x0400310F RID: 12559
		public const uint MsgID = 501027U;

		// Token: 0x04003110 RID: 12560
		public uint Sequence;

		// Token: 0x04003111 RID: 12561
		public byte isShow;
	}
}
