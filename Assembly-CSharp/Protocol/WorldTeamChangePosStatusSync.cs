using System;

namespace Protocol
{
	// Token: 0x02000B8D RID: 2957
	[Protocol]
	public class WorldTeamChangePosStatusSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D50 RID: 32080 RVA: 0x0016504C File Offset: 0x0016344C
		public uint GetMsgID()
		{
			return 601631U;
		}

		// Token: 0x06007D51 RID: 32081 RVA: 0x00165053 File Offset: 0x00163453
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D52 RID: 32082 RVA: 0x0016505B File Offset: 0x0016345B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D53 RID: 32083 RVA: 0x00165064 File Offset: 0x00163464
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			BaseDLL.encode_int8(buffer, ref pos_, this.open);
		}

		// Token: 0x06007D54 RID: 32084 RVA: 0x00165082 File Offset: 0x00163482
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.open);
		}

		// Token: 0x06007D55 RID: 32085 RVA: 0x001650A0 File Offset: 0x001634A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			BaseDLL.encode_int8(buffer, ref pos_, this.open);
		}

		// Token: 0x06007D56 RID: 32086 RVA: 0x001650BE File Offset: 0x001634BE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.open);
		}

		// Token: 0x06007D57 RID: 32087 RVA: 0x001650DC File Offset: 0x001634DC
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 1;
		}

		// Token: 0x04003B72 RID: 15218
		public const uint MsgID = 601631U;

		// Token: 0x04003B73 RID: 15219
		public uint Sequence;

		// Token: 0x04003B74 RID: 15220
		public byte pos;

		// Token: 0x04003B75 RID: 15221
		public byte open;
	}
}
