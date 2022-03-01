using System;

namespace Protocol
{
	// Token: 0x02000922 RID: 2338
	[Protocol]
	public class SceneQuickUseItemReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A9F RID: 27295 RVA: 0x00138E0C File Offset: 0x0013720C
		public uint GetMsgID()
		{
			return 500950U;
		}

		// Token: 0x06006AA0 RID: 27296 RVA: 0x00138E13 File Offset: 0x00137213
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006AA1 RID: 27297 RVA: 0x00138E1B File Offset: 0x0013721B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006AA2 RID: 27298 RVA: 0x00138E24 File Offset: 0x00137224
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.idx);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungenid);
		}

		// Token: 0x06006AA3 RID: 27299 RVA: 0x00138E42 File Offset: 0x00137242
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.idx);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungenid);
		}

		// Token: 0x06006AA4 RID: 27300 RVA: 0x00138E60 File Offset: 0x00137260
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.idx);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungenid);
		}

		// Token: 0x06006AA5 RID: 27301 RVA: 0x00138E7E File Offset: 0x0013727E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.idx);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungenid);
		}

		// Token: 0x06006AA6 RID: 27302 RVA: 0x00138E9C File Offset: 0x0013729C
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 4;
		}

		// Token: 0x04003057 RID: 12375
		public const uint MsgID = 500950U;

		// Token: 0x04003058 RID: 12376
		public uint Sequence;

		// Token: 0x04003059 RID: 12377
		public byte idx;

		// Token: 0x0400305A RID: 12378
		public uint dungenid;
	}
}
