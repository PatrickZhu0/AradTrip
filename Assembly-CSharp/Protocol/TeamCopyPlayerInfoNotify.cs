using System;

namespace Protocol
{
	// Token: 0x02000BF6 RID: 3062
	[Protocol]
	public class TeamCopyPlayerInfoNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008041 RID: 32833 RVA: 0x0016B2C4 File Offset: 0x001696C4
		public uint GetMsgID()
		{
			return 1100059U;
		}

		// Token: 0x06008042 RID: 32834 RVA: 0x0016B2CB File Offset: 0x001696CB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008043 RID: 32835 RVA: 0x0016B2D3 File Offset: 0x001696D3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008044 RID: 32836 RVA: 0x0016B2DC File Offset: 0x001696DC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dayNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dayTotalNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekTotalNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.diffWeekNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.diffWeekTotalNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isCreateGold);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dayFreeQuitNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekFreeQuitNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ticketIsEnough);
			BaseDLL.encode_uint32(buffer, ref pos_, this.commonGradePassNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unlockDiffGradeCommonNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.yetOpenGradeList.Length);
			for (int i = 0; i < this.yetOpenGradeList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.yetOpenGradeList[i]);
			}
		}

		// Token: 0x06008045 RID: 32837 RVA: 0x0016B3CC File Offset: 0x001697CC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dayNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dayTotalNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekTotalNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.diffWeekNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.diffWeekTotalNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isCreateGold);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dayFreeQuitNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekFreeQuitNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ticketIsEnough);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.commonGradePassNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unlockDiffGradeCommonNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.yetOpenGradeList = new uint[(int)num];
			for (int i = 0; i < this.yetOpenGradeList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.yetOpenGradeList[i]);
			}
		}

		// Token: 0x06008046 RID: 32838 RVA: 0x0016B4C8 File Offset: 0x001698C8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dayNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dayTotalNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekTotalNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.diffWeekNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.diffWeekTotalNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isCreateGold);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dayFreeQuitNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekFreeQuitNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ticketIsEnough);
			BaseDLL.encode_uint32(buffer, ref pos_, this.commonGradePassNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unlockDiffGradeCommonNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.yetOpenGradeList.Length);
			for (int i = 0; i < this.yetOpenGradeList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.yetOpenGradeList[i]);
			}
		}

		// Token: 0x06008047 RID: 32839 RVA: 0x0016B5B8 File Offset: 0x001699B8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dayNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dayTotalNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekTotalNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.diffWeekNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.diffWeekTotalNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isCreateGold);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dayFreeQuitNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekFreeQuitNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ticketIsEnough);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.commonGradePassNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unlockDiffGradeCommonNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.yetOpenGradeList = new uint[(int)num];
			for (int i = 0; i < this.yetOpenGradeList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.yetOpenGradeList[i]);
			}
		}

		// Token: 0x06008048 RID: 32840 RVA: 0x0016B6B4 File Offset: 0x00169AB4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + (2 + 4 * this.yetOpenGradeList.Length);
		}

		// Token: 0x04003D33 RID: 15667
		public const uint MsgID = 1100059U;

		// Token: 0x04003D34 RID: 15668
		public uint Sequence;

		// Token: 0x04003D35 RID: 15669
		public uint dayNum;

		// Token: 0x04003D36 RID: 15670
		public uint dayTotalNum;

		// Token: 0x04003D37 RID: 15671
		public uint weekNum;

		// Token: 0x04003D38 RID: 15672
		public uint weekTotalNum;

		// Token: 0x04003D39 RID: 15673
		public uint diffWeekNum;

		// Token: 0x04003D3A RID: 15674
		public uint diffWeekTotalNum;

		// Token: 0x04003D3B RID: 15675
		public uint isCreateGold;

		// Token: 0x04003D3C RID: 15676
		public uint dayFreeQuitNum;

		// Token: 0x04003D3D RID: 15677
		public uint weekFreeQuitNum;

		// Token: 0x04003D3E RID: 15678
		public uint ticketIsEnough;

		// Token: 0x04003D3F RID: 15679
		public uint commonGradePassNum;

		// Token: 0x04003D40 RID: 15680
		public uint unlockDiffGradeCommonNum;

		// Token: 0x04003D41 RID: 15681
		public uint[] yetOpenGradeList = new uint[0];
	}
}
