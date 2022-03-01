using System;

namespace Protocol
{
	// Token: 0x0200085D RID: 2141
	[Protocol]
	public class WorldGuildBattleTerritoryRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060064B7 RID: 25783 RVA: 0x0012C10B File Offset: 0x0012A50B
		public uint GetMsgID()
		{
			return 601952U;
		}

		// Token: 0x060064B8 RID: 25784 RVA: 0x0012C112 File Offset: 0x0012A512
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060064B9 RID: 25785 RVA: 0x0012C11A File Offset: 0x0012A51A
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060064BA RID: 25786 RVA: 0x0012C123 File Offset: 0x0012A523
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x060064BB RID: 25787 RVA: 0x0012C140 File Offset: 0x0012A540
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x060064BC RID: 25788 RVA: 0x0012C15D File Offset: 0x0012A55D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x060064BD RID: 25789 RVA: 0x0012C17A File Offset: 0x0012A57A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x060064BE RID: 25790 RVA: 0x0012C198 File Offset: 0x0012A598
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.info.getLen();
		}

		// Token: 0x04002D1C RID: 11548
		public const uint MsgID = 601952U;

		// Token: 0x04002D1D RID: 11549
		public uint Sequence;

		// Token: 0x04002D1E RID: 11550
		public uint result;

		// Token: 0x04002D1F RID: 11551
		public GuildTerritoryBaseInfo info = new GuildTerritoryBaseInfo();
	}
}
