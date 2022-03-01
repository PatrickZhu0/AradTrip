using System;

namespace Protocol
{
	// Token: 0x02000862 RID: 2146
	[Protocol]
	public class WorldGuildInviteNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x060064E4 RID: 25828 RVA: 0x0012C593 File Offset: 0x0012A993
		public uint GetMsgID()
		{
			return 601957U;
		}

		// Token: 0x060064E5 RID: 25829 RVA: 0x0012C59A File Offset: 0x0012A99A
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060064E6 RID: 25830 RVA: 0x0012C5A2 File Offset: 0x0012A9A2
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060064E7 RID: 25831 RVA: 0x0012C5AC File Offset: 0x0012A9AC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.inviterId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.inviterName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.inviterOccu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.inviterLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.inviterVipLevel);
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildId);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.guildName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x060064E8 RID: 25832 RVA: 0x0012C644 File Offset: 0x0012AA44
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.inviterId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.inviterName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.inviterOccu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.inviterLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.inviterVipLevel);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildId);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.guildName = StringHelper.BytesToString(array2);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x060064E9 RID: 25833 RVA: 0x0012C72C File Offset: 0x0012AB2C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.inviterId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.inviterName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.inviterOccu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.inviterLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.inviterVipLevel);
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildId);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.guildName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x060064EA RID: 25834 RVA: 0x0012C7CC File Offset: 0x0012ABCC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.inviterId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.inviterName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.inviterOccu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.inviterLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.inviterVipLevel);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildId);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.guildName = StringHelper.BytesToString(array2);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x060064EB RID: 25835 RVA: 0x0012C8B4 File Offset: 0x0012ACB4
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.inviterName);
			num += 2 + array.Length;
			num++;
			num += 2;
			num++;
			num += 8;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.guildName);
			num += 2 + array2.Length;
			return num + this.playerLabelInfo.getLen();
		}

		// Token: 0x04002D2F RID: 11567
		public const uint MsgID = 601957U;

		// Token: 0x04002D30 RID: 11568
		public uint Sequence;

		// Token: 0x04002D31 RID: 11569
		public ulong inviterId;

		// Token: 0x04002D32 RID: 11570
		public string inviterName;

		// Token: 0x04002D33 RID: 11571
		public byte inviterOccu;

		// Token: 0x04002D34 RID: 11572
		public ushort inviterLevel;

		// Token: 0x04002D35 RID: 11573
		public byte inviterVipLevel;

		// Token: 0x04002D36 RID: 11574
		public ulong guildId;

		// Token: 0x04002D37 RID: 11575
		public string guildName;

		// Token: 0x04002D38 RID: 11576
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();
	}
}
