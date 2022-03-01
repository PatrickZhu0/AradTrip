using System;

namespace Protocol
{
	// Token: 0x020009B2 RID: 2482
	[Protocol]
	public class SceneActivePlantAppraRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F8B RID: 28555 RVA: 0x00141F8C File Offset: 0x0014038C
		public uint GetMsgID()
		{
			return 501097U;
		}

		// Token: 0x06006F8C RID: 28556 RVA: 0x00141F93 File Offset: 0x00140393
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F8D RID: 28557 RVA: 0x00141F9B File Offset: 0x0014039B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F8E RID: 28558 RVA: 0x00141FA4 File Offset: 0x001403A4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06006F8F RID: 28559 RVA: 0x00141FB4 File Offset: 0x001403B4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06006F90 RID: 28560 RVA: 0x00141FC4 File Offset: 0x001403C4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06006F91 RID: 28561 RVA: 0x00141FD4 File Offset: 0x001403D4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06006F92 RID: 28562 RVA: 0x00141FE4 File Offset: 0x001403E4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400329C RID: 12956
		public const uint MsgID = 501097U;

		// Token: 0x0400329D RID: 12957
		public uint Sequence;

		// Token: 0x0400329E RID: 12958
		public uint retCode;
	}
}
