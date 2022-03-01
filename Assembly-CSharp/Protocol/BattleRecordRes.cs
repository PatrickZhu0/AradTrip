using System;

namespace Protocol
{
	// Token: 0x02000741 RID: 1857
	[Protocol]
	public class BattleRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005C8C RID: 23692 RVA: 0x001172B4 File Offset: 0x001156B4
		public uint GetMsgID()
		{
			return 708313U;
		}

		// Token: 0x06005C8D RID: 23693 RVA: 0x001172BB File Offset: 0x001156BB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005C8E RID: 23694 RVA: 0x001172C3 File Offset: 0x001156C3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005C8F RID: 23695 RVA: 0x001172CC File Offset: 0x001156CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.BattleRecordList.Length);
			for (int i = 0; i < this.BattleRecordList.Length; i++)
			{
				this.BattleRecordList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C90 RID: 23696 RVA: 0x00117314 File Offset: 0x00115714
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.BattleRecordList = new BattleRecord[(int)num];
			for (int i = 0; i < this.BattleRecordList.Length; i++)
			{
				this.BattleRecordList[i] = new BattleRecord();
				this.BattleRecordList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C91 RID: 23697 RVA: 0x00117370 File Offset: 0x00115770
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.BattleRecordList.Length);
			for (int i = 0; i < this.BattleRecordList.Length; i++)
			{
				this.BattleRecordList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C92 RID: 23698 RVA: 0x001173B8 File Offset: 0x001157B8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.BattleRecordList = new BattleRecord[(int)num];
			for (int i = 0; i < this.BattleRecordList.Length; i++)
			{
				this.BattleRecordList[i] = new BattleRecord();
				this.BattleRecordList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C93 RID: 23699 RVA: 0x00117414 File Offset: 0x00115814
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.BattleRecordList.Length; i++)
			{
				num += this.BattleRecordList[i].getLen();
			}
			return num;
		}

		// Token: 0x040025CA RID: 9674
		public const uint MsgID = 708313U;

		// Token: 0x040025CB RID: 9675
		public uint Sequence;

		// Token: 0x040025CC RID: 9676
		public BattleRecord[] BattleRecordList = new BattleRecord[0];
	}
}
