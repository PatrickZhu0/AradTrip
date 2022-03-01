using System;

namespace Protocol
{
	// Token: 0x02000B7A RID: 2938
	[Protocol]
	public class WorldCreateTeamRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007CAB RID: 31915 RVA: 0x001638E8 File Offset: 0x00161CE8
		public uint GetMsgID()
		{
			return 601627U;
		}

		// Token: 0x06007CAC RID: 31916 RVA: 0x001638EF File Offset: 0x00161CEF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007CAD RID: 31917 RVA: 0x001638F7 File Offset: 0x00161CF7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007CAE RID: 31918 RVA: 0x00163900 File Offset: 0x00161D00
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007CAF RID: 31919 RVA: 0x00163910 File Offset: 0x00161D10
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007CB0 RID: 31920 RVA: 0x00163920 File Offset: 0x00161D20
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007CB1 RID: 31921 RVA: 0x00163930 File Offset: 0x00161D30
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007CB2 RID: 31922 RVA: 0x00163940 File Offset: 0x00161D40
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003B18 RID: 15128
		public const uint MsgID = 601627U;

		// Token: 0x04003B19 RID: 15129
		public uint Sequence;

		// Token: 0x04003B1A RID: 15130
		public uint result;
	}
}
