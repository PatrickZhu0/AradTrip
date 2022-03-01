using System;

namespace Protocol
{
	// Token: 0x02000BA0 RID: 2976
	[Protocol]
	public class WorldSyncTeamMemberProperty : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007DFB RID: 32251 RVA: 0x00165C83 File Offset: 0x00164083
		public uint GetMsgID()
		{
			return 601654U;
		}

		// Token: 0x06007DFC RID: 32252 RVA: 0x00165C8A File Offset: 0x0016408A
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007DFD RID: 32253 RVA: 0x00165C92 File Offset: 0x00164092
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007DFE RID: 32254 RVA: 0x00165C9B File Offset: 0x0016409B
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.memberId);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.value);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06007DFF RID: 32255 RVA: 0x00165CD4 File Offset: 0x001640D4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.memberId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.value);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06007E00 RID: 32256 RVA: 0x00165D0D File Offset: 0x0016410D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.memberId);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.value);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06007E01 RID: 32257 RVA: 0x00165D46 File Offset: 0x00164146
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.memberId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.value);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06007E02 RID: 32258 RVA: 0x00165D80 File Offset: 0x00164180
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			num += 8;
			return num + this.playerLabelInfo.getLen();
		}

		// Token: 0x04003BAF RID: 15279
		public const uint MsgID = 601654U;

		// Token: 0x04003BB0 RID: 15280
		public uint Sequence;

		// Token: 0x04003BB1 RID: 15281
		public ulong memberId;

		// Token: 0x04003BB2 RID: 15282
		public byte type;

		// Token: 0x04003BB3 RID: 15283
		public ulong value;

		// Token: 0x04003BB4 RID: 15284
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();
	}
}
