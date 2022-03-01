using System;

namespace Protocol
{
	// Token: 0x02000BDA RID: 3034
	[Protocol]
	public class TeamCopyFindTeamMateRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F4B RID: 32587 RVA: 0x001693A0 File Offset: 0x001677A0
		public uint GetMsgID()
		{
			return 1100030U;
		}

		// Token: 0x06007F4C RID: 32588 RVA: 0x001693A7 File Offset: 0x001677A7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F4D RID: 32589 RVA: 0x001693AF File Offset: 0x001677AF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F4E RID: 32590 RVA: 0x001693B8 File Offset: 0x001677B8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.playerList.Length);
			for (int i = 0; i < this.playerList.Length; i++)
			{
				this.playerList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007F4F RID: 32591 RVA: 0x00169400 File Offset: 0x00167800
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.playerList = new TeamCopyApplyProperty[(int)num];
			for (int i = 0; i < this.playerList.Length; i++)
			{
				this.playerList[i] = new TeamCopyApplyProperty();
				this.playerList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007F50 RID: 32592 RVA: 0x0016945C File Offset: 0x0016785C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.playerList.Length);
			for (int i = 0; i < this.playerList.Length; i++)
			{
				this.playerList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007F51 RID: 32593 RVA: 0x001694A4 File Offset: 0x001678A4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.playerList = new TeamCopyApplyProperty[(int)num];
			for (int i = 0; i < this.playerList.Length; i++)
			{
				this.playerList[i] = new TeamCopyApplyProperty();
				this.playerList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007F52 RID: 32594 RVA: 0x00169500 File Offset: 0x00167900
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.playerList.Length; i++)
			{
				num += this.playerList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003CC6 RID: 15558
		public const uint MsgID = 1100030U;

		// Token: 0x04003CC7 RID: 15559
		public uint Sequence;

		// Token: 0x04003CC8 RID: 15560
		public TeamCopyApplyProperty[] playerList = new TeamCopyApplyProperty[0];
	}
}
