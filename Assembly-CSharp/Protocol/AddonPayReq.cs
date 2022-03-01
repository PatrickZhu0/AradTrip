using System;

namespace Protocol
{
	// Token: 0x02000C9F RID: 3231
	[Protocol]
	public class AddonPayReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600854E RID: 34126 RVA: 0x00175D7F File Offset: 0x0017417F
		public uint GetMsgID()
		{
			return 601722U;
		}

		// Token: 0x0600854F RID: 34127 RVA: 0x00175D86 File Offset: 0x00174186
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008550 RID: 34128 RVA: 0x00175D8E File Offset: 0x0017418E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008551 RID: 34129 RVA: 0x00175D98 File Offset: 0x00174198
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.goodId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.tarId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.tarName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.tarOccu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.tarLevel);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.words);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06008552 RID: 34130 RVA: 0x00175E18 File Offset: 0x00174218
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goodId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.tarId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.tarName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.tarOccu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.tarLevel);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.words = StringHelper.BytesToString(array2);
		}

		// Token: 0x06008553 RID: 34131 RVA: 0x00175EE8 File Offset: 0x001742E8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.goodId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.tarId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.tarName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.tarOccu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.tarLevel);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.words);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06008554 RID: 34132 RVA: 0x00175F6C File Offset: 0x0017436C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goodId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.tarId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.tarName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.tarOccu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.tarLevel);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.words = StringHelper.BytesToString(array2);
		}

		// Token: 0x06008555 RID: 34133 RVA: 0x0017603C File Offset: 0x0017443C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.tarName);
			num += 2 + array.Length;
			num++;
			num += 4;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.words);
			return num + (2 + array2.Length);
		}

		// Token: 0x04003FDD RID: 16349
		public const uint MsgID = 601722U;

		// Token: 0x04003FDE RID: 16350
		public uint Sequence;

		// Token: 0x04003FDF RID: 16351
		public uint goodId;

		// Token: 0x04003FE0 RID: 16352
		public ulong tarId;

		// Token: 0x04003FE1 RID: 16353
		public string tarName;

		// Token: 0x04003FE2 RID: 16354
		public byte tarOccu;

		// Token: 0x04003FE3 RID: 16355
		public uint tarLevel;

		// Token: 0x04003FE4 RID: 16356
		public string words;
	}
}
