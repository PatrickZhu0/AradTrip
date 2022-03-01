using System;

namespace Protocol
{
	// Token: 0x02000A4F RID: 2639
	[Protocol]
	public class SceneSyncPetList : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600741D RID: 29725 RVA: 0x00150C68 File Offset: 0x0014F068
		public uint GetMsgID()
		{
			return 502201U;
		}

		// Token: 0x0600741E RID: 29726 RVA: 0x00150C6F File Offset: 0x0014F06F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600741F RID: 29727 RVA: 0x00150C77 File Offset: 0x0014F077
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007420 RID: 29728 RVA: 0x00150C80 File Offset: 0x0014F080
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.followPetId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.battlePets.Length);
			for (int i = 0; i < this.battlePets.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.battlePets[i]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.petList.Length);
			for (int j = 0; j < this.petList.Length; j++)
			{
				this.petList[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007421 RID: 29729 RVA: 0x00150D10 File Offset: 0x0014F110
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.followPetId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.battlePets = new ulong[(int)num];
			for (int i = 0; i < this.battlePets.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.battlePets[i]);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.petList = new PetInfo[(int)num2];
			for (int j = 0; j < this.petList.Length; j++)
			{
				this.petList[j] = new PetInfo();
				this.petList[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007422 RID: 29730 RVA: 0x00150DC0 File Offset: 0x0014F1C0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.followPetId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.battlePets.Length);
			for (int i = 0; i < this.battlePets.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.battlePets[i]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.petList.Length);
			for (int j = 0; j < this.petList.Length; j++)
			{
				this.petList[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007423 RID: 29731 RVA: 0x00150E50 File Offset: 0x0014F250
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.followPetId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.battlePets = new ulong[(int)num];
			for (int i = 0; i < this.battlePets.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.battlePets[i]);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.petList = new PetInfo[(int)num2];
			for (int j = 0; j < this.petList.Length; j++)
			{
				this.petList[j] = new PetInfo();
				this.petList[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007424 RID: 29732 RVA: 0x00150F00 File Offset: 0x0014F300
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 2 + 8 * this.battlePets.Length;
			num += 2;
			for (int i = 0; i < this.petList.Length; i++)
			{
				num += this.petList[i].getLen();
			}
			return num;
		}

		// Token: 0x040035ED RID: 13805
		public const uint MsgID = 502201U;

		// Token: 0x040035EE RID: 13806
		public uint Sequence;

		// Token: 0x040035EF RID: 13807
		public ulong followPetId;

		// Token: 0x040035F0 RID: 13808
		public ulong[] battlePets = new ulong[0];

		// Token: 0x040035F1 RID: 13809
		public PetInfo[] petList = new PetInfo[0];
	}
}
