using System;

namespace Protocol
{
	// Token: 0x020007DF RID: 2015
	[Protocol]
	public class SceneDungeonBuyTimesReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006142 RID: 24898 RVA: 0x00123ADD File Offset: 0x00121EDD
		public uint GetMsgID()
		{
			return 506831U;
		}

		// Token: 0x06006143 RID: 24899 RVA: 0x00123AE4 File Offset: 0x00121EE4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006144 RID: 24900 RVA: 0x00123AEC File Offset: 0x00121EEC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006145 RID: 24901 RVA: 0x00123AF5 File Offset: 0x00121EF5
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.subType);
		}

		// Token: 0x06006146 RID: 24902 RVA: 0x00123B05 File Offset: 0x00121F05
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.subType);
		}

		// Token: 0x06006147 RID: 24903 RVA: 0x00123B15 File Offset: 0x00121F15
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.subType);
		}

		// Token: 0x06006148 RID: 24904 RVA: 0x00123B25 File Offset: 0x00121F25
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.subType);
		}

		// Token: 0x06006149 RID: 24905 RVA: 0x00123B38 File Offset: 0x00121F38
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04002889 RID: 10377
		public const uint MsgID = 506831U;

		// Token: 0x0400288A RID: 10378
		public uint Sequence;

		// Token: 0x0400288B RID: 10379
		public byte subType;
	}
}
