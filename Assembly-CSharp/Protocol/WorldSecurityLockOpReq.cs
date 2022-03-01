using System;

namespace Protocol
{
	// Token: 0x02000B25 RID: 2853
	[Protocol]
	public class WorldSecurityLockOpReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A41 RID: 31297 RVA: 0x0015F1C4 File Offset: 0x0015D5C4
		public uint GetMsgID()
		{
			return 608404U;
		}

		// Token: 0x06007A42 RID: 31298 RVA: 0x0015F1CB File Offset: 0x0015D5CB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A43 RID: 31299 RVA: 0x0015F1D3 File Offset: 0x0015D5D3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A44 RID: 31300 RVA: 0x0015F1DC File Offset: 0x0015D5DC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lockOpType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.passwd);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007A45 RID: 31301 RVA: 0x0015F214 File Offset: 0x0015D614
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lockOpType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.passwd = StringHelper.BytesToString(array);
		}

		// Token: 0x06007A46 RID: 31302 RVA: 0x0015F270 File Offset: 0x0015D670
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lockOpType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.passwd);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007A47 RID: 31303 RVA: 0x0015F2AC File Offset: 0x0015D6AC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lockOpType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.passwd = StringHelper.BytesToString(array);
		}

		// Token: 0x06007A48 RID: 31304 RVA: 0x0015F308 File Offset: 0x0015D708
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.passwd);
			return num + (2 + array.Length);
		}

		// Token: 0x040039B5 RID: 14773
		public const uint MsgID = 608404U;

		// Token: 0x040039B6 RID: 14774
		public uint Sequence;

		// Token: 0x040039B7 RID: 14775
		public uint lockOpType;

		// Token: 0x040039B8 RID: 14776
		public string passwd;
	}
}
