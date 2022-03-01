using System;

namespace Protocol
{
	// Token: 0x02000C87 RID: 3207
	[Protocol]
	public class WorldRelationFindPlayersRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008485 RID: 33925 RVA: 0x001737DC File Offset: 0x00171BDC
		public uint GetMsgID()
		{
			return 601710U;
		}

		// Token: 0x06008486 RID: 33926 RVA: 0x001737E3 File Offset: 0x00171BE3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008487 RID: 33927 RVA: 0x001737EB File Offset: 0x00171BEB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008488 RID: 33928 RVA: 0x001737F4 File Offset: 0x00171BF4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.friendList.Length);
			for (int i = 0; i < this.friendList.Length; i++)
			{
				this.friendList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06008489 RID: 33929 RVA: 0x00173848 File Offset: 0x00171C48
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.friendList = new QuickFriendInfo[(int)num];
			for (int i = 0; i < this.friendList.Length; i++)
			{
				this.friendList[i] = new QuickFriendInfo();
				this.friendList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600848A RID: 33930 RVA: 0x001738B0 File Offset: 0x00171CB0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.friendList.Length);
			for (int i = 0; i < this.friendList.Length; i++)
			{
				this.friendList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600848B RID: 33931 RVA: 0x00173904 File Offset: 0x00171D04
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.friendList = new QuickFriendInfo[(int)num];
			for (int i = 0; i < this.friendList.Length; i++)
			{
				this.friendList[i] = new QuickFriendInfo();
				this.friendList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600848C RID: 33932 RVA: 0x0017396C File Offset: 0x00171D6C
		public int getLen()
		{
			int num = 0;
			num++;
			num += 2;
			for (int i = 0; i < this.friendList.Length; i++)
			{
				num += this.friendList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003F6F RID: 16239
		public const uint MsgID = 601710U;

		// Token: 0x04003F70 RID: 16240
		public uint Sequence;

		// Token: 0x04003F71 RID: 16241
		public byte type;

		// Token: 0x04003F72 RID: 16242
		public QuickFriendInfo[] friendList = new QuickFriendInfo[0];
	}
}
