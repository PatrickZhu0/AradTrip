using System;

namespace Protocol
{
	// Token: 0x02000751 RID: 1873
	[Protocol]
	public class SceneChampionGambleRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D04 RID: 23812 RVA: 0x00117FE0 File Offset: 0x001163E0
		public uint GetMsgID()
		{
			return 509812U;
		}

		// Token: 0x06005D05 RID: 23813 RVA: 0x00117FE7 File Offset: 0x001163E7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D06 RID: 23814 RVA: 0x00117FEF File Offset: 0x001163EF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005D07 RID: 23815 RVA: 0x00117FF8 File Offset: 0x001163F8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint64(buffer, ref pos_, this.option);
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06005D08 RID: 23816 RVA: 0x00118032 File Offset: 0x00116432
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.option);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005D09 RID: 23817 RVA: 0x0011806C File Offset: 0x0011646C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint64(buffer, ref pos_, this.option);
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06005D0A RID: 23818 RVA: 0x001180A6 File Offset: 0x001164A6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.option);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005D0B RID: 23819 RVA: 0x001180E0 File Offset: 0x001164E0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400261F RID: 9759
		public const uint MsgID = 509812U;

		// Token: 0x04002620 RID: 9760
		public uint Sequence;

		// Token: 0x04002621 RID: 9761
		public uint id;

		// Token: 0x04002622 RID: 9762
		public ulong option;

		// Token: 0x04002623 RID: 9763
		public uint errorCode;

		// Token: 0x04002624 RID: 9764
		public uint num;
	}
}
