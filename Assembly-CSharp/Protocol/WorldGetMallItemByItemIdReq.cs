using System;

namespace Protocol
{
	// Token: 0x02000918 RID: 2328
	[Protocol]
	public class WorldGetMallItemByItemIdReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A45 RID: 27205 RVA: 0x001385AD File Offset: 0x001369AD
		public uint GetMsgID()
		{
			return 602821U;
		}

		// Token: 0x06006A46 RID: 27206 RVA: 0x001385B4 File Offset: 0x001369B4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A47 RID: 27207 RVA: 0x001385BC File Offset: 0x001369BC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A48 RID: 27208 RVA: 0x001385C5 File Offset: 0x001369C5
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
		}

		// Token: 0x06006A49 RID: 27209 RVA: 0x001385D5 File Offset: 0x001369D5
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
		}

		// Token: 0x06006A4A RID: 27210 RVA: 0x001385E5 File Offset: 0x001369E5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
		}

		// Token: 0x06006A4B RID: 27211 RVA: 0x001385F5 File Offset: 0x001369F5
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
		}

		// Token: 0x06006A4C RID: 27212 RVA: 0x00138608 File Offset: 0x00136A08
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400302F RID: 12335
		public const uint MsgID = 602821U;

		// Token: 0x04003030 RID: 12336
		public uint Sequence;

		// Token: 0x04003031 RID: 12337
		public uint itemId;
	}
}
