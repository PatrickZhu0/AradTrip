using System;

namespace Protocol
{
	// Token: 0x02000C89 RID: 3209
	[Protocol]
	public class WorldQueryPlayerReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008497 RID: 33943 RVA: 0x00173A68 File Offset: 0x00171E68
		public uint GetMsgID()
		{
			return 601701U;
		}

		// Token: 0x06008498 RID: 33944 RVA: 0x00173A6F File Offset: 0x00171E6F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008499 RID: 33945 RVA: 0x00173A77 File Offset: 0x00171E77
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600849A RID: 33946 RVA: 0x00173A80 File Offset: 0x00171E80
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.queryType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600849B RID: 33947 RVA: 0x00173AD4 File Offset: 0x00171ED4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.queryType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
		}

		// Token: 0x0600849C RID: 33948 RVA: 0x00173B4C File Offset: 0x00171F4C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.queryType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600849D RID: 33949 RVA: 0x00173BA4 File Offset: 0x00171FA4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.queryType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
		}

		// Token: 0x0600849E RID: 33950 RVA: 0x00173C1C File Offset: 0x0017201C
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			return num + (2 + array.Length);
		}

		// Token: 0x04003F77 RID: 16247
		public const uint MsgID = 601701U;

		// Token: 0x04003F78 RID: 16248
		public uint Sequence;

		// Token: 0x04003F79 RID: 16249
		public ulong roleId;

		// Token: 0x04003F7A RID: 16250
		public uint queryType;

		// Token: 0x04003F7B RID: 16251
		public uint zoneId;

		// Token: 0x04003F7C RID: 16252
		public string name;
	}
}
