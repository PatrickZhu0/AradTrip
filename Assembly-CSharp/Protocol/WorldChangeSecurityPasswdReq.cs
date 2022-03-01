using System;

namespace Protocol
{
	// Token: 0x02000B27 RID: 2855
	[Protocol]
	public class WorldChangeSecurityPasswdReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A53 RID: 31315 RVA: 0x0015F4CC File Offset: 0x0015D8CC
		public uint GetMsgID()
		{
			return 608406U;
		}

		// Token: 0x06007A54 RID: 31316 RVA: 0x0015F4D3 File Offset: 0x0015D8D3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A55 RID: 31317 RVA: 0x0015F4DB File Offset: 0x0015D8DB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A56 RID: 31318 RVA: 0x0015F4E4 File Offset: 0x0015D8E4
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.oldPasswd);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.newPasswd);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007A57 RID: 31319 RVA: 0x0015F52C File Offset: 0x0015D92C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.oldPasswd = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.newPasswd = StringHelper.BytesToString(array2);
		}

		// Token: 0x06007A58 RID: 31320 RVA: 0x0015F5C4 File Offset: 0x0015D9C4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.oldPasswd);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.newPasswd);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007A59 RID: 31321 RVA: 0x0015F610 File Offset: 0x0015DA10
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.oldPasswd = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.newPasswd = StringHelper.BytesToString(array2);
		}

		// Token: 0x06007A5A RID: 31322 RVA: 0x0015F6A8 File Offset: 0x0015DAA8
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.oldPasswd);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.newPasswd);
			return num + (2 + array2.Length);
		}

		// Token: 0x040039C0 RID: 14784
		public const uint MsgID = 608406U;

		// Token: 0x040039C1 RID: 14785
		public uint Sequence;

		// Token: 0x040039C2 RID: 14786
		public string oldPasswd;

		// Token: 0x040039C3 RID: 14787
		public string newPasswd;
	}
}
