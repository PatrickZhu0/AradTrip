using System;

namespace Protocol
{
	// Token: 0x020009A1 RID: 2465
	[Protocol]
	public class WorldGetItemFriendPresentInfosRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006EF8 RID: 28408 RVA: 0x00140DB4 File Offset: 0x0013F1B4
		public uint GetMsgID()
		{
			return 609702U;
		}

		// Token: 0x06006EF9 RID: 28409 RVA: 0x00140DBB File Offset: 0x0013F1BB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006EFA RID: 28410 RVA: 0x00140DC3 File Offset: 0x0013F1C3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006EFB RID: 28411 RVA: 0x00140DCC File Offset: 0x0013F1CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.presentInfos.Length);
			for (int i = 0; i < this.presentInfos.Length; i++)
			{
				this.presentInfos[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.recvedTotal);
			BaseDLL.encode_uint32(buffer, ref pos_, this.recvedTotalLimit);
		}

		// Token: 0x06006EFC RID: 28412 RVA: 0x00140E3C File Offset: 0x0013F23C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.presentInfos = new FriendPresentInfo[(int)num];
			for (int i = 0; i < this.presentInfos.Length; i++)
			{
				this.presentInfos[i] = new FriendPresentInfo();
				this.presentInfos[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.recvedTotal);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.recvedTotalLimit);
		}

		// Token: 0x06006EFD RID: 28413 RVA: 0x00140EC0 File Offset: 0x0013F2C0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.presentInfos.Length);
			for (int i = 0; i < this.presentInfos.Length; i++)
			{
				this.presentInfos[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.recvedTotal);
			BaseDLL.encode_uint32(buffer, ref pos_, this.recvedTotalLimit);
		}

		// Token: 0x06006EFE RID: 28414 RVA: 0x00140F30 File Offset: 0x0013F330
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.presentInfos = new FriendPresentInfo[(int)num];
			for (int i = 0; i < this.presentInfos.Length; i++)
			{
				this.presentInfos[i] = new FriendPresentInfo();
				this.presentInfos[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.recvedTotal);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.recvedTotalLimit);
		}

		// Token: 0x06006EFF RID: 28415 RVA: 0x00140FB4 File Offset: 0x0013F3B4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.presentInfos.Length; i++)
			{
				num += this.presentInfos[i].getLen();
			}
			num += 4;
			return num + 4;
		}

		// Token: 0x04003255 RID: 12885
		public const uint MsgID = 609702U;

		// Token: 0x04003256 RID: 12886
		public uint Sequence;

		// Token: 0x04003257 RID: 12887
		public uint dataId;

		// Token: 0x04003258 RID: 12888
		public FriendPresentInfo[] presentInfos = new FriendPresentInfo[0];

		// Token: 0x04003259 RID: 12889
		public uint recvedTotal;

		// Token: 0x0400325A RID: 12890
		public uint recvedTotalLimit;
	}
}
