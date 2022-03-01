using System;

namespace Protocol
{
	// Token: 0x02000BCE RID: 3022
	[Protocol]
	public class TeamCopyStageNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007EE2 RID: 32482 RVA: 0x001683F5 File Offset: 0x001667F5
		public uint GetMsgID()
		{
			return 1100019U;
		}

		// Token: 0x06007EE3 RID: 32483 RVA: 0x001683FC File Offset: 0x001667FC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007EE4 RID: 32484 RVA: 0x00168404 File Offset: 0x00166804
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007EE5 RID: 32485 RVA: 0x00168410 File Offset: 0x00166810
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.stageId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gameOverTime);
			this.squadTarget.encode(buffer, ref pos_);
			this.teamTarget.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.feildList.Length);
			for (int i = 0; i < this.feildList.Length; i++)
			{
				this.feildList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007EE6 RID: 32486 RVA: 0x0016848C File Offset: 0x0016688C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stageId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gameOverTime);
			this.squadTarget.decode(buffer, ref pos_);
			this.teamTarget.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.feildList = new TeamCopyFeild[(int)num];
			for (int i = 0; i < this.feildList.Length; i++)
			{
				this.feildList[i] = new TeamCopyFeild();
				this.feildList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007EE7 RID: 32487 RVA: 0x0016851C File Offset: 0x0016691C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.stageId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gameOverTime);
			this.squadTarget.encode(buffer, ref pos_);
			this.teamTarget.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.feildList.Length);
			for (int i = 0; i < this.feildList.Length; i++)
			{
				this.feildList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007EE8 RID: 32488 RVA: 0x00168598 File Offset: 0x00166998
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stageId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gameOverTime);
			this.squadTarget.decode(buffer, ref pos_);
			this.teamTarget.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.feildList = new TeamCopyFeild[(int)num];
			for (int i = 0; i < this.feildList.Length; i++)
			{
				this.feildList[i] = new TeamCopyFeild();
				this.feildList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007EE9 RID: 32489 RVA: 0x00168628 File Offset: 0x00166A28
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += this.squadTarget.getLen();
			num += this.teamTarget.getLen();
			num += 2;
			for (int i = 0; i < this.feildList.Length; i++)
			{
				num += this.feildList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003C95 RID: 15509
		public const uint MsgID = 1100019U;

		// Token: 0x04003C96 RID: 15510
		public uint Sequence;

		// Token: 0x04003C97 RID: 15511
		public uint stageId;

		// Token: 0x04003C98 RID: 15512
		public uint gameOverTime;

		// Token: 0x04003C99 RID: 15513
		public TeamCopyTarget squadTarget = new TeamCopyTarget();

		// Token: 0x04003C9A RID: 15514
		public TeamCopyTarget teamTarget = new TeamCopyTarget();

		// Token: 0x04003C9B RID: 15515
		public TeamCopyFeild[] feildList = new TeamCopyFeild[0];
	}
}
