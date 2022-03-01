using System;

namespace Protocol
{
	// Token: 0x0200083D RID: 2109
	[Protocol]
	public class WorldGuildModifyDeclaration : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006397 RID: 25495 RVA: 0x0012AA05 File Offset: 0x00128E05
		public uint GetMsgID()
		{
			return 601921U;
		}

		// Token: 0x06006398 RID: 25496 RVA: 0x0012AA0C File Offset: 0x00128E0C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006399 RID: 25497 RVA: 0x0012AA14 File Offset: 0x00128E14
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600639A RID: 25498 RVA: 0x0012AA20 File Offset: 0x00128E20
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600639B RID: 25499 RVA: 0x0012AA4C File Offset: 0x00128E4C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.declaration = StringHelper.BytesToString(array);
		}

		// Token: 0x0600639C RID: 25500 RVA: 0x0012AA9C File Offset: 0x00128E9C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600639D RID: 25501 RVA: 0x0012AAC8 File Offset: 0x00128EC8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.declaration = StringHelper.BytesToString(array);
		}

		// Token: 0x0600639E RID: 25502 RVA: 0x0012AB18 File Offset: 0x00128F18
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.declaration);
			return num + (2 + array.Length);
		}

		// Token: 0x04002CB4 RID: 11444
		public const uint MsgID = 601921U;

		// Token: 0x04002CB5 RID: 11445
		public uint Sequence;

		// Token: 0x04002CB6 RID: 11446
		public string declaration;
	}
}
