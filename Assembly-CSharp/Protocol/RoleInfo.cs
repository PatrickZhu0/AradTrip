using System;

namespace Protocol
{
	// Token: 0x020006EC RID: 1772
	public class RoleInfo : IProtocolStream
	{
		// Token: 0x060059D1 RID: 22993 RVA: 0x00110E4C File Offset: 0x0010F24C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.strRoleId);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.sex);
			BaseDLL.encode_int8(buffer, ref pos_, this.occupation);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.offlineTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.deleteTime);
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newboot);
			BaseDLL.encode_int8(buffer, ref pos_, this.preOccu);
			BaseDLL.encode_int8(buffer, ref pos_, this.isAppointmentOccu);
			BaseDLL.encode_int8(buffer, ref pos_, this.isVeteranReturn);
			this.playerLabelInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.addPreferencesTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.delPreferencesTime);
		}

		// Token: 0x060059D2 RID: 22994 RVA: 0x00110F54 File Offset: 0x0010F354
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.strRoleId = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.name = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.sex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occupation);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.offlineTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.deleteTime);
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newboot);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.preOccu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAppointmentOccu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isVeteranReturn);
			this.playerLabelInfo.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.addPreferencesTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.delPreferencesTime);
		}

		// Token: 0x060059D3 RID: 22995 RVA: 0x001110AC File Offset: 0x0010F4AC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.strRoleId);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.sex);
			BaseDLL.encode_int8(buffer, ref pos_, this.occupation);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.offlineTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.deleteTime);
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newboot);
			BaseDLL.encode_int8(buffer, ref pos_, this.preOccu);
			BaseDLL.encode_int8(buffer, ref pos_, this.isAppointmentOccu);
			BaseDLL.encode_int8(buffer, ref pos_, this.isVeteranReturn);
			this.playerLabelInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.addPreferencesTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.delPreferencesTime);
		}

		// Token: 0x060059D4 RID: 22996 RVA: 0x001111BC File Offset: 0x0010F5BC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.strRoleId = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.name = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.sex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occupation);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.offlineTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.deleteTime);
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newboot);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.preOccu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAppointmentOccu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isVeteranReturn);
			this.playerLabelInfo.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.addPreferencesTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.delPreferencesTime);
		}

		// Token: 0x060059D5 RID: 22997 RVA: 0x00111314 File Offset: 0x0010F714
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.strRoleId);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array2.Length;
			num++;
			num++;
			num += 2;
			num += 4;
			num += 4;
			num += this.avatar.getLen();
			num += 4;
			num++;
			num++;
			num++;
			num += this.playerLabelInfo.getLen();
			num += 4;
			return num + 4;
		}

		// Token: 0x0400244A RID: 9290
		public ulong roleId;

		// Token: 0x0400244B RID: 9291
		public string strRoleId;

		// Token: 0x0400244C RID: 9292
		public string name;

		// Token: 0x0400244D RID: 9293
		public byte sex;

		// Token: 0x0400244E RID: 9294
		public byte occupation;

		// Token: 0x0400244F RID: 9295
		public ushort level;

		// Token: 0x04002450 RID: 9296
		public uint offlineTime;

		// Token: 0x04002451 RID: 9297
		public uint deleteTime;

		// Token: 0x04002452 RID: 9298
		public PlayerAvatar avatar = new PlayerAvatar();

		// Token: 0x04002453 RID: 9299
		public uint newboot;

		// Token: 0x04002454 RID: 9300
		public byte preOccu;

		// Token: 0x04002455 RID: 9301
		public byte isAppointmentOccu;

		// Token: 0x04002456 RID: 9302
		public byte isVeteranReturn;

		// Token: 0x04002457 RID: 9303
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();

		// Token: 0x04002458 RID: 9304
		public uint addPreferencesTime;

		// Token: 0x04002459 RID: 9305
		public uint delPreferencesTime;
	}
}
