using System;

namespace Protocol
{
	// Token: 0x020006F0 RID: 1776
	public class PlayerIcon : IProtocolStream
	{
		// Token: 0x060059F2 RID: 23026 RVA: 0x00111BB4 File Offset: 0x0010FFB4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x060059F3 RID: 23027 RVA: 0x00111C14 File Offset: 0x00110014
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
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x060059F4 RID: 23028 RVA: 0x00111C98 File Offset: 0x00110098
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x060059F5 RID: 23029 RVA: 0x00111CFC File Offset: 0x001100FC
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
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x060059F6 RID: 23030 RVA: 0x00111D80 File Offset: 0x00110180
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num += 2;
			return num + this.playerLabelInfo.getLen();
		}

		// Token: 0x04002473 RID: 9331
		public ulong id;

		// Token: 0x04002474 RID: 9332
		public string name;

		// Token: 0x04002475 RID: 9333
		public byte occu;

		// Token: 0x04002476 RID: 9334
		public ushort level;

		// Token: 0x04002477 RID: 9335
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();
	}
}
