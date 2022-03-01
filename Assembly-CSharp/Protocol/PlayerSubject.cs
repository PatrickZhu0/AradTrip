using System;

namespace Protocol
{
	// Token: 0x020006FE RID: 1790
	public class PlayerSubject : IProtocolStream
	{
		// Token: 0x06005A6A RID: 23146 RVA: 0x001130C8 File Offset: 0x001114C8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.accId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
		}

		// Token: 0x06005A6B RID: 23147 RVA: 0x0011311C File Offset: 0x0011151C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
		}

		// Token: 0x06005A6C RID: 23148 RVA: 0x00113194 File Offset: 0x00111594
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.accId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
		}

		// Token: 0x06005A6D RID: 23149 RVA: 0x001131EC File Offset: 0x001115EC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
		}

		// Token: 0x06005A6E RID: 23150 RVA: 0x00113264 File Offset: 0x00111664
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.playerName);
			num += 2 + array.Length;
			return num + 1;
		}

		// Token: 0x040024BC RID: 9404
		public uint accId;

		// Token: 0x040024BD RID: 9405
		public ulong playerId;

		// Token: 0x040024BE RID: 9406
		public string playerName;

		// Token: 0x040024BF RID: 9407
		public byte occu;
	}
}
