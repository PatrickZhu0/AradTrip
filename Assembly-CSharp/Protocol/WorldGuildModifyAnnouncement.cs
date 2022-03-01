using System;

namespace Protocol
{
	// Token: 0x0200083F RID: 2111
	[Protocol]
	public class WorldGuildModifyAnnouncement : IProtocolStream, IGetMsgID
	{
		// Token: 0x060063A9 RID: 25513 RVA: 0x0012ACF8 File Offset: 0x001290F8
		public uint GetMsgID()
		{
			return 601923U;
		}

		// Token: 0x060063AA RID: 25514 RVA: 0x0012ACFF File Offset: 0x001290FF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060063AB RID: 25515 RVA: 0x0012AD07 File Offset: 0x00129107
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060063AC RID: 25516 RVA: 0x0012AD10 File Offset: 0x00129110
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.content);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060063AD RID: 25517 RVA: 0x0012AD3C File Offset: 0x0012913C
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
		}

		// Token: 0x060063AE RID: 25518 RVA: 0x0012AD8C File Offset: 0x0012918C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.content);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060063AF RID: 25519 RVA: 0x0012ADB8 File Offset: 0x001291B8
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
		}

		// Token: 0x060063B0 RID: 25520 RVA: 0x0012AE08 File Offset: 0x00129208
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.content);
			return num + (2 + array.Length);
		}

		// Token: 0x04002CBC RID: 11452
		public const uint MsgID = 601923U;

		// Token: 0x04002CBD RID: 11453
		public uint Sequence;

		// Token: 0x04002CBE RID: 11454
		public string content;
	}
}
