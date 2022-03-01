using System;

namespace Protocol
{
	// Token: 0x020009BC RID: 2492
	[Protocol]
	public class AdminLoginVerifyReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006FBE RID: 28606 RVA: 0x00142A69 File Offset: 0x00140E69
		public uint GetMsgID()
		{
			return 200201U;
		}

		// Token: 0x06006FBF RID: 28607 RVA: 0x00142A70 File Offset: 0x00140E70
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006FC0 RID: 28608 RVA: 0x00142A78 File Offset: 0x00140E78
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006FC1 RID: 28609 RVA: 0x00142A84 File Offset: 0x00140E84
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.version);
			byte[] str = StringHelper.StringToUTF8Bytes(this.source1);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.append1);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.source2);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.append2);
			for (int i = 0; i < this.tableMd5.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.tableMd5[i]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.svnVersion);
			for (int j = 0; j < this.append3.Length; j++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.append3[j]);
			}
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.param);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			for (int k = 0; k < this.hashValue.Length; k++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.hashValue[k]);
			}
		}

		// Token: 0x06006FC2 RID: 28610 RVA: 0x00142BA0 File Offset: 0x00140FA0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.version);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.source1 = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.append1);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.source2 = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.append2);
			for (int k = 0; k < this.tableMd5.Length; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.tableMd5[k]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.svnVersion);
			for (int l = 0; l < this.append3.Length; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.append3[l]);
			}
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int m = 0; m < (int)num3; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[m]);
			}
			this.param = StringHelper.BytesToString(array3);
			for (int n = 0; n < this.hashValue.Length; n++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.hashValue[n]);
			}
		}

		// Token: 0x06006FC3 RID: 28611 RVA: 0x00142D50 File Offset: 0x00141150
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.version);
			byte[] str = StringHelper.StringToUTF8Bytes(this.source1);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.append1);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.source2);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.append2);
			for (int i = 0; i < this.tableMd5.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.tableMd5[i]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.svnVersion);
			for (int j = 0; j < this.append3.Length; j++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.append3[j]);
			}
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.param);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			for (int k = 0; k < this.hashValue.Length; k++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.hashValue[k]);
			}
		}

		// Token: 0x06006FC4 RID: 28612 RVA: 0x00142E74 File Offset: 0x00141274
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.version);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.source1 = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.append1);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.source2 = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.append2);
			for (int k = 0; k < this.tableMd5.Length; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.tableMd5[k]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.svnVersion);
			for (int l = 0; l < this.append3.Length; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.append3[l]);
			}
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int m = 0; m < (int)num3; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[m]);
			}
			this.param = StringHelper.BytesToString(array3);
			for (int n = 0; n < this.hashValue.Length; n++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.hashValue[n]);
			}
		}

		// Token: 0x06006FC5 RID: 28613 RVA: 0x00143024 File Offset: 0x00141424
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.source1);
			num += 2 + array.Length;
			num += 4;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.source2);
			num += 2 + array2.Length;
			num++;
			num += this.tableMd5.Length;
			num += 4;
			num += this.append3.Length;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.param);
			num += 2 + array3.Length;
			return num + this.hashValue.Length;
		}

		// Token: 0x040032C9 RID: 13001
		public const uint MsgID = 200201U;

		// Token: 0x040032CA RID: 13002
		public uint Sequence;

		// Token: 0x040032CB RID: 13003
		public uint version;

		// Token: 0x040032CC RID: 13004
		public string source1;

		// Token: 0x040032CD RID: 13005
		public uint append1;

		// Token: 0x040032CE RID: 13006
		public string source2;

		// Token: 0x040032CF RID: 13007
		public byte append2;

		// Token: 0x040032D0 RID: 13008
		public byte[] tableMd5 = new byte[16];

		// Token: 0x040032D1 RID: 13009
		public uint svnVersion;

		// Token: 0x040032D2 RID: 13010
		public byte[] append3 = new byte[12];

		// Token: 0x040032D3 RID: 13011
		public string param;

		// Token: 0x040032D4 RID: 13012
		public byte[] hashValue = new byte[20];
	}
}
