using System;

namespace Protocol
{
	// Token: 0x02000712 RID: 1810
	[Protocol]
	public class SceneBattleEnterBattleRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B18 RID: 23320 RVA: 0x001146FC File Offset: 0x00112AFC
		public uint GetMsgID()
		{
			return 508926U;
		}

		// Token: 0x06005B19 RID: 23321 RVA: 0x00114703 File Offset: 0x00112B03
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B1A RID: 23322 RVA: 0x0011470B File Offset: 0x00112B0B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B1B RID: 23323 RVA: 0x00114714 File Offset: 0x00112B14
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06005B1C RID: 23324 RVA: 0x00114732 File Offset: 0x00112B32
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06005B1D RID: 23325 RVA: 0x00114750 File Offset: 0x00112B50
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06005B1E RID: 23326 RVA: 0x0011476E File Offset: 0x00112B6E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06005B1F RID: 23327 RVA: 0x0011478C File Offset: 0x00112B8C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400251A RID: 9498
		public const uint MsgID = 508926U;

		// Token: 0x0400251B RID: 9499
		public uint Sequence;

		// Token: 0x0400251C RID: 9500
		public uint battleID;

		// Token: 0x0400251D RID: 9501
		public uint retCode;
	}
}
