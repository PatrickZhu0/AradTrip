using System;

namespace Protocol
{
	// Token: 0x020009D3 RID: 2515
	[Protocol]
	public class GateConvertAccountRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007093 RID: 28819 RVA: 0x00145794 File Offset: 0x00143B94
		public uint GetMsgID()
		{
			return 300323U;
		}

		// Token: 0x06007094 RID: 28820 RVA: 0x0014579B File Offset: 0x00143B9B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007095 RID: 28821 RVA: 0x001457A3 File Offset: 0x00143BA3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007096 RID: 28822 RVA: 0x001457AC File Offset: 0x00143BAC
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.account);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.passwd);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.saveFile);
			BaseDLL.encode_int8(buffer, ref pos_, this.screenShot);
		}

		// Token: 0x06007097 RID: 28823 RVA: 0x00145810 File Offset: 0x00143C10
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.account = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.passwd = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.saveFile);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.screenShot);
		}

		// Token: 0x06007098 RID: 28824 RVA: 0x001458C4 File Offset: 0x00143CC4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.account);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.passwd);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.saveFile);
			BaseDLL.encode_int8(buffer, ref pos_, this.screenShot);
		}

		// Token: 0x06007099 RID: 28825 RVA: 0x0014592C File Offset: 0x00143D2C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.account = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.passwd = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.saveFile);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.screenShot);
		}

		// Token: 0x0600709A RID: 28826 RVA: 0x001459E0 File Offset: 0x00143DE0
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.account);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.passwd);
			num += 2 + array2.Length;
			num++;
			return num + 1;
		}

		// Token: 0x04003345 RID: 13125
		public const uint MsgID = 300323U;

		// Token: 0x04003346 RID: 13126
		public uint Sequence;

		// Token: 0x04003347 RID: 13127
		public string account;

		// Token: 0x04003348 RID: 13128
		public string passwd;

		// Token: 0x04003349 RID: 13129
		public byte saveFile;

		// Token: 0x0400334A RID: 13130
		public byte screenShot;
	}
}
