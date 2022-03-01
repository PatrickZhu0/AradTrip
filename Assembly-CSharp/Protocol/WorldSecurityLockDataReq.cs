using System;

namespace Protocol
{
	// Token: 0x02000B23 RID: 2851
	[Protocol]
	public class WorldSecurityLockDataReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A2F RID: 31279 RVA: 0x0015EEF4 File Offset: 0x0015D2F4
		public uint GetMsgID()
		{
			return 608402U;
		}

		// Token: 0x06007A30 RID: 31280 RVA: 0x0015EEFB File Offset: 0x0015D2FB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A31 RID: 31281 RVA: 0x0015EF03 File Offset: 0x0015D303
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A32 RID: 31282 RVA: 0x0015EF0C File Offset: 0x0015D30C
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.deviceID);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007A33 RID: 31283 RVA: 0x0015EF38 File Offset: 0x0015D338
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.deviceID = StringHelper.BytesToString(array);
		}

		// Token: 0x06007A34 RID: 31284 RVA: 0x0015EF88 File Offset: 0x0015D388
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.deviceID);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007A35 RID: 31285 RVA: 0x0015EFB4 File Offset: 0x0015D3B4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.deviceID = StringHelper.BytesToString(array);
		}

		// Token: 0x06007A36 RID: 31286 RVA: 0x0015F004 File Offset: 0x0015D404
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.deviceID);
			return num + (2 + array.Length);
		}

		// Token: 0x040039AB RID: 14763
		public const uint MsgID = 608402U;

		// Token: 0x040039AC RID: 14764
		public uint Sequence;

		// Token: 0x040039AD RID: 14765
		public string deviceID;
	}
}
