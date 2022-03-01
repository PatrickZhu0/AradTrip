using System;

namespace Protocol
{
	// Token: 0x02000840 RID: 2112
	[Protocol]
	public class WorldGuildSendMail : IProtocolStream, IGetMsgID
	{
		// Token: 0x060063B2 RID: 25522 RVA: 0x0012AE34 File Offset: 0x00129234
		public uint GetMsgID()
		{
			return 601924U;
		}

		// Token: 0x060063B3 RID: 25523 RVA: 0x0012AE3B File Offset: 0x0012923B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060063B4 RID: 25524 RVA: 0x0012AE43 File Offset: 0x00129243
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060063B5 RID: 25525 RVA: 0x0012AE4C File Offset: 0x0012924C
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.content);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060063B6 RID: 25526 RVA: 0x0012AE78 File Offset: 0x00129278
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

		// Token: 0x060063B7 RID: 25527 RVA: 0x0012AEC8 File Offset: 0x001292C8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.content);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060063B8 RID: 25528 RVA: 0x0012AEF4 File Offset: 0x001292F4
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

		// Token: 0x060063B9 RID: 25529 RVA: 0x0012AF44 File Offset: 0x00129344
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.content);
			return num + (2 + array.Length);
		}

		// Token: 0x04002CBF RID: 11455
		public const uint MsgID = 601924U;

		// Token: 0x04002CC0 RID: 11456
		public uint Sequence;

		// Token: 0x04002CC1 RID: 11457
		public string content;
	}
}
