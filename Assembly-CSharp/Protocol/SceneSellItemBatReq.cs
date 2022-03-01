using System;

namespace Protocol
{
	// Token: 0x02000936 RID: 2358
	[Protocol]
	public class SceneSellItemBatReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B4D RID: 27469 RVA: 0x0013A07D File Offset: 0x0013847D
		public uint GetMsgID()
		{
			return 500973U;
		}

		// Token: 0x06006B4E RID: 27470 RVA: 0x0013A084 File Offset: 0x00138484
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B4F RID: 27471 RVA: 0x0013A08C File Offset: 0x0013848C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B50 RID: 27472 RVA: 0x0013A098 File Offset: 0x00138498
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemUids.Length);
			for (int i = 0; i < this.itemUids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.itemUids[i]);
			}
		}

		// Token: 0x06006B51 RID: 27473 RVA: 0x0013A0E0 File Offset: 0x001384E0
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemUids = new ulong[(int)num];
			for (int i = 0; i < this.itemUids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUids[i]);
			}
		}

		// Token: 0x06006B52 RID: 27474 RVA: 0x0013A134 File Offset: 0x00138534
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemUids.Length);
			for (int i = 0; i < this.itemUids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.itemUids[i]);
			}
		}

		// Token: 0x06006B53 RID: 27475 RVA: 0x0013A17C File Offset: 0x0013857C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemUids = new ulong[(int)num];
			for (int i = 0; i < this.itemUids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUids[i]);
			}
		}

		// Token: 0x06006B54 RID: 27476 RVA: 0x0013A1D0 File Offset: 0x001385D0
		public int getLen()
		{
			int num = 0;
			return num + (2 + 8 * this.itemUids.Length);
		}

		// Token: 0x040030A3 RID: 12451
		public const uint MsgID = 500973U;

		// Token: 0x040030A4 RID: 12452
		public uint Sequence;

		// Token: 0x040030A5 RID: 12453
		public ulong[] itemUids = new ulong[0];
	}
}
