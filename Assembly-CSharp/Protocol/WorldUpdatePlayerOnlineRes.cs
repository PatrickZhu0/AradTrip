using System;

namespace Protocol
{
	// Token: 0x02000C97 RID: 3223
	[Protocol]
	public class WorldUpdatePlayerOnlineRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008506 RID: 34054 RVA: 0x00175497 File Offset: 0x00173897
		public uint GetMsgID()
		{
			return 601715U;
		}

		// Token: 0x06008507 RID: 34055 RVA: 0x0017549E File Offset: 0x0017389E
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008508 RID: 34056 RVA: 0x001754A6 File Offset: 0x001738A6
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008509 RID: 34057 RVA: 0x001754B0 File Offset: 0x001738B0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.playerStates.Length);
			for (int i = 0; i < this.playerStates.Length; i++)
			{
				this.playerStates[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600850A RID: 34058 RVA: 0x001754F8 File Offset: 0x001738F8
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.playerStates = new PlayerOnline[(int)num];
			for (int i = 0; i < this.playerStates.Length; i++)
			{
				this.playerStates[i] = new PlayerOnline();
				this.playerStates[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600850B RID: 34059 RVA: 0x00175554 File Offset: 0x00173954
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.playerStates.Length);
			for (int i = 0; i < this.playerStates.Length; i++)
			{
				this.playerStates[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600850C RID: 34060 RVA: 0x0017559C File Offset: 0x0017399C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.playerStates = new PlayerOnline[(int)num];
			for (int i = 0; i < this.playerStates.Length; i++)
			{
				this.playerStates[i] = new PlayerOnline();
				this.playerStates[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600850D RID: 34061 RVA: 0x001755F8 File Offset: 0x001739F8
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.playerStates.Length; i++)
			{
				num += this.playerStates[i].getLen();
			}
			return num;
		}

		// Token: 0x04003FC2 RID: 16322
		public const uint MsgID = 601715U;

		// Token: 0x04003FC3 RID: 16323
		public uint Sequence;

		// Token: 0x04003FC4 RID: 16324
		public PlayerOnline[] playerStates = new PlayerOnline[0];
	}
}
