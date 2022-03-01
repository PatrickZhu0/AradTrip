using System;

namespace Protocol
{
	// Token: 0x02000AB8 RID: 2744
	[Protocol]
	public class SceneChanageRetinueRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600771D RID: 30493 RVA: 0x001587E8 File Offset: 0x00156BE8
		public uint GetMsgID()
		{
			return 507004U;
		}

		// Token: 0x0600771E RID: 30494 RVA: 0x001587EF File Offset: 0x00156BEF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600771F RID: 30495 RVA: 0x001587F7 File Offset: 0x00156BF7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007720 RID: 30496 RVA: 0x00158800 File Offset: 0x00156C00
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.offRetinueIds.Length);
			for (int i = 0; i < this.offRetinueIds.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.offRetinueIds[i]);
			}
		}

		// Token: 0x06007721 RID: 30497 RVA: 0x00158864 File Offset: 0x00156C64
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.offRetinueIds = new ulong[(int)num];
			for (int i = 0; i < this.offRetinueIds.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.offRetinueIds[i]);
			}
		}

		// Token: 0x06007722 RID: 30498 RVA: 0x001588D4 File Offset: 0x00156CD4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.offRetinueIds.Length);
			for (int i = 0; i < this.offRetinueIds.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.offRetinueIds[i]);
			}
		}

		// Token: 0x06007723 RID: 30499 RVA: 0x00158938 File Offset: 0x00156D38
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.offRetinueIds = new ulong[(int)num];
			for (int i = 0; i < this.offRetinueIds.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.offRetinueIds[i]);
			}
		}

		// Token: 0x06007724 RID: 30500 RVA: 0x001589A8 File Offset: 0x00156DA8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			return num + (2 + 8 * this.offRetinueIds.Length);
		}

		// Token: 0x040037C7 RID: 14279
		public const uint MsgID = 507004U;

		// Token: 0x040037C8 RID: 14280
		public uint Sequence;

		// Token: 0x040037C9 RID: 14281
		public uint result;

		// Token: 0x040037CA RID: 14282
		public ulong id;

		// Token: 0x040037CB RID: 14283
		public ulong[] offRetinueIds = new ulong[0];
	}
}
