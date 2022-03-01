using System;

namespace Protocol
{
	// Token: 0x020007C9 RID: 1993
	[Protocol]
	public class SceneDungeonOpenChestRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600607F RID: 24703 RVA: 0x00122493 File Offset: 0x00120893
		public uint GetMsgID()
		{
			return 506814U;
		}

		// Token: 0x06006080 RID: 24704 RVA: 0x0012249A File Offset: 0x0012089A
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006081 RID: 24705 RVA: 0x001224A2 File Offset: 0x001208A2
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006082 RID: 24706 RVA: 0x001224AB File Offset: 0x001208AB
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.owner);
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			this.chest.encode(buffer, ref pos_);
		}

		// Token: 0x06006083 RID: 24707 RVA: 0x001224D6 File Offset: 0x001208D6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.owner);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			this.chest.decode(buffer, ref pos_);
		}

		// Token: 0x06006084 RID: 24708 RVA: 0x00122501 File Offset: 0x00120901
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.owner);
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			this.chest.encode(buffer, ref pos_);
		}

		// Token: 0x06006085 RID: 24709 RVA: 0x0012252C File Offset: 0x0012092C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.owner);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			this.chest.decode(buffer, ref pos_);
		}

		// Token: 0x06006086 RID: 24710 RVA: 0x00122558 File Offset: 0x00120958
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			return num + this.chest.getLen();
		}

		// Token: 0x0400283E RID: 10302
		public const uint MsgID = 506814U;

		// Token: 0x0400283F RID: 10303
		public uint Sequence;

		// Token: 0x04002840 RID: 10304
		public ulong owner;

		// Token: 0x04002841 RID: 10305
		public byte pos;

		// Token: 0x04002842 RID: 10306
		public DungeonChest chest = new DungeonChest();
	}
}
