using System;

namespace Protocol
{
	// Token: 0x02000AB5 RID: 2741
	[Protocol]
	public class SceneSyncRetinueList : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007702 RID: 30466 RVA: 0x001583B4 File Offset: 0x001567B4
		public uint GetMsgID()
		{
			return 507001U;
		}

		// Token: 0x06007703 RID: 30467 RVA: 0x001583BB File Offset: 0x001567BB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007704 RID: 30468 RVA: 0x001583C3 File Offset: 0x001567C3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007705 RID: 30469 RVA: 0x001583CC File Offset: 0x001567CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.offRetinueIds.Length);
			for (int i = 0; i < this.offRetinueIds.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.offRetinueIds[i]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.retinueList.Length);
			for (int j = 0; j < this.retinueList.Length; j++)
			{
				this.retinueList[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007706 RID: 30470 RVA: 0x0015845C File Offset: 0x0015685C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.offRetinueIds = new ulong[(int)num];
			for (int i = 0; i < this.offRetinueIds.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.offRetinueIds[i]);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.retinueList = new RetinueInfo[(int)num2];
			for (int j = 0; j < this.retinueList.Length; j++)
			{
				this.retinueList[j] = new RetinueInfo();
				this.retinueList[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007707 RID: 30471 RVA: 0x0015850C File Offset: 0x0015690C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.offRetinueIds.Length);
			for (int i = 0; i < this.offRetinueIds.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.offRetinueIds[i]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.retinueList.Length);
			for (int j = 0; j < this.retinueList.Length; j++)
			{
				this.retinueList[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007708 RID: 30472 RVA: 0x0015859C File Offset: 0x0015699C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.offRetinueIds = new ulong[(int)num];
			for (int i = 0; i < this.offRetinueIds.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.offRetinueIds[i]);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.retinueList = new RetinueInfo[(int)num2];
			for (int j = 0; j < this.retinueList.Length; j++)
			{
				this.retinueList[j] = new RetinueInfo();
				this.retinueList[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007709 RID: 30473 RVA: 0x0015864C File Offset: 0x00156A4C
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 2 + 8 * this.offRetinueIds.Length;
			num += 2;
			for (int i = 0; i < this.retinueList.Length; i++)
			{
				num += this.retinueList[i].getLen();
			}
			return num;
		}

		// Token: 0x040037BB RID: 14267
		public const uint MsgID = 507001U;

		// Token: 0x040037BC RID: 14268
		public uint Sequence;

		// Token: 0x040037BD RID: 14269
		public ulong id;

		// Token: 0x040037BE RID: 14270
		public ulong[] offRetinueIds = new ulong[0];

		// Token: 0x040037BF RID: 14271
		public RetinueInfo[] retinueList = new RetinueInfo[0];
	}
}
