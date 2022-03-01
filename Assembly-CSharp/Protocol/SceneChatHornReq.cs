using System;

namespace Protocol
{
	// Token: 0x02000782 RID: 1922
	[Protocol]
	public class SceneChatHornReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E90 RID: 24208 RVA: 0x0011B928 File Offset: 0x00119D28
		public uint GetMsgID()
		{
			return 500808U;
		}

		// Token: 0x06005E91 RID: 24209 RVA: 0x0011B92F File Offset: 0x00119D2F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E92 RID: 24210 RVA: 0x0011B937 File Offset: 0x00119D37
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E93 RID: 24211 RVA: 0x0011B940 File Offset: 0x00119D40
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.content);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
		}

		// Token: 0x06005E94 RID: 24212 RVA: 0x0011B978 File Offset: 0x00119D78
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.content = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005E95 RID: 24213 RVA: 0x0011B9D4 File Offset: 0x00119DD4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.content);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
		}

		// Token: 0x06005E96 RID: 24214 RVA: 0x0011BA10 File Offset: 0x00119E10
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.content = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005E97 RID: 24215 RVA: 0x0011BA6C File Offset: 0x00119E6C
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.content);
			num += 2 + array.Length;
			return num + 1;
		}

		// Token: 0x040026E7 RID: 9959
		public const uint MsgID = 500808U;

		// Token: 0x040026E8 RID: 9960
		public uint Sequence;

		// Token: 0x040026E9 RID: 9961
		public string content;

		// Token: 0x040026EA RID: 9962
		public byte num;
	}
}
