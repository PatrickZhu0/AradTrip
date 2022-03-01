using System;

namespace Protocol
{
	// Token: 0x02000805 RID: 2053
	[Protocol]
	public class SceneCreditPointRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600626E RID: 25198 RVA: 0x001260E5 File Offset: 0x001244E5
		public uint GetMsgID()
		{
			return 510105U;
		}

		// Token: 0x0600626F RID: 25199 RVA: 0x001260EC File Offset: 0x001244EC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006270 RID: 25200 RVA: 0x001260F4 File Offset: 0x001244F4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006271 RID: 25201 RVA: 0x00126100 File Offset: 0x00124500
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.recordList.Length);
			for (int i = 0; i < this.recordList.Length; i++)
			{
				this.recordList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006272 RID: 25202 RVA: 0x00126148 File Offset: 0x00124548
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.recordList = new CreditPointRecord[(int)num];
			for (int i = 0; i < this.recordList.Length; i++)
			{
				this.recordList[i] = new CreditPointRecord();
				this.recordList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006273 RID: 25203 RVA: 0x001261A4 File Offset: 0x001245A4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.recordList.Length);
			for (int i = 0; i < this.recordList.Length; i++)
			{
				this.recordList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006274 RID: 25204 RVA: 0x001261EC File Offset: 0x001245EC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.recordList = new CreditPointRecord[(int)num];
			for (int i = 0; i < this.recordList.Length; i++)
			{
				this.recordList[i] = new CreditPointRecord();
				this.recordList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006275 RID: 25205 RVA: 0x00126248 File Offset: 0x00124648
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.recordList.Length; i++)
			{
				num += this.recordList[i].getLen();
			}
			return num;
		}

		// Token: 0x04002B75 RID: 11125
		public const uint MsgID = 510105U;

		// Token: 0x04002B76 RID: 11126
		public uint Sequence;

		// Token: 0x04002B77 RID: 11127
		public CreditPointRecord[] recordList = new CreditPointRecord[0];
	}
}
