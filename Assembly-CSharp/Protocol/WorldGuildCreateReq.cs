using System;

namespace Protocol
{
	// Token: 0x02000829 RID: 2089
	[Protocol]
	public class WorldGuildCreateReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060062E3 RID: 25315 RVA: 0x00129A75 File Offset: 0x00127E75
		public uint GetMsgID()
		{
			return 601901U;
		}

		// Token: 0x060062E4 RID: 25316 RVA: 0x00129A7C File Offset: 0x00127E7C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060062E5 RID: 25317 RVA: 0x00129A84 File Offset: 0x00127E84
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060062E6 RID: 25318 RVA: 0x00129A90 File Offset: 0x00127E90
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060062E7 RID: 25319 RVA: 0x00129AD8 File Offset: 0x00127ED8
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.declaration = StringHelper.BytesToString(array2);
		}

		// Token: 0x060062E8 RID: 25320 RVA: 0x00129B70 File Offset: 0x00127F70
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060062E9 RID: 25321 RVA: 0x00129BBC File Offset: 0x00127FBC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.declaration = StringHelper.BytesToString(array2);
		}

		// Token: 0x060062EA RID: 25322 RVA: 0x00129C54 File Offset: 0x00128054
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.declaration);
			return num + (2 + array2.Length);
		}

		// Token: 0x04002C73 RID: 11379
		public const uint MsgID = 601901U;

		// Token: 0x04002C74 RID: 11380
		public uint Sequence;

		// Token: 0x04002C75 RID: 11381
		public string name;

		// Token: 0x04002C76 RID: 11382
		public string declaration;
	}
}
