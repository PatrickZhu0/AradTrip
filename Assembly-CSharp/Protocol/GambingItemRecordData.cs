using System;

namespace Protocol
{
	// Token: 0x020008D4 RID: 2260
	public class GambingItemRecordData : IProtocolStream
	{
		// Token: 0x060067ED RID: 26605 RVA: 0x001344CC File Offset: 0x001328CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemNum);
			BaseDLL.encode_uint16(buffer, ref pos_, this.sortId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemDataId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.soldOutTimestamp);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.groupRecordData.Length);
			for (int i = 0; i < this.groupRecordData.Length; i++)
			{
				this.groupRecordData[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060067EE RID: 26606 RVA: 0x00134558 File Offset: 0x00132958
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemNum);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.sortId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemDataId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.soldOutTimestamp);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.groupRecordData = new GambingGroupRecordData[(int)num];
			for (int i = 0; i < this.groupRecordData.Length; i++)
			{
				this.groupRecordData[i] = new GambingGroupRecordData();
				this.groupRecordData[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060067EF RID: 26607 RVA: 0x001345F8 File Offset: 0x001329F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemNum);
			BaseDLL.encode_uint16(buffer, ref pos_, this.sortId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemDataId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.soldOutTimestamp);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.groupRecordData.Length);
			for (int i = 0; i < this.groupRecordData.Length; i++)
			{
				this.groupRecordData[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060067F0 RID: 26608 RVA: 0x00134684 File Offset: 0x00132A84
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemNum);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.sortId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemDataId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.soldOutTimestamp);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.groupRecordData = new GambingGroupRecordData[(int)num];
			for (int i = 0; i < this.groupRecordData.Length; i++)
			{
				this.groupRecordData[i] = new GambingGroupRecordData();
				this.groupRecordData[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060067F1 RID: 26609 RVA: 0x00134724 File Offset: 0x00132B24
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.groupRecordData.Length; i++)
			{
				num += this.groupRecordData[i].getLen();
			}
			return num;
		}

		// Token: 0x04002F26 RID: 12070
		public uint gambingItemId;

		// Token: 0x04002F27 RID: 12071
		public uint gambingItemNum;

		// Token: 0x04002F28 RID: 12072
		public ushort sortId;

		// Token: 0x04002F29 RID: 12073
		public uint itemDataId;

		// Token: 0x04002F2A RID: 12074
		public uint soldOutTimestamp;

		// Token: 0x04002F2B RID: 12075
		public GambingGroupRecordData[] groupRecordData = new GambingGroupRecordData[0];
	}
}
