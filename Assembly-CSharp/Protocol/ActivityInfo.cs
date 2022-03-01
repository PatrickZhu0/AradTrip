using System;

namespace Protocol
{
	// Token: 0x0200066C RID: 1644
	public class ActivityInfo : IProtocolStream
	{
		// Token: 0x06005606 RID: 22022 RVA: 0x001078A0 File Offset: 0x00105CA0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dueTime);
		}

		// Token: 0x06005607 RID: 22023 RVA: 0x00107920 File Offset: 0x00105D20
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dueTime);
		}

		// Token: 0x06005608 RID: 22024 RVA: 0x001079C4 File Offset: 0x00105DC4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dueTime);
		}

		// Token: 0x06005609 RID: 22025 RVA: 0x00107A44 File Offset: 0x00105E44
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dueTime);
		}

		// Token: 0x0600560A RID: 22026 RVA: 0x00107AE8 File Offset: 0x00105EE8
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num += 2;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002218 RID: 8728
		public byte state;

		// Token: 0x04002219 RID: 8729
		public uint id;

		// Token: 0x0400221A RID: 8730
		public string name;

		// Token: 0x0400221B RID: 8731
		public ushort level;

		// Token: 0x0400221C RID: 8732
		public uint preTime;

		// Token: 0x0400221D RID: 8733
		public uint startTime;

		// Token: 0x0400221E RID: 8734
		public uint dueTime;
	}
}
