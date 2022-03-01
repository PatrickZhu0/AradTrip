using System;

namespace Protocol
{
	// Token: 0x02000953 RID: 2387
	[Protocol]
	public class SceneSyncResistMagicReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C4F RID: 27727 RVA: 0x0013BC8D File Offset: 0x0013A08D
		public uint GetMsgID()
		{
			return 501021U;
		}

		// Token: 0x06006C50 RID: 27728 RVA: 0x0013BC94 File Offset: 0x0013A094
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C51 RID: 27729 RVA: 0x0013BC9C File Offset: 0x0013A09C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C52 RID: 27730 RVA: 0x0013BCA5 File Offset: 0x0013A0A5
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resist_magic);
		}

		// Token: 0x06006C53 RID: 27731 RVA: 0x0013BCB5 File Offset: 0x0013A0B5
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resist_magic);
		}

		// Token: 0x06006C54 RID: 27732 RVA: 0x0013BCC5 File Offset: 0x0013A0C5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resist_magic);
		}

		// Token: 0x06006C55 RID: 27733 RVA: 0x0013BCD5 File Offset: 0x0013A0D5
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resist_magic);
		}

		// Token: 0x06006C56 RID: 27734 RVA: 0x0013BCE8 File Offset: 0x0013A0E8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003104 RID: 12548
		public const uint MsgID = 501021U;

		// Token: 0x04003105 RID: 12549
		public uint Sequence;

		// Token: 0x04003106 RID: 12550
		public uint resist_magic;
	}
}
