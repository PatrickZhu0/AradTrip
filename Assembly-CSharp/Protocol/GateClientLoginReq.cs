using System;

namespace Protocol
{
	// Token: 0x020009BE RID: 2494
	[Protocol]
	public class GateClientLoginReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006FD0 RID: 28624 RVA: 0x00143CC1 File Offset: 0x001420C1
		public uint GetMsgID()
		{
			return 300203U;
		}

		// Token: 0x06006FD1 RID: 28625 RVA: 0x00143CC8 File Offset: 0x001420C8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006FD2 RID: 28626 RVA: 0x00143CD0 File Offset: 0x001420D0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006FD3 RID: 28627 RVA: 0x00143CD9 File Offset: 0x001420D9
		public string GetPassword()
		{
			return this.password;
		}

		// Token: 0x06006FD4 RID: 28628 RVA: 0x00143CE1 File Offset: 0x001420E1
		public void SetPassword(string strPass)
		{
			this.password = strPass;
		}

		// Token: 0x06006FD5 RID: 28629 RVA: 0x00143CEA File Offset: 0x001420EA
		public string GetPassword2()
		{
			return this.password2;
		}

		// Token: 0x06006FD6 RID: 28630 RVA: 0x00143CF2 File Offset: 0x001420F2
		public void SetPassword2(string strPass)
		{
			this.password2 = strPass;
		}

		// Token: 0x06006FD7 RID: 28631 RVA: 0x00143CFB File Offset: 0x001420FB
		public string GetCPS()
		{
			return this.cpsaccount;
		}

		// Token: 0x06006FD8 RID: 28632 RVA: 0x00143D03 File Offset: 0x00142103
		public void SetCPS(string strCPS)
		{
			this.cpsaccount = strCPS;
		}

		// Token: 0x06006FD9 RID: 28633 RVA: 0x00143D0C File Offset: 0x0014210C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			for (int i = 0; i < this.hashValue.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.hashValue[i]);
			}
			byte[] str = StringHelper.StringToUTF8Bytes(this.password);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.password2);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.cpsaccount);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06006FDA RID: 28634 RVA: 0x00143DA4 File Offset: 0x001421A4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			for (int i = 0; i < this.hashValue.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.hashValue[i]);
			}
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int j = 0; j < (int)num; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[j]);
			}
			this.password = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int k = 0; k < (int)num2; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[k]);
			}
			this.password2 = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int l = 0; l < (int)num3; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[l]);
			}
			this.cpsaccount = StringHelper.BytesToString(array3);
		}

		// Token: 0x06006FDB RID: 28635 RVA: 0x00143EC4 File Offset: 0x001422C4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			for (int i = 0; i < this.hashValue.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.hashValue[i]);
			}
			byte[] str = StringHelper.StringToUTF8Bytes(this.password);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.password2);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.cpsaccount);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06006FDC RID: 28636 RVA: 0x00143F68 File Offset: 0x00142368
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			for (int i = 0; i < this.hashValue.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.hashValue[i]);
			}
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int j = 0; j < (int)num; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[j]);
			}
			this.password = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int k = 0; k < (int)num2; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[k]);
			}
			this.password2 = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int l = 0; l < (int)num3; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[l]);
			}
			this.cpsaccount = StringHelper.BytesToString(array3);
		}

		// Token: 0x06006FDD RID: 28637 RVA: 0x00144088 File Offset: 0x00142488
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += this.hashValue.Length;
			byte[] array = StringHelper.StringToUTF8Bytes(this.password);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.password2);
			num += 2 + array2.Length;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.cpsaccount);
			return num + (2 + array3.Length);
		}

		// Token: 0x040032EC RID: 13036
		public const uint MsgID = 300203U;

		// Token: 0x040032ED RID: 13037
		public uint Sequence;

		// Token: 0x040032EE RID: 13038
		public uint accid;

		// Token: 0x040032EF RID: 13039
		public byte[] hashValue = new byte[20];

		// Token: 0x040032F0 RID: 13040
		public string password;

		// Token: 0x040032F1 RID: 13041
		public string password2;

		// Token: 0x040032F2 RID: 13042
		public string cpsaccount;
	}
}
