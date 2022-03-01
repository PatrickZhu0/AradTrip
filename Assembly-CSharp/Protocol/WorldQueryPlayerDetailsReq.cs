using System;

namespace Protocol
{
	// Token: 0x02000C8A RID: 3210
	[Protocol]
	public class WorldQueryPlayerDetailsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060084A0 RID: 33952 RVA: 0x00173C54 File Offset: 0x00172054
		public uint GetMsgID()
		{
			return 601726U;
		}

		// Token: 0x060084A1 RID: 33953 RVA: 0x00173C5B File Offset: 0x0017205B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060084A2 RID: 33954 RVA: 0x00173C63 File Offset: 0x00172063
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060084A3 RID: 33955 RVA: 0x00173C6C File Offset: 0x0017206C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.queryType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060084A4 RID: 33956 RVA: 0x00173CC0 File Offset: 0x001720C0
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

		// Token: 0x060084A5 RID: 33957 RVA: 0x00173D38 File Offset: 0x00172138
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.queryType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060084A6 RID: 33958 RVA: 0x00173D90 File Offset: 0x00172190
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

		// Token: 0x060084A7 RID: 33959 RVA: 0x00173E08 File Offset: 0x00172208
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			return num + (2 + array.Length);
		}

		// Token: 0x04003F7D RID: 16253
		public const uint MsgID = 601726U;

		// Token: 0x04003F7E RID: 16254
		public uint Sequence;

		// Token: 0x04003F7F RID: 16255
		public ulong roleId;

		// Token: 0x04003F80 RID: 16256
		public uint queryType;

		// Token: 0x04003F81 RID: 16257
		public uint zoneId;

		// Token: 0x04003F82 RID: 16258
		public string name;
	}
}
