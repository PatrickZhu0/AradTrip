using System;

namespace Protocol
{
	// Token: 0x0200083C RID: 2108
	[Protocol]
	public class WorldGuildMemberListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600638E RID: 25486 RVA: 0x0012A860 File Offset: 0x00128C60
		public uint GetMsgID()
		{
			return 601920U;
		}

		// Token: 0x0600638F RID: 25487 RVA: 0x0012A867 File Offset: 0x00128C67
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006390 RID: 25488 RVA: 0x0012A86F File Offset: 0x00128C6F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006391 RID: 25489 RVA: 0x0012A878 File Offset: 0x00128C78
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.members.Length);
			for (int i = 0; i < this.members.Length; i++)
			{
				this.members[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006392 RID: 25490 RVA: 0x0012A8C0 File Offset: 0x00128CC0
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.members = new GuildMemberEntry[(int)num];
			for (int i = 0; i < this.members.Length; i++)
			{
				this.members[i] = new GuildMemberEntry();
				this.members[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006393 RID: 25491 RVA: 0x0012A91C File Offset: 0x00128D1C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.members.Length);
			for (int i = 0; i < this.members.Length; i++)
			{
				this.members[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006394 RID: 25492 RVA: 0x0012A964 File Offset: 0x00128D64
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.members = new GuildMemberEntry[(int)num];
			for (int i = 0; i < this.members.Length; i++)
			{
				this.members[i] = new GuildMemberEntry();
				this.members[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006395 RID: 25493 RVA: 0x0012A9C0 File Offset: 0x00128DC0
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.members.Length; i++)
			{
				num += this.members[i].getLen();
			}
			return num;
		}

		// Token: 0x04002CB1 RID: 11441
		public const uint MsgID = 601920U;

		// Token: 0x04002CB2 RID: 11442
		public uint Sequence;

		// Token: 0x04002CB3 RID: 11443
		public GuildMemberEntry[] members = new GuildMemberEntry[0];
	}
}
