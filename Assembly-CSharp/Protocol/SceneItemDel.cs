using System;

namespace Protocol
{
	// Token: 0x02000B17 RID: 2839
	[Protocol]
	public class SceneItemDel : IProtocolStream, IGetMsgID
	{
		// Token: 0x060079DE RID: 31198 RVA: 0x0015E7A9 File Offset: 0x0015CBA9
		public uint GetMsgID()
		{
			return 500627U;
		}

		// Token: 0x060079DF RID: 31199 RVA: 0x0015E7B0 File Offset: 0x0015CBB0
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060079E0 RID: 31200 RVA: 0x0015E7B8 File Offset: 0x0015CBB8
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060079E1 RID: 31201 RVA: 0x0015E7C4 File Offset: 0x0015CBC4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.guids.Length);
			for (int i = 0; i < this.guids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.guids[i]);
			}
		}

		// Token: 0x060079E2 RID: 31202 RVA: 0x0015E81C File Offset: 0x0015CC1C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.guids = new ulong[(int)num];
			for (int i = 0; i < this.guids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.guids[i]);
			}
		}

		// Token: 0x060079E3 RID: 31203 RVA: 0x0015E87C File Offset: 0x0015CC7C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.guids.Length);
			for (int i = 0; i < this.guids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.guids[i]);
			}
		}

		// Token: 0x060079E4 RID: 31204 RVA: 0x0015E8D4 File Offset: 0x0015CCD4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.guids = new ulong[(int)num];
			for (int i = 0; i < this.guids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.guids[i]);
			}
		}

		// Token: 0x060079E5 RID: 31205 RVA: 0x0015E934 File Offset: 0x0015CD34
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + (2 + 8 * this.guids.Length);
		}

		// Token: 0x04003978 RID: 14712
		public const uint MsgID = 500627U;

		// Token: 0x04003979 RID: 14713
		public uint Sequence;

		// Token: 0x0400397A RID: 14714
		public uint battleID;

		// Token: 0x0400397B RID: 14715
		public ulong[] guids = new ulong[0];
	}
}
