using System;

namespace Protocol
{
	// Token: 0x02000BCC RID: 3020
	public class TeamCopyTarget : IProtocolStream
	{
		// Token: 0x06007ED6 RID: 32470 RVA: 0x00167F78 File Offset: 0x00166378
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.targetDetailList.Length);
			for (int i = 0; i < this.targetDetailList.Length; i++)
			{
				this.targetDetailList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007ED7 RID: 32471 RVA: 0x00167FCC File Offset: 0x001663CC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.targetDetailList = new TeamCopyTargetDetail[(int)num];
			for (int i = 0; i < this.targetDetailList.Length; i++)
			{
				this.targetDetailList[i] = new TeamCopyTargetDetail();
				this.targetDetailList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007ED8 RID: 32472 RVA: 0x00168034 File Offset: 0x00166434
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.targetDetailList.Length);
			for (int i = 0; i < this.targetDetailList.Length; i++)
			{
				this.targetDetailList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007ED9 RID: 32473 RVA: 0x00168088 File Offset: 0x00166488
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.targetDetailList = new TeamCopyTargetDetail[(int)num];
			for (int i = 0; i < this.targetDetailList.Length; i++)
			{
				this.targetDetailList[i] = new TeamCopyTargetDetail();
				this.targetDetailList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007EDA RID: 32474 RVA: 0x001680F0 File Offset: 0x001664F0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.targetDetailList.Length; i++)
			{
				num += this.targetDetailList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003C8D RID: 15501
		public uint targetId;

		// Token: 0x04003C8E RID: 15502
		public TeamCopyTargetDetail[] targetDetailList = new TeamCopyTargetDetail[0];
	}
}
