using System;

namespace Protocol
{
	// Token: 0x02000BBB RID: 3003
	public class SquadData : IProtocolStream
	{
		// Token: 0x06007E49 RID: 32329 RVA: 0x00166674 File Offset: 0x00164A74
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadStatus);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.teamMemberList.Length);
			for (int i = 0; i < this.teamMemberList.Length; i++)
			{
				this.teamMemberList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007E4A RID: 32330 RVA: 0x001666D8 File Offset: 0x00164AD8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadStatus);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.teamMemberList = new TeamCopyMember[(int)num];
			for (int i = 0; i < this.teamMemberList.Length; i++)
			{
				this.teamMemberList[i] = new TeamCopyMember();
				this.teamMemberList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007E4B RID: 32331 RVA: 0x00166750 File Offset: 0x00164B50
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadStatus);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.teamMemberList.Length);
			for (int i = 0; i < this.teamMemberList.Length; i++)
			{
				this.teamMemberList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007E4C RID: 32332 RVA: 0x001667B4 File Offset: 0x00164BB4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadStatus);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.teamMemberList = new TeamCopyMember[(int)num];
			for (int i = 0; i < this.teamMemberList.Length; i++)
			{
				this.teamMemberList[i] = new TeamCopyMember();
				this.teamMemberList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007E4D RID: 32333 RVA: 0x0016682C File Offset: 0x00164C2C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.teamMemberList.Length; i++)
			{
				num += this.teamMemberList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003C3F RID: 15423
		public uint squadId;

		// Token: 0x04003C40 RID: 15424
		public uint squadStatus;

		// Token: 0x04003C41 RID: 15425
		public TeamCopyMember[] teamMemberList = new TeamCopyMember[0];
	}
}
