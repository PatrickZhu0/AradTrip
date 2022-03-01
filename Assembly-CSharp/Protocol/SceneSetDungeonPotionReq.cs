using System;

namespace Protocol
{
	// Token: 0x0200092E RID: 2350
	[Protocol]
	public class SceneSetDungeonPotionReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B08 RID: 27400 RVA: 0x00139945 File Offset: 0x00137D45
		public uint GetMsgID()
		{
			return 500964U;
		}

		// Token: 0x06006B09 RID: 27401 RVA: 0x0013994C File Offset: 0x00137D4C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B0A RID: 27402 RVA: 0x00139954 File Offset: 0x00137D54
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B0B RID: 27403 RVA: 0x0013995D File Offset: 0x00137D5D
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.potionId);
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
		}

		// Token: 0x06006B0C RID: 27404 RVA: 0x0013997B File Offset: 0x00137D7B
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.potionId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
		}

		// Token: 0x06006B0D RID: 27405 RVA: 0x00139999 File Offset: 0x00137D99
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.potionId);
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
		}

		// Token: 0x06006B0E RID: 27406 RVA: 0x001399B7 File Offset: 0x00137DB7
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.potionId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
		}

		// Token: 0x06006B0F RID: 27407 RVA: 0x001399D8 File Offset: 0x00137DD8
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x04003088 RID: 12424
		public const uint MsgID = 500964U;

		// Token: 0x04003089 RID: 12425
		public uint Sequence;

		// Token: 0x0400308A RID: 12426
		public uint potionId;

		// Token: 0x0400308B RID: 12427
		public byte pos;
	}
}
