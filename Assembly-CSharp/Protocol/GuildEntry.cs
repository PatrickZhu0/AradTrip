using System;

namespace Protocol
{
	// Token: 0x02000817 RID: 2071
	public class GuildEntry : IProtocolStream
	{
		// Token: 0x06006277 RID: 25207 RVA: 0x00126290 File Offset: 0x00124690
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.memberNum);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.leaderName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.isRequested);
			BaseDLL.encode_int8(buffer, ref pos_, this.occupyCrossTerrId);
			BaseDLL.encode_int8(buffer, ref pos_, this.occupyTerrId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.joinLevel);
			BaseDLL.encode_uint64(buffer, ref pos_, this.leaderId);
		}

		// Token: 0x06006278 RID: 25208 RVA: 0x00126364 File Offset: 0x00124764
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
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.memberNum);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.leaderName = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.declaration = StringHelper.BytesToString(array3);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRequested);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occupyCrossTerrId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occupyTerrId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.joinLevel);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.leaderId);
		}

		// Token: 0x06006279 RID: 25209 RVA: 0x001264B4 File Offset: 0x001248B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.memberNum);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.leaderName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.isRequested);
			BaseDLL.encode_int8(buffer, ref pos_, this.occupyCrossTerrId);
			BaseDLL.encode_int8(buffer, ref pos_, this.occupyTerrId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.joinLevel);
			BaseDLL.encode_uint64(buffer, ref pos_, this.leaderId);
		}

		// Token: 0x0600627A RID: 25210 RVA: 0x00126590 File Offset: 0x00124990
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
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.memberNum);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.leaderName = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.declaration = StringHelper.BytesToString(array3);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRequested);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occupyCrossTerrId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occupyTerrId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.joinLevel);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.leaderId);
		}

		// Token: 0x0600627B RID: 25211 RVA: 0x001266E0 File Offset: 0x00124AE0
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num++;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.leaderName);
			num += 2 + array2.Length;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.declaration);
			num += 2 + array3.Length;
			num++;
			num++;
			num++;
			num += 4;
			return num + 8;
		}

		// Token: 0x04002BF6 RID: 11254
		public ulong id;

		// Token: 0x04002BF7 RID: 11255
		public string name;

		// Token: 0x04002BF8 RID: 11256
		public byte level;

		// Token: 0x04002BF9 RID: 11257
		public byte memberNum;

		// Token: 0x04002BFA RID: 11258
		public string leaderName;

		// Token: 0x04002BFB RID: 11259
		public string declaration;

		// Token: 0x04002BFC RID: 11260
		public byte isRequested;

		// Token: 0x04002BFD RID: 11261
		public byte occupyCrossTerrId;

		// Token: 0x04002BFE RID: 11262
		public byte occupyTerrId;

		// Token: 0x04002BFF RID: 11263
		public uint joinLevel;

		// Token: 0x04002C00 RID: 11264
		public ulong leaderId;
	}
}
