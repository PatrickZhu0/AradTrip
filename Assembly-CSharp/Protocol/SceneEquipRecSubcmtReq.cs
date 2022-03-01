using System;

namespace Protocol
{
	// Token: 0x0200093A RID: 2362
	[Protocol]
	public class SceneEquipRecSubcmtReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B71 RID: 27505 RVA: 0x0013A3D8 File Offset: 0x001387D8
		public uint GetMsgID()
		{
			return 501008U;
		}

		// Token: 0x06006B72 RID: 27506 RVA: 0x0013A3DF File Offset: 0x001387DF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B73 RID: 27507 RVA: 0x0013A3E7 File Offset: 0x001387E7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B74 RID: 27508 RVA: 0x0013A3F0 File Offset: 0x001387F0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemUids.Length);
			for (int i = 0; i < this.itemUids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.itemUids[i]);
			}
		}

		// Token: 0x06006B75 RID: 27509 RVA: 0x0013A438 File Offset: 0x00138838
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

		// Token: 0x06006B76 RID: 27510 RVA: 0x0013A48C File Offset: 0x0013888C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemUids.Length);
			for (int i = 0; i < this.itemUids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.itemUids[i]);
			}
		}

		// Token: 0x06006B77 RID: 27511 RVA: 0x0013A4D4 File Offset: 0x001388D4
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

		// Token: 0x06006B78 RID: 27512 RVA: 0x0013A528 File Offset: 0x00138928
		public int getLen()
		{
			int num = 0;
			return num + (2 + 8 * this.itemUids.Length);
		}

		// Token: 0x040030B1 RID: 12465
		public const uint MsgID = 501008U;

		// Token: 0x040030B2 RID: 12466
		public uint Sequence;

		// Token: 0x040030B3 RID: 12467
		public ulong[] itemUids = new ulong[0];
	}
}
