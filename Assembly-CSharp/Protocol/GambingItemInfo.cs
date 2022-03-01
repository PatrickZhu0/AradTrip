using System;

namespace Protocol
{
	// Token: 0x020008D1 RID: 2257
	public class GambingItemInfo : IProtocolStream
	{
		// Token: 0x060067DB RID: 26587 RVA: 0x00133744 File Offset: 0x00131B44
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemNum);
			BaseDLL.encode_uint16(buffer, ref pos_, this.sortId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemDataId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.costMoneyId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unitPrice);
			BaseDLL.encode_uint16(buffer, ref pos_, this.restGroups);
			BaseDLL.encode_uint16(buffer, ref pos_, this.totalGroups);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rewardsPerCopy.Length);
			for (int i = 0; i < this.rewardsPerCopy.Length; i++)
			{
				this.rewardsPerCopy[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, this.curGroupId);
			BaseDLL.encode_int8(buffer, ref pos_, this.statusOfCurGroup);
			BaseDLL.encode_uint32(buffer, ref pos_, this.soldCopiesInCurGroup);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalCopiesOfCurGroup);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sellBeginTime);
			this.mineGambingInfo.encode(buffer, ref pos_);
		}

		// Token: 0x060067DC RID: 26588 RVA: 0x00133850 File Offset: 0x00131C50
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemNum);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.sortId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemDataId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.costMoneyId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unitPrice);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.restGroups);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.totalGroups);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.rewardsPerCopy = new ItemReward[(int)num];
			for (int i = 0; i < this.rewardsPerCopy.Length; i++)
			{
				this.rewardsPerCopy[i] = new ItemReward();
				this.rewardsPerCopy[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.curGroupId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.statusOfCurGroup);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.soldCopiesInCurGroup);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalCopiesOfCurGroup);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sellBeginTime);
			this.mineGambingInfo.decode(buffer, ref pos_);
		}

		// Token: 0x060067DD RID: 26589 RVA: 0x00133970 File Offset: 0x00131D70
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemNum);
			BaseDLL.encode_uint16(buffer, ref pos_, this.sortId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemDataId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.costMoneyId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unitPrice);
			BaseDLL.encode_uint16(buffer, ref pos_, this.restGroups);
			BaseDLL.encode_uint16(buffer, ref pos_, this.totalGroups);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rewardsPerCopy.Length);
			for (int i = 0; i < this.rewardsPerCopy.Length; i++)
			{
				this.rewardsPerCopy[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, this.curGroupId);
			BaseDLL.encode_int8(buffer, ref pos_, this.statusOfCurGroup);
			BaseDLL.encode_uint32(buffer, ref pos_, this.soldCopiesInCurGroup);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalCopiesOfCurGroup);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sellBeginTime);
			this.mineGambingInfo.encode(buffer, ref pos_);
		}

		// Token: 0x060067DE RID: 26590 RVA: 0x00133A7C File Offset: 0x00131E7C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemNum);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.sortId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemDataId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.costMoneyId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unitPrice);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.restGroups);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.totalGroups);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.rewardsPerCopy = new ItemReward[(int)num];
			for (int i = 0; i < this.rewardsPerCopy.Length; i++)
			{
				this.rewardsPerCopy[i] = new ItemReward();
				this.rewardsPerCopy[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.curGroupId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.statusOfCurGroup);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.soldCopiesInCurGroup);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalCopiesOfCurGroup);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sellBeginTime);
			this.mineGambingInfo.decode(buffer, ref pos_);
		}

		// Token: 0x060067DF RID: 26591 RVA: 0x00133B9C File Offset: 0x00131F9C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			num += 2;
			num += 2;
			for (int i = 0; i < this.rewardsPerCopy.Length; i++)
			{
				num += this.rewardsPerCopy[i].getLen();
			}
			num += 2;
			num++;
			num += 4;
			num += 4;
			num += 4;
			return num + this.mineGambingInfo.getLen();
		}

		// Token: 0x04002F05 RID: 12037
		public uint gambingItemId;

		// Token: 0x04002F06 RID: 12038
		public uint gambingItemNum;

		// Token: 0x04002F07 RID: 12039
		public ushort sortId;

		// Token: 0x04002F08 RID: 12040
		public uint itemDataId;

		// Token: 0x04002F09 RID: 12041
		public uint costMoneyId;

		// Token: 0x04002F0A RID: 12042
		public uint unitPrice;

		// Token: 0x04002F0B RID: 12043
		public ushort restGroups;

		// Token: 0x04002F0C RID: 12044
		public ushort totalGroups;

		// Token: 0x04002F0D RID: 12045
		public ItemReward[] rewardsPerCopy = new ItemReward[0];

		// Token: 0x04002F0E RID: 12046
		public ushort curGroupId;

		// Token: 0x04002F0F RID: 12047
		public byte statusOfCurGroup;

		// Token: 0x04002F10 RID: 12048
		public uint soldCopiesInCurGroup;

		// Token: 0x04002F11 RID: 12049
		public uint totalCopiesOfCurGroup;

		// Token: 0x04002F12 RID: 12050
		public uint sellBeginTime;

		// Token: 0x04002F13 RID: 12051
		public GambingParticipantInfo mineGambingInfo = new GambingParticipantInfo();
	}
}
