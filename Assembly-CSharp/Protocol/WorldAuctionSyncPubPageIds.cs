using System;

namespace Protocol
{
	// Token: 0x020006DA RID: 1754
	[Protocol]
	public class WorldAuctionSyncPubPageIds : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005956 RID: 22870 RVA: 0x0010F9A0 File Offset: 0x0010DDA0
		public uint GetMsgID()
		{
			return 603928U;
		}

		// Token: 0x06005957 RID: 22871 RVA: 0x0010F9A7 File Offset: 0x0010DDA7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005958 RID: 22872 RVA: 0x0010F9AF File Offset: 0x0010DDAF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005959 RID: 22873 RVA: 0x0010F9B8 File Offset: 0x0010DDB8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pageIds.Length);
			for (int i = 0; i < this.pageIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.pageIds[i]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.shieldItemList.Length);
			for (int j = 0; j < this.shieldItemList.Length; j++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.shieldItemList[j]);
			}
		}

		// Token: 0x0600595A RID: 22874 RVA: 0x0010FA3C File Offset: 0x0010DE3C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.pageIds = new uint[(int)num];
			for (int i = 0; i < this.pageIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.pageIds[i]);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.shieldItemList = new uint[(int)num2];
			for (int j = 0; j < this.shieldItemList.Length; j++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.shieldItemList[j]);
			}
		}

		// Token: 0x0600595B RID: 22875 RVA: 0x0010FAD4 File Offset: 0x0010DED4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pageIds.Length);
			for (int i = 0; i < this.pageIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.pageIds[i]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.shieldItemList.Length);
			for (int j = 0; j < this.shieldItemList.Length; j++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.shieldItemList[j]);
			}
		}

		// Token: 0x0600595C RID: 22876 RVA: 0x0010FB58 File Offset: 0x0010DF58
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.pageIds = new uint[(int)num];
			for (int i = 0; i < this.pageIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.pageIds[i]);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.shieldItemList = new uint[(int)num2];
			for (int j = 0; j < this.shieldItemList.Length; j++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.shieldItemList[j]);
			}
		}

		// Token: 0x0600595D RID: 22877 RVA: 0x0010FBF0 File Offset: 0x0010DFF0
		public int getLen()
		{
			int num = 0;
			num += 2 + 4 * this.pageIds.Length;
			return num + (2 + 4 * this.shieldItemList.Length);
		}

		// Token: 0x040023F5 RID: 9205
		public const uint MsgID = 603928U;

		// Token: 0x040023F6 RID: 9206
		public uint Sequence;

		// Token: 0x040023F7 RID: 9207
		public uint[] pageIds = new uint[0];

		// Token: 0x040023F8 RID: 9208
		public uint[] shieldItemList = new uint[0];
	}
}
