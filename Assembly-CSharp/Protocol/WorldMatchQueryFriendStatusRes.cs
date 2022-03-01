using System;

namespace Protocol
{
	// Token: 0x02000A06 RID: 2566
	[Protocol]
	public class WorldMatchQueryFriendStatusRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060071FB RID: 29179 RVA: 0x0014ACC8 File Offset: 0x001490C8
		public uint GetMsgID()
		{
			return 606707U;
		}

		// Token: 0x060071FC RID: 29180 RVA: 0x0014ACCF File Offset: 0x001490CF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060071FD RID: 29181 RVA: 0x0014ACD7 File Offset: 0x001490D7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060071FE RID: 29182 RVA: 0x0014ACE0 File Offset: 0x001490E0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infoes.Length);
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060071FF RID: 29183 RVA: 0x0014AD28 File Offset: 0x00149128
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infoes = new FriendMatchStatusInfo[(int)num];
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i] = new FriendMatchStatusInfo();
				this.infoes[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007200 RID: 29184 RVA: 0x0014AD84 File Offset: 0x00149184
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infoes.Length);
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007201 RID: 29185 RVA: 0x0014ADCC File Offset: 0x001491CC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infoes = new FriendMatchStatusInfo[(int)num];
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i] = new FriendMatchStatusInfo();
				this.infoes[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007202 RID: 29186 RVA: 0x0014AE28 File Offset: 0x00149228
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.infoes.Length; i++)
			{
				num += this.infoes[i].getLen();
			}
			return num;
		}

		// Token: 0x04003463 RID: 13411
		public const uint MsgID = 606707U;

		// Token: 0x04003464 RID: 13412
		public uint Sequence;

		// Token: 0x04003465 RID: 13413
		public FriendMatchStatusInfo[] infoes = new FriendMatchStatusInfo[0];
	}
}
