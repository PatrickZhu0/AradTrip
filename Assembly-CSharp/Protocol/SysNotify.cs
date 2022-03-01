using System;

namespace Protocol
{
	// Token: 0x0200077D RID: 1917
	[Protocol]
	public class SysNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E63 RID: 24163 RVA: 0x0011AED8 File Offset: 0x001192D8
		public uint GetMsgID()
		{
			return 11U;
		}

		// Token: 0x06005E64 RID: 24164 RVA: 0x0011AEDC File Offset: 0x001192DC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E65 RID: 24165 RVA: 0x0011AEE4 File Offset: 0x001192E4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E66 RID: 24166 RVA: 0x0011AEF0 File Offset: 0x001192F0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.type);
			byte[] str = StringHelper.StringToUTF8Bytes(this.word);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005E67 RID: 24167 RVA: 0x0011AF28 File Offset: 0x00119328
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.word = StringHelper.BytesToString(array);
		}

		// Token: 0x06005E68 RID: 24168 RVA: 0x0011AF84 File Offset: 0x00119384
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.type);
			byte[] str = StringHelper.StringToUTF8Bytes(this.word);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005E69 RID: 24169 RVA: 0x0011AFC0 File Offset: 0x001193C0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.word = StringHelper.BytesToString(array);
		}

		// Token: 0x06005E6A RID: 24170 RVA: 0x0011B01C File Offset: 0x0011941C
		public int getLen()
		{
			int num = 0;
			num += 2;
			byte[] array = StringHelper.StringToUTF8Bytes(this.word);
			return num + (2 + array.Length);
		}

		// Token: 0x040026C5 RID: 9925
		public const uint MsgID = 11U;

		// Token: 0x040026C6 RID: 9926
		public uint Sequence;

		// Token: 0x040026C7 RID: 9927
		public ushort type;

		// Token: 0x040026C8 RID: 9928
		public string word;
	}
}
