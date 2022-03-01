using System;

namespace Protocol
{
	// Token: 0x02000867 RID: 2151
	[Protocol]
	public class WorldGuildChallengeInfoSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006511 RID: 25873 RVA: 0x0012CD1B File Offset: 0x0012B11B
		public uint GetMsgID()
		{
			return 601962U;
		}

		// Token: 0x06006512 RID: 25874 RVA: 0x0012CD22 File Offset: 0x0012B122
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006513 RID: 25875 RVA: 0x0012CD2A File Offset: 0x0012B12A
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006514 RID: 25876 RVA: 0x0012CD34 File Offset: 0x0012B134
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
			BaseDLL.encode_uint64(buffer, ref pos_, this.enrollGuildId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.enrollGuildName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.enrollGuildleaderName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.enrollGuildLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
		}

		// Token: 0x06006515 RID: 25877 RVA: 0x0012CDC0 File Offset: 0x0012B1C0
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.enrollGuildId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.enrollGuildName = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.enrollGuildleaderName = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enrollGuildLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
		}

		// Token: 0x06006516 RID: 25878 RVA: 0x0012CE9C File Offset: 0x0012B29C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
			BaseDLL.encode_uint64(buffer, ref pos_, this.enrollGuildId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.enrollGuildName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.enrollGuildleaderName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.enrollGuildLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
		}

		// Token: 0x06006517 RID: 25879 RVA: 0x0012CF2C File Offset: 0x0012B32C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.enrollGuildId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.enrollGuildName = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.enrollGuildleaderName = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enrollGuildLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
		}

		// Token: 0x06006518 RID: 25880 RVA: 0x0012D008 File Offset: 0x0012B408
		public int getLen()
		{
			int num = 0;
			num += this.info.getLen();
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.enrollGuildName);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.enrollGuildleaderName);
			num += 2 + array2.Length;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002D49 RID: 11593
		public const uint MsgID = 601962U;

		// Token: 0x04002D4A RID: 11594
		public uint Sequence;

		// Token: 0x04002D4B RID: 11595
		public GuildTerritoryBaseInfo info = new GuildTerritoryBaseInfo();

		// Token: 0x04002D4C RID: 11596
		public ulong enrollGuildId;

		// Token: 0x04002D4D RID: 11597
		public string enrollGuildName;

		// Token: 0x04002D4E RID: 11598
		public string enrollGuildleaderName;

		// Token: 0x04002D4F RID: 11599
		public byte enrollGuildLevel;

		// Token: 0x04002D50 RID: 11600
		public uint itemId;

		// Token: 0x04002D51 RID: 11601
		public uint itemNum;
	}
}
