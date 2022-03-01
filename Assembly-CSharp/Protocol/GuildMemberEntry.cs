using System;

namespace Protocol
{
	// Token: 0x02000818 RID: 2072
	public class GuildMemberEntry : IProtocolStream
	{
		// Token: 0x0600627D RID: 25213 RVA: 0x00126760 File Offset: 0x00124B60
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_int8(buffer, ref pos_, this.post);
			BaseDLL.encode_uint32(buffer, ref pos_, this.contribution);
			BaseDLL.encode_uint32(buffer, ref pos_, this.logoutTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.activeDegree);
			BaseDLL.encode_int8(buffer, ref pos_, this.vipLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x0600627E RID: 25214 RVA: 0x00126814 File Offset: 0x00124C14
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.post);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.contribution);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.logoutTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.activeDegree);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.vipLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x0600627F RID: 25215 RVA: 0x001268EC File Offset: 0x00124CEC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_int8(buffer, ref pos_, this.post);
			BaseDLL.encode_uint32(buffer, ref pos_, this.contribution);
			BaseDLL.encode_uint32(buffer, ref pos_, this.logoutTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.activeDegree);
			BaseDLL.encode_int8(buffer, ref pos_, this.vipLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06006280 RID: 25216 RVA: 0x001269A4 File Offset: 0x00124DA4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.post);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.contribution);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.logoutTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.activeDegree);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.vipLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06006281 RID: 25217 RVA: 0x00126A7C File Offset: 0x00124E7C
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num += 2;
			num++;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num += 4;
			return num + this.playerLabelInfo.getLen();
		}

		// Token: 0x04002C01 RID: 11265
		public ulong id;

		// Token: 0x04002C02 RID: 11266
		public string name;

		// Token: 0x04002C03 RID: 11267
		public ushort level;

		// Token: 0x04002C04 RID: 11268
		public byte occu;

		// Token: 0x04002C05 RID: 11269
		public byte post;

		// Token: 0x04002C06 RID: 11270
		public uint contribution;

		// Token: 0x04002C07 RID: 11271
		public uint logoutTime;

		// Token: 0x04002C08 RID: 11272
		public uint activeDegree;

		// Token: 0x04002C09 RID: 11273
		public byte vipLevel;

		// Token: 0x04002C0A RID: 11274
		public uint seasonLevel;

		// Token: 0x04002C0B RID: 11275
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();
	}
}
