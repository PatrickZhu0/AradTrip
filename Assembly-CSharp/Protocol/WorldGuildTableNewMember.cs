using System;

namespace Protocol
{
	// Token: 0x0200084E RID: 2126
	[Protocol]
	public class WorldGuildTableNewMember : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006430 RID: 25648 RVA: 0x0012B6B3 File Offset: 0x00129AB3
		public uint GetMsgID()
		{
			return 601938U;
		}

		// Token: 0x06006431 RID: 25649 RVA: 0x0012B6BA File Offset: 0x00129ABA
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006432 RID: 25650 RVA: 0x0012B6C2 File Offset: 0x00129AC2
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006433 RID: 25651 RVA: 0x0012B6CB File Offset: 0x00129ACB
		public void encode(byte[] buffer, ref int pos_)
		{
			this.member.encode(buffer, ref pos_);
		}

		// Token: 0x06006434 RID: 25652 RVA: 0x0012B6DA File Offset: 0x00129ADA
		public void decode(byte[] buffer, ref int pos_)
		{
			this.member.decode(buffer, ref pos_);
		}

		// Token: 0x06006435 RID: 25653 RVA: 0x0012B6E9 File Offset: 0x00129AE9
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.member.encode(buffer, ref pos_);
		}

		// Token: 0x06006436 RID: 25654 RVA: 0x0012B6F8 File Offset: 0x00129AF8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.member.decode(buffer, ref pos_);
		}

		// Token: 0x06006437 RID: 25655 RVA: 0x0012B708 File Offset: 0x00129B08
		public int getLen()
		{
			int num = 0;
			return num + this.member.getLen();
		}

		// Token: 0x04002CE9 RID: 11497
		public const uint MsgID = 601938U;

		// Token: 0x04002CEA RID: 11498
		public uint Sequence;

		// Token: 0x04002CEB RID: 11499
		public GuildTableMember member = new GuildTableMember();
	}
}
