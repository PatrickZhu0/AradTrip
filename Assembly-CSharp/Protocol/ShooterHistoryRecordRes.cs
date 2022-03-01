using System;

namespace Protocol
{
	// Token: 0x02000738 RID: 1848
	[Protocol]
	public class ShooterHistoryRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005C41 RID: 23617 RVA: 0x001169D0 File Offset: 0x00114DD0
		public uint GetMsgID()
		{
			return 708306U;
		}

		// Token: 0x06005C42 RID: 23618 RVA: 0x001169D7 File Offset: 0x00114DD7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005C43 RID: 23619 RVA: 0x001169DF File Offset: 0x00114DDF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005C44 RID: 23620 RVA: 0x001169E8 File Offset: 0x00114DE8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.recordList.Length);
			for (int i = 0; i < this.recordList.Length; i++)
			{
				this.recordList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C45 RID: 23621 RVA: 0x00116A3C File Offset: 0x00114E3C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.recordList = new ShooterRecord[(int)num];
			for (int i = 0; i < this.recordList.Length; i++)
			{
				this.recordList[i] = new ShooterRecord();
				this.recordList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C46 RID: 23622 RVA: 0x00116AA4 File Offset: 0x00114EA4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.recordList.Length);
			for (int i = 0; i < this.recordList.Length; i++)
			{
				this.recordList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C47 RID: 23623 RVA: 0x00116AF8 File Offset: 0x00114EF8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.recordList = new ShooterRecord[(int)num];
			for (int i = 0; i < this.recordList.Length; i++)
			{
				this.recordList[i] = new ShooterRecord();
				this.recordList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C48 RID: 23624 RVA: 0x00116B60 File Offset: 0x00114F60
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.recordList.Length; i++)
			{
				num += this.recordList[i].getLen();
			}
			return num;
		}

		// Token: 0x040025A9 RID: 9641
		public const uint MsgID = 708306U;

		// Token: 0x040025AA RID: 9642
		public uint Sequence;

		// Token: 0x040025AB RID: 9643
		public uint id;

		// Token: 0x040025AC RID: 9644
		public ShooterRecord[] recordList = new ShooterRecord[0];
	}
}
