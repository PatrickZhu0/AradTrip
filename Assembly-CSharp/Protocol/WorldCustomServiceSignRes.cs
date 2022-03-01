using System;

namespace Protocol
{
	// Token: 0x02000787 RID: 1927
	[Protocol]
	public class WorldCustomServiceSignRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005EBA RID: 24250 RVA: 0x0011C0F0 File Offset: 0x0011A4F0
		public uint GetMsgID()
		{
			return 600817U;
		}

		// Token: 0x06005EBB RID: 24251 RVA: 0x0011C0F7 File Offset: 0x0011A4F7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005EBC RID: 24252 RVA: 0x0011C0FF File Offset: 0x0011A4FF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005EBD RID: 24253 RVA: 0x0011C108 File Offset: 0x0011A508
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			byte[] str = StringHelper.StringToUTF8Bytes(this.sign);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005EBE RID: 24254 RVA: 0x0011C140 File Offset: 0x0011A540
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.sign = StringHelper.BytesToString(array);
		}

		// Token: 0x06005EBF RID: 24255 RVA: 0x0011C19C File Offset: 0x0011A59C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			byte[] str = StringHelper.StringToUTF8Bytes(this.sign);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005EC0 RID: 24256 RVA: 0x0011C1D8 File Offset: 0x0011A5D8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.sign = StringHelper.BytesToString(array);
		}

		// Token: 0x06005EC1 RID: 24257 RVA: 0x0011C234 File Offset: 0x0011A634
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.sign);
			return num + (2 + array.Length);
		}

		// Token: 0x040026FF RID: 9983
		public const uint MsgID = 600817U;

		// Token: 0x04002700 RID: 9984
		public uint Sequence;

		// Token: 0x04002701 RID: 9985
		public uint result;

		// Token: 0x04002702 RID: 9986
		public string sign;
	}
}
