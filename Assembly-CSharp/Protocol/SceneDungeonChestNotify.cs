using System;

namespace Protocol
{
	// Token: 0x020007C6 RID: 1990
	[Protocol]
	public class SceneDungeonChestNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006067 RID: 24679 RVA: 0x00122170 File Offset: 0x00120570
		public uint GetMsgID()
		{
			return 506816U;
		}

		// Token: 0x06006068 RID: 24680 RVA: 0x00122177 File Offset: 0x00120577
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006069 RID: 24681 RVA: 0x0012217F File Offset: 0x0012057F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600606A RID: 24682 RVA: 0x00122188 File Offset: 0x00120588
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.payChestCostItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.payChestCost);
		}

		// Token: 0x0600606B RID: 24683 RVA: 0x001221A6 File Offset: 0x001205A6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.payChestCostItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.payChestCost);
		}

		// Token: 0x0600606C RID: 24684 RVA: 0x001221C4 File Offset: 0x001205C4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.payChestCostItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.payChestCost);
		}

		// Token: 0x0600606D RID: 24685 RVA: 0x001221E2 File Offset: 0x001205E2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.payChestCostItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.payChestCost);
		}

		// Token: 0x0600606E RID: 24686 RVA: 0x00122200 File Offset: 0x00120600
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002830 RID: 10288
		public const uint MsgID = 506816U;

		// Token: 0x04002831 RID: 10289
		public uint Sequence;

		// Token: 0x04002832 RID: 10290
		public uint payChestCostItemId;

		// Token: 0x04002833 RID: 10291
		public uint payChestCost;
	}
}
