using System;

namespace Protocol
{
	// Token: 0x02000914 RID: 2324
	[Protocol]
	public class SCMallBatchBuyRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A24 RID: 27172 RVA: 0x00138139 File Offset: 0x00136539
		public uint GetMsgID()
		{
			return 602813U;
		}

		// Token: 0x06006A25 RID: 27173 RVA: 0x00138140 File Offset: 0x00136540
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A26 RID: 27174 RVA: 0x00138148 File Offset: 0x00136548
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A27 RID: 27175 RVA: 0x00138154 File Offset: 0x00136554
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemUids.Length);
			for (int i = 0; i < this.itemUids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.itemUids[i]);
			}
		}

		// Token: 0x06006A28 RID: 27176 RVA: 0x001381AC File Offset: 0x001365AC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemUids = new ulong[(int)num];
			for (int i = 0; i < this.itemUids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUids[i]);
			}
		}

		// Token: 0x06006A29 RID: 27177 RVA: 0x0013820C File Offset: 0x0013660C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemUids.Length);
			for (int i = 0; i < this.itemUids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.itemUids[i]);
			}
		}

		// Token: 0x06006A2A RID: 27178 RVA: 0x00138264 File Offset: 0x00136664
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemUids = new ulong[(int)num];
			for (int i = 0; i < this.itemUids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUids[i]);
			}
		}

		// Token: 0x06006A2B RID: 27179 RVA: 0x001382C4 File Offset: 0x001366C4
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + (2 + 8 * this.itemUids.Length);
		}

		// Token: 0x04003023 RID: 12323
		public const uint MsgID = 602813U;

		// Token: 0x04003024 RID: 12324
		public uint Sequence;

		// Token: 0x04003025 RID: 12325
		public uint code;

		// Token: 0x04003026 RID: 12326
		public ulong[] itemUids = new ulong[0];
	}
}
