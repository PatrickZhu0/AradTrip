using System;

namespace Protocol
{
	// Token: 0x02000C9E RID: 3230
	[Protocol]
	public class MasterGiveEquip : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008545 RID: 34117 RVA: 0x00175BCC File Offset: 0x00173FCC
		public uint GetMsgID()
		{
			return 501701U;
		}

		// Token: 0x06008546 RID: 34118 RVA: 0x00175BD3 File Offset: 0x00173FD3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008547 RID: 34119 RVA: 0x00175BDB File Offset: 0x00173FDB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008548 RID: 34120 RVA: 0x00175BE4 File Offset: 0x00173FE4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemUids.Length);
			for (int i = 0; i < this.itemUids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.itemUids[i]);
			}
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipleId);
		}

		// Token: 0x06008549 RID: 34121 RVA: 0x00175C3C File Offset: 0x0017403C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemUids = new ulong[(int)num];
			for (int i = 0; i < this.itemUids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUids[i]);
			}
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipleId);
		}

		// Token: 0x0600854A RID: 34122 RVA: 0x00175C9C File Offset: 0x0017409C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemUids.Length);
			for (int i = 0; i < this.itemUids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.itemUids[i]);
			}
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipleId);
		}

		// Token: 0x0600854B RID: 34123 RVA: 0x00175CF4 File Offset: 0x001740F4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemUids = new ulong[(int)num];
			for (int i = 0; i < this.itemUids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUids[i]);
			}
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipleId);
		}

		// Token: 0x0600854C RID: 34124 RVA: 0x00175D54 File Offset: 0x00174154
		public int getLen()
		{
			int num = 0;
			num += 2 + 8 * this.itemUids.Length;
			return num + 8;
		}

		// Token: 0x04003FD9 RID: 16345
		public const uint MsgID = 501701U;

		// Token: 0x04003FDA RID: 16346
		public uint Sequence;

		// Token: 0x04003FDB RID: 16347
		public ulong[] itemUids = new ulong[0];

		// Token: 0x04003FDC RID: 16348
		public ulong discipleId;
	}
}
