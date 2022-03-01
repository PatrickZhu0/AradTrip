using System;

namespace Protocol
{
	// Token: 0x02000C06 RID: 3078
	[Protocol]
	public class TeamCopyForceEndVoteResult : IProtocolStream, IGetMsgID
	{
		// Token: 0x060080D1 RID: 32977 RVA: 0x0016C164 File Offset: 0x0016A564
		public uint GetMsgID()
		{
			return 1100075U;
		}

		// Token: 0x060080D2 RID: 32978 RVA: 0x0016C16B File Offset: 0x0016A56B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060080D3 RID: 32979 RVA: 0x0016C173 File Offset: 0x0016A573
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060080D4 RID: 32980 RVA: 0x0016C17C File Offset: 0x0016A57C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060080D5 RID: 32981 RVA: 0x0016C18C File Offset: 0x0016A58C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060080D6 RID: 32982 RVA: 0x0016C19C File Offset: 0x0016A59C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060080D7 RID: 32983 RVA: 0x0016C1AC File Offset: 0x0016A5AC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060080D8 RID: 32984 RVA: 0x0016C1BC File Offset: 0x0016A5BC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003D7A RID: 15738
		public const uint MsgID = 1100075U;

		// Token: 0x04003D7B RID: 15739
		public uint Sequence;

		// Token: 0x04003D7C RID: 15740
		public uint result;
	}
}
