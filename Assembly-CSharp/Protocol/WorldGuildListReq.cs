using System;

namespace Protocol
{
	// Token: 0x0200082F RID: 2095
	[Protocol]
	public class WorldGuildListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006319 RID: 25369 RVA: 0x00129E9C File Offset: 0x0012829C
		public uint GetMsgID()
		{
			return 601907U;
		}

		// Token: 0x0600631A RID: 25370 RVA: 0x00129EA3 File Offset: 0x001282A3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600631B RID: 25371 RVA: 0x00129EAB File Offset: 0x001282AB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600631C RID: 25372 RVA: 0x00129EB4 File Offset: 0x001282B4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.start);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x0600631D RID: 25373 RVA: 0x00129ED2 File Offset: 0x001282D2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.start);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x0600631E RID: 25374 RVA: 0x00129EF0 File Offset: 0x001282F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.start);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x0600631F RID: 25375 RVA: 0x00129F0E File Offset: 0x0012830E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.start);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006320 RID: 25376 RVA: 0x00129F2C File Offset: 0x0012832C
		public int getLen()
		{
			int num = 0;
			num += 2;
			return num + 2;
		}

		// Token: 0x04002C85 RID: 11397
		public const uint MsgID = 601907U;

		// Token: 0x04002C86 RID: 11398
		public uint Sequence;

		// Token: 0x04002C87 RID: 11399
		public ushort start;

		// Token: 0x04002C88 RID: 11400
		public ushort num;
	}
}
