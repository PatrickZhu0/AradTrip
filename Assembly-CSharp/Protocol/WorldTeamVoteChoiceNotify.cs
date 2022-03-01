using System;

namespace Protocol
{
	// Token: 0x02000B9A RID: 2970
	[Protocol]
	public class WorldTeamVoteChoiceNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007DC5 RID: 32197 RVA: 0x0016584C File Offset: 0x00163C4C
		public uint GetMsgID()
		{
			return 601647U;
		}

		// Token: 0x06007DC6 RID: 32198 RVA: 0x00165853 File Offset: 0x00163C53
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007DC7 RID: 32199 RVA: 0x0016585B File Offset: 0x00163C5B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007DC8 RID: 32200 RVA: 0x00165864 File Offset: 0x00163C64
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.agree);
		}

		// Token: 0x06007DC9 RID: 32201 RVA: 0x00165882 File Offset: 0x00163C82
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.agree);
		}

		// Token: 0x06007DCA RID: 32202 RVA: 0x001658A0 File Offset: 0x00163CA0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.agree);
		}

		// Token: 0x06007DCB RID: 32203 RVA: 0x001658BE File Offset: 0x00163CBE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.agree);
		}

		// Token: 0x06007DCC RID: 32204 RVA: 0x001658DC File Offset: 0x00163CDC
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x04003B9C RID: 15260
		public const uint MsgID = 601647U;

		// Token: 0x04003B9D RID: 15261
		public uint Sequence;

		// Token: 0x04003B9E RID: 15262
		public ulong roleId;

		// Token: 0x04003B9F RID: 15263
		public byte agree;
	}
}
