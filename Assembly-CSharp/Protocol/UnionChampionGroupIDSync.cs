using System;

namespace Protocol
{
	// Token: 0x02000765 RID: 1893
	[Protocol]
	public class UnionChampionGroupIDSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005DAF RID: 23983 RVA: 0x0011926D File Offset: 0x0011766D
		public uint GetMsgID()
		{
			return 1209812U;
		}

		// Token: 0x06005DB0 RID: 23984 RVA: 0x00119274 File Offset: 0x00117674
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005DB1 RID: 23985 RVA: 0x0011927C File Offset: 0x0011767C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005DB2 RID: 23986 RVA: 0x00119285 File Offset: 0x00117685
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x06005DB3 RID: 23987 RVA: 0x00119295 File Offset: 0x00117695
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06005DB4 RID: 23988 RVA: 0x001192A5 File Offset: 0x001176A5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x06005DB5 RID: 23989 RVA: 0x001192B5 File Offset: 0x001176B5
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06005DB6 RID: 23990 RVA: 0x001192C8 File Offset: 0x001176C8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002667 RID: 9831
		public const uint MsgID = 1209812U;

		// Token: 0x04002668 RID: 9832
		public uint Sequence;

		// Token: 0x04002669 RID: 9833
		public uint id;
	}
}
