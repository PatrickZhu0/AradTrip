using System;

namespace Protocol
{
	// Token: 0x02000BBF RID: 3007
	[Protocol]
	public class TeamCopyTeamListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007E67 RID: 32359 RVA: 0x00167200 File Offset: 0x00165600
		public uint GetMsgID()
		{
			return 1100008U;
		}

		// Token: 0x06007E68 RID: 32360 RVA: 0x00167207 File Offset: 0x00165607
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007E69 RID: 32361 RVA: 0x0016720F File Offset: 0x0016560F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007E6A RID: 32362 RVA: 0x00167218 File Offset: 0x00165618
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.curPage);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalPageNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.teamList.Length);
			for (int i = 0; i < this.teamList.Length; i++)
			{
				this.teamList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007E6B RID: 32363 RVA: 0x0016727C File Offset: 0x0016567C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curPage);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalPageNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.teamList = new TeamCopyTeamProperty[(int)num];
			for (int i = 0; i < this.teamList.Length; i++)
			{
				this.teamList[i] = new TeamCopyTeamProperty();
				this.teamList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007E6C RID: 32364 RVA: 0x001672F4 File Offset: 0x001656F4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.curPage);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalPageNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.teamList.Length);
			for (int i = 0; i < this.teamList.Length; i++)
			{
				this.teamList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007E6D RID: 32365 RVA: 0x00167358 File Offset: 0x00165758
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curPage);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalPageNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.teamList = new TeamCopyTeamProperty[(int)num];
			for (int i = 0; i < this.teamList.Length; i++)
			{
				this.teamList[i] = new TeamCopyTeamProperty();
				this.teamList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007E6E RID: 32366 RVA: 0x001673D0 File Offset: 0x001657D0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.teamList.Length; i++)
			{
				num += this.teamList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003C5E RID: 15454
		public const uint MsgID = 1100008U;

		// Token: 0x04003C5F RID: 15455
		public uint Sequence;

		// Token: 0x04003C60 RID: 15456
		public uint curPage;

		// Token: 0x04003C61 RID: 15457
		public uint totalPageNum;

		// Token: 0x04003C62 RID: 15458
		public TeamCopyTeamProperty[] teamList = new TeamCopyTeamProperty[0];
	}
}
