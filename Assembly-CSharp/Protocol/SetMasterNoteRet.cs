using System;

namespace Protocol
{
	// Token: 0x02000C99 RID: 3225
	[Protocol]
	public class SetMasterNoteRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008518 RID: 34072 RVA: 0x0017577C File Offset: 0x00173B7C
		public uint GetMsgID()
		{
			return 601717U;
		}

		// Token: 0x06008519 RID: 34073 RVA: 0x00175783 File Offset: 0x00173B83
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600851A RID: 34074 RVA: 0x0017578B File Offset: 0x00173B8B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600851B RID: 34075 RVA: 0x00175794 File Offset: 0x00173B94
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			byte[] str = StringHelper.StringToUTF8Bytes(this.note);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600851C RID: 34076 RVA: 0x001757CC File Offset: 0x00173BCC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.note = StringHelper.BytesToString(array);
		}

		// Token: 0x0600851D RID: 34077 RVA: 0x00175828 File Offset: 0x00173C28
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			byte[] str = StringHelper.StringToUTF8Bytes(this.note);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600851E RID: 34078 RVA: 0x00175864 File Offset: 0x00173C64
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.note = StringHelper.BytesToString(array);
		}

		// Token: 0x0600851F RID: 34079 RVA: 0x001758C0 File Offset: 0x00173CC0
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.note);
			return num + (2 + array.Length);
		}

		// Token: 0x04003FC8 RID: 16328
		public const uint MsgID = 601717U;

		// Token: 0x04003FC9 RID: 16329
		public uint Sequence;

		// Token: 0x04003FCA RID: 16330
		public uint code;

		// Token: 0x04003FCB RID: 16331
		public string note;
	}
}
