using System;

namespace Protocol
{
	// Token: 0x02000786 RID: 1926
	[Protocol]
	public class WorldCustomServiceSignReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005EB1 RID: 24241 RVA: 0x0011BFB2 File Offset: 0x0011A3B2
		public uint GetMsgID()
		{
			return 600816U;
		}

		// Token: 0x06005EB2 RID: 24242 RVA: 0x0011BFB9 File Offset: 0x0011A3B9
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005EB3 RID: 24243 RVA: 0x0011BFC1 File Offset: 0x0011A3C1
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005EB4 RID: 24244 RVA: 0x0011BFCC File Offset: 0x0011A3CC
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.info);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005EB5 RID: 24245 RVA: 0x0011BFF8 File Offset: 0x0011A3F8
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.info = StringHelper.BytesToString(array);
		}

		// Token: 0x06005EB6 RID: 24246 RVA: 0x0011C048 File Offset: 0x0011A448
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.info);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005EB7 RID: 24247 RVA: 0x0011C074 File Offset: 0x0011A474
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.info = StringHelper.BytesToString(array);
		}

		// Token: 0x06005EB8 RID: 24248 RVA: 0x0011C0C4 File Offset: 0x0011A4C4
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.info);
			return num + (2 + array.Length);
		}

		// Token: 0x040026FC RID: 9980
		public const uint MsgID = 600816U;

		// Token: 0x040026FD RID: 9981
		public uint Sequence;

		// Token: 0x040026FE RID: 9982
		public string info;
	}
}
