using System;

namespace Protocol
{
	// Token: 0x02000A1D RID: 2589
	[Protocol]
	public class WorldGetPlayerTitleSyncList : IProtocolStream, IGetMsgID
	{
		// Token: 0x060072B8 RID: 29368 RVA: 0x0014C0E4 File Offset: 0x0014A4E4
		public uint GetMsgID()
		{
			return 609201U;
		}

		// Token: 0x060072B9 RID: 29369 RVA: 0x0014C0EB File Offset: 0x0014A4EB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060072BA RID: 29370 RVA: 0x0014C0F3 File Offset: 0x0014A4F3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060072BB RID: 29371 RVA: 0x0014C0FC File Offset: 0x0014A4FC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.titles.Length);
			for (int i = 0; i < this.titles.Length; i++)
			{
				this.titles[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060072BC RID: 29372 RVA: 0x0014C144 File Offset: 0x0014A544
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.titles = new PlayerTitleInfo[(int)num];
			for (int i = 0; i < this.titles.Length; i++)
			{
				this.titles[i] = new PlayerTitleInfo();
				this.titles[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060072BD RID: 29373 RVA: 0x0014C1A0 File Offset: 0x0014A5A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.titles.Length);
			for (int i = 0; i < this.titles.Length; i++)
			{
				this.titles[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060072BE RID: 29374 RVA: 0x0014C1E8 File Offset: 0x0014A5E8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.titles = new PlayerTitleInfo[(int)num];
			for (int i = 0; i < this.titles.Length; i++)
			{
				this.titles[i] = new PlayerTitleInfo();
				this.titles[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060072BF RID: 29375 RVA: 0x0014C244 File Offset: 0x0014A644
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.titles.Length; i++)
			{
				num += this.titles[i].getLen();
			}
			return num;
		}

		// Token: 0x040034B9 RID: 13497
		public const uint MsgID = 609201U;

		// Token: 0x040034BA RID: 13498
		public uint Sequence;

		// Token: 0x040034BB RID: 13499
		public PlayerTitleInfo[] titles = new PlayerTitleInfo[0];
	}
}
