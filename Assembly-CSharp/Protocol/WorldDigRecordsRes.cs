using System;

namespace Protocol
{
	// Token: 0x020007A3 RID: 1955
	[Protocol]
	public class WorldDigRecordsRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F8F RID: 24463 RVA: 0x0011DEC8 File Offset: 0x0011C2C8
		public uint GetMsgID()
		{
			return 608216U;
		}

		// Token: 0x06005F90 RID: 24464 RVA: 0x0011DECF File Offset: 0x0011C2CF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F91 RID: 24465 RVA: 0x0011DED7 File Offset: 0x0011C2D7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F92 RID: 24466 RVA: 0x0011DEE0 File Offset: 0x0011C2E0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infos.Length);
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005F93 RID: 24467 RVA: 0x0011DF34 File Offset: 0x0011C334
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infos = new DigRecordInfo[(int)num];
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i] = new DigRecordInfo();
				this.infos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005F94 RID: 24468 RVA: 0x0011DF9C File Offset: 0x0011C39C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infos.Length);
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005F95 RID: 24469 RVA: 0x0011DFF0 File Offset: 0x0011C3F0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infos = new DigRecordInfo[(int)num];
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i] = new DigRecordInfo();
				this.infos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005F96 RID: 24470 RVA: 0x0011E058 File Offset: 0x0011C458
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.infos.Length; i++)
			{
				num += this.infos[i].getLen();
			}
			return num;
		}

		// Token: 0x04002770 RID: 10096
		public const uint MsgID = 608216U;

		// Token: 0x04002771 RID: 10097
		public uint Sequence;

		// Token: 0x04002772 RID: 10098
		public uint result;

		// Token: 0x04002773 RID: 10099
		public DigRecordInfo[] infos = new DigRecordInfo[0];
	}
}
