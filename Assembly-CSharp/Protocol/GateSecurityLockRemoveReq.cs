using System;

namespace Protocol
{
	// Token: 0x02000B2D RID: 2861
	[Protocol]
	public class GateSecurityLockRemoveReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A89 RID: 31369 RVA: 0x0015FBA8 File Offset: 0x0015DFA8
		public uint GetMsgID()
		{
			return 308401U;
		}

		// Token: 0x06007A8A RID: 31370 RVA: 0x0015FBAF File Offset: 0x0015DFAF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A8B RID: 31371 RVA: 0x0015FBB7 File Offset: 0x0015DFB7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A8C RID: 31372 RVA: 0x0015FBC0 File Offset: 0x0015DFC0
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.passwd);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007A8D RID: 31373 RVA: 0x0015FBEC File Offset: 0x0015DFEC
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.passwd = StringHelper.BytesToString(array);
		}

		// Token: 0x06007A8E RID: 31374 RVA: 0x0015FC3C File Offset: 0x0015E03C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.passwd);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007A8F RID: 31375 RVA: 0x0015FC68 File Offset: 0x0015E068
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.passwd = StringHelper.BytesToString(array);
		}

		// Token: 0x06007A90 RID: 31376 RVA: 0x0015FCB8 File Offset: 0x0015E0B8
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.passwd);
			return num + (2 + array.Length);
		}

		// Token: 0x040039D7 RID: 14807
		public const uint MsgID = 308401U;

		// Token: 0x040039D8 RID: 14808
		public uint Sequence;

		// Token: 0x040039D9 RID: 14809
		public string passwd;
	}
}
