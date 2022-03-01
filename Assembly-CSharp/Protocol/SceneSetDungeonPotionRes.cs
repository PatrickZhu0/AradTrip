using System;

namespace Protocol
{
	// Token: 0x0200092F RID: 2351
	[Protocol]
	public class SceneSetDungeonPotionRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B11 RID: 27409 RVA: 0x001399F8 File Offset: 0x00137DF8
		public uint GetMsgID()
		{
			return 500965U;
		}

		// Token: 0x06006B12 RID: 27410 RVA: 0x001399FF File Offset: 0x00137DFF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B13 RID: 27411 RVA: 0x00139A07 File Offset: 0x00137E07
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B14 RID: 27412 RVA: 0x00139A10 File Offset: 0x00137E10
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006B15 RID: 27413 RVA: 0x00139A20 File Offset: 0x00137E20
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006B16 RID: 27414 RVA: 0x00139A30 File Offset: 0x00137E30
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006B17 RID: 27415 RVA: 0x00139A40 File Offset: 0x00137E40
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006B18 RID: 27416 RVA: 0x00139A50 File Offset: 0x00137E50
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400308C RID: 12428
		public const uint MsgID = 500965U;

		// Token: 0x0400308D RID: 12429
		public uint Sequence;

		// Token: 0x0400308E RID: 12430
		public uint code;
	}
}
