using System;

namespace Protocol
{
	// Token: 0x02000B9B RID: 2971
	[Protocol]
	public class WorldTeamMatchResultNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007DCE RID: 32206 RVA: 0x00165908 File Offset: 0x00163D08
		public uint GetMsgID()
		{
			return 601648U;
		}

		// Token: 0x06007DCF RID: 32207 RVA: 0x0016590F File Offset: 0x00163D0F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007DD0 RID: 32208 RVA: 0x00165917 File Offset: 0x00163D17
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007DD1 RID: 32209 RVA: 0x00165920 File Offset: 0x00163D20
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.players.Length);
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007DD2 RID: 32210 RVA: 0x00165974 File Offset: 0x00163D74
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.players = new PlayerIcon[(int)num];
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i] = new PlayerIcon();
				this.players[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007DD3 RID: 32211 RVA: 0x001659DC File Offset: 0x00163DDC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.players.Length);
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007DD4 RID: 32212 RVA: 0x00165A30 File Offset: 0x00163E30
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.players = new PlayerIcon[(int)num];
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i] = new PlayerIcon();
				this.players[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007DD5 RID: 32213 RVA: 0x00165A98 File Offset: 0x00163E98
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.players.Length; i++)
			{
				num += this.players[i].getLen();
			}
			return num;
		}

		// Token: 0x04003BA0 RID: 15264
		public const uint MsgID = 601648U;

		// Token: 0x04003BA1 RID: 15265
		public uint Sequence;

		// Token: 0x04003BA2 RID: 15266
		public uint dungeonId;

		// Token: 0x04003BA3 RID: 15267
		public PlayerIcon[] players = new PlayerIcon[0];
	}
}
