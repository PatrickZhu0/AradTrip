using System;

namespace Protocol
{
	// Token: 0x02000BC6 RID: 3014
	[Protocol]
	public class TeamCopyStartBattleRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007EA3 RID: 32419 RVA: 0x001678E5 File Offset: 0x00165CE5
		public uint GetMsgID()
		{
			return 1100014U;
		}

		// Token: 0x06007EA4 RID: 32420 RVA: 0x001678EC File Offset: 0x00165CEC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007EA5 RID: 32421 RVA: 0x001678F4 File Offset: 0x00165CF4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007EA6 RID: 32422 RVA: 0x00167900 File Offset: 0x00165D00
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.roleName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007EA7 RID: 32423 RVA: 0x00167938 File Offset: 0x00165D38
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.roleName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007EA8 RID: 32424 RVA: 0x00167994 File Offset: 0x00165D94
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.roleName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007EA9 RID: 32425 RVA: 0x001679D0 File Offset: 0x00165DD0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.roleName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007EAA RID: 32426 RVA: 0x00167A2C File Offset: 0x00165E2C
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.roleName);
			num += 2 + array.Length;
			return num + 4;
		}

		// Token: 0x04003C77 RID: 15479
		public const uint MsgID = 1100014U;

		// Token: 0x04003C78 RID: 15480
		public uint Sequence;

		// Token: 0x04003C79 RID: 15481
		public string roleName;

		// Token: 0x04003C7A RID: 15482
		public uint retCode;
	}
}
