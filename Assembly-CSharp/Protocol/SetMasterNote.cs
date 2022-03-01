using System;

namespace Protocol
{
	// Token: 0x02000C98 RID: 3224
	[Protocol]
	public class SetMasterNote : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600850F RID: 34063 RVA: 0x0017563D File Offset: 0x00173A3D
		public uint GetMsgID()
		{
			return 601716U;
		}

		// Token: 0x06008510 RID: 34064 RVA: 0x00175644 File Offset: 0x00173A44
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008511 RID: 34065 RVA: 0x0017564C File Offset: 0x00173A4C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008512 RID: 34066 RVA: 0x00175658 File Offset: 0x00173A58
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.note);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06008513 RID: 34067 RVA: 0x00175684 File Offset: 0x00173A84
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.note = StringHelper.BytesToString(array);
		}

		// Token: 0x06008514 RID: 34068 RVA: 0x001756D4 File Offset: 0x00173AD4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.note);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06008515 RID: 34069 RVA: 0x00175700 File Offset: 0x00173B00
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.note = StringHelper.BytesToString(array);
		}

		// Token: 0x06008516 RID: 34070 RVA: 0x00175750 File Offset: 0x00173B50
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.note);
			return num + (2 + array.Length);
		}

		// Token: 0x04003FC5 RID: 16325
		public const uint MsgID = 601716U;

		// Token: 0x04003FC6 RID: 16326
		public uint Sequence;

		// Token: 0x04003FC7 RID: 16327
		public string note;
	}
}
