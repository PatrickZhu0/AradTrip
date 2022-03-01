using System;

namespace Protocol
{
	// Token: 0x020009A7 RID: 2471
	[Protocol]
	public class SceneMoveItem : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F2B RID: 28459 RVA: 0x001413F7 File Offset: 0x0013F7F7
		public uint GetMsgID()
		{
			return 500962U;
		}

		// Token: 0x06006F2C RID: 28460 RVA: 0x001413FE File Offset: 0x0013F7FE
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F2D RID: 28461 RVA: 0x00141406 File Offset: 0x0013F806
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F2E RID: 28462 RVA: 0x0014140F File Offset: 0x0013F80F
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
			this.targetPos.encode(buffer, ref pos_);
		}

		// Token: 0x06006F2F RID: 28463 RVA: 0x0014143A File Offset: 0x0013F83A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
			this.targetPos.decode(buffer, ref pos_);
		}

		// Token: 0x06006F30 RID: 28464 RVA: 0x00141465 File Offset: 0x0013F865
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
			this.targetPos.encode(buffer, ref pos_);
		}

		// Token: 0x06006F31 RID: 28465 RVA: 0x00141490 File Offset: 0x0013F890
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
			this.targetPos.decode(buffer, ref pos_);
		}

		// Token: 0x06006F32 RID: 28466 RVA: 0x001414BC File Offset: 0x0013F8BC
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 2;
			return num + this.targetPos.getLen();
		}

		// Token: 0x0400326F RID: 12911
		public const uint MsgID = 500962U;

		// Token: 0x04003270 RID: 12912
		public uint Sequence;

		// Token: 0x04003271 RID: 12913
		public ulong itemId;

		// Token: 0x04003272 RID: 12914
		public ushort num;

		// Token: 0x04003273 RID: 12915
		public ItemPos targetPos = new ItemPos();
	}
}
