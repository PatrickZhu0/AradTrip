using System;

namespace Protocol
{
	// Token: 0x0200084B RID: 2123
	[Protocol]
	public class WorldGuildLeaderInfoRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006415 RID: 25621 RVA: 0x0012B507 File Offset: 0x00129907
		public uint GetMsgID()
		{
			return 601935U;
		}

		// Token: 0x06006416 RID: 25622 RVA: 0x0012B50E File Offset: 0x0012990E
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006417 RID: 25623 RVA: 0x0012B516 File Offset: 0x00129916
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006418 RID: 25624 RVA: 0x0012B51F File Offset: 0x0012991F
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06006419 RID: 25625 RVA: 0x0012B52E File Offset: 0x0012992E
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x0600641A RID: 25626 RVA: 0x0012B53D File Offset: 0x0012993D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x0600641B RID: 25627 RVA: 0x0012B54C File Offset: 0x0012994C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x0600641C RID: 25628 RVA: 0x0012B55C File Offset: 0x0012995C
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x04002CDF RID: 11487
		public const uint MsgID = 601935U;

		// Token: 0x04002CE0 RID: 11488
		public uint Sequence;

		// Token: 0x04002CE1 RID: 11489
		public GuildLeaderInfo info = new GuildLeaderInfo();
	}
}
