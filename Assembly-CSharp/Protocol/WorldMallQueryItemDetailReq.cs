using System;

namespace Protocol
{
	// Token: 0x02000915 RID: 2325
	[Protocol]
	public class WorldMallQueryItemDetailReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A2D RID: 27181 RVA: 0x001382EF File Offset: 0x001366EF
		public uint GetMsgID()
		{
			return 602805U;
		}

		// Token: 0x06006A2E RID: 27182 RVA: 0x001382F6 File Offset: 0x001366F6
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A2F RID: 27183 RVA: 0x001382FE File Offset: 0x001366FE
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A30 RID: 27184 RVA: 0x00138307 File Offset: 0x00136707
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mallItemId);
		}

		// Token: 0x06006A31 RID: 27185 RVA: 0x00138317 File Offset: 0x00136717
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mallItemId);
		}

		// Token: 0x06006A32 RID: 27186 RVA: 0x00138327 File Offset: 0x00136727
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mallItemId);
		}

		// Token: 0x06006A33 RID: 27187 RVA: 0x00138337 File Offset: 0x00136737
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mallItemId);
		}

		// Token: 0x06006A34 RID: 27188 RVA: 0x00138348 File Offset: 0x00136748
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003027 RID: 12327
		public const uint MsgID = 602805U;

		// Token: 0x04003028 RID: 12328
		public uint Sequence;

		// Token: 0x04003029 RID: 12329
		public uint mallItemId;
	}
}
