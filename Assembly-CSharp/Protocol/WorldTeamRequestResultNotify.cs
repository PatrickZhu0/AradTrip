using System;

namespace Protocol
{
	// Token: 0x02000B99 RID: 2969
	[Protocol]
	public class WorldTeamRequestResultNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007DBC RID: 32188 RVA: 0x001657D6 File Offset: 0x00163BD6
		public uint GetMsgID()
		{
			return 601646U;
		}

		// Token: 0x06007DBD RID: 32189 RVA: 0x001657DD File Offset: 0x00163BDD
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007DBE RID: 32190 RVA: 0x001657E5 File Offset: 0x00163BE5
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007DBF RID: 32191 RVA: 0x001657EE File Offset: 0x00163BEE
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.agree);
		}

		// Token: 0x06007DC0 RID: 32192 RVA: 0x001657FE File Offset: 0x00163BFE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.agree);
		}

		// Token: 0x06007DC1 RID: 32193 RVA: 0x0016580E File Offset: 0x00163C0E
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.agree);
		}

		// Token: 0x06007DC2 RID: 32194 RVA: 0x0016581E File Offset: 0x00163C1E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.agree);
		}

		// Token: 0x06007DC3 RID: 32195 RVA: 0x00165830 File Offset: 0x00163C30
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003B99 RID: 15257
		public const uint MsgID = 601646U;

		// Token: 0x04003B9A RID: 15258
		public uint Sequence;

		// Token: 0x04003B9B RID: 15259
		public byte agree;
	}
}
