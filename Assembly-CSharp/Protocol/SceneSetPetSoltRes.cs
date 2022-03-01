using System;

namespace Protocol
{
	// Token: 0x02000A53 RID: 2643
	[Protocol]
	public class SceneSetPetSoltRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007441 RID: 29761 RVA: 0x001510C0 File Offset: 0x0014F4C0
		public uint GetMsgID()
		{
			return 502206U;
		}

		// Token: 0x06007442 RID: 29762 RVA: 0x001510C7 File Offset: 0x0014F4C7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007443 RID: 29763 RVA: 0x001510CF File Offset: 0x0014F4CF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007444 RID: 29764 RVA: 0x001510D8 File Offset: 0x0014F4D8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.battlePets.Length);
			for (int i = 0; i < this.battlePets.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.battlePets[i]);
			}
			BaseDLL.encode_uint64(buffer, ref pos_, this.followPetId);
		}

		// Token: 0x06007445 RID: 29765 RVA: 0x0015113C File Offset: 0x0014F53C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.battlePets = new ulong[(int)num];
			for (int i = 0; i < this.battlePets.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.battlePets[i]);
			}
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.followPetId);
		}

		// Token: 0x06007446 RID: 29766 RVA: 0x001511AC File Offset: 0x0014F5AC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.battlePets.Length);
			for (int i = 0; i < this.battlePets.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.battlePets[i]);
			}
			BaseDLL.encode_uint64(buffer, ref pos_, this.followPetId);
		}

		// Token: 0x06007447 RID: 29767 RVA: 0x00151210 File Offset: 0x0014F610
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.battlePets = new ulong[(int)num];
			for (int i = 0; i < this.battlePets.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.battlePets[i]);
			}
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.followPetId);
		}

		// Token: 0x06007448 RID: 29768 RVA: 0x00151280 File Offset: 0x0014F680
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2 + 8 * this.battlePets.Length;
			return num + 8;
		}

		// Token: 0x040035FB RID: 13819
		public const uint MsgID = 502206U;

		// Token: 0x040035FC RID: 13820
		public uint Sequence;

		// Token: 0x040035FD RID: 13821
		public uint result;

		// Token: 0x040035FE RID: 13822
		public ulong[] battlePets = new ulong[0];

		// Token: 0x040035FF RID: 13823
		public ulong followPetId;
	}
}
