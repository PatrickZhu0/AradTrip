using System;

namespace Protocol
{
	// Token: 0x02000697 RID: 1687
	[Protocol]
	public class WorldAdventureTeamRenameRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005762 RID: 22370 RVA: 0x0010ACA0 File Offset: 0x001090A0
		public uint GetMsgID()
		{
			return 608602U;
		}

		// Token: 0x06005763 RID: 22371 RVA: 0x0010ACA7 File Offset: 0x001090A7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005764 RID: 22372 RVA: 0x0010ACAF File Offset: 0x001090AF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005765 RID: 22373 RVA: 0x0010ACB8 File Offset: 0x001090B8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			byte[] str = StringHelper.StringToUTF8Bytes(this.newName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005766 RID: 22374 RVA: 0x0010ACF0 File Offset: 0x001090F0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.newName = StringHelper.BytesToString(array);
		}

		// Token: 0x06005767 RID: 22375 RVA: 0x0010AD4C File Offset: 0x0010914C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			byte[] str = StringHelper.StringToUTF8Bytes(this.newName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005768 RID: 22376 RVA: 0x0010AD88 File Offset: 0x00109188
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.newName = StringHelper.BytesToString(array);
		}

		// Token: 0x06005769 RID: 22377 RVA: 0x0010ADE4 File Offset: 0x001091E4
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.newName);
			return num + (2 + array.Length);
		}

		// Token: 0x040022BF RID: 8895
		public const uint MsgID = 608602U;

		// Token: 0x040022C0 RID: 8896
		public uint Sequence;

		// Token: 0x040022C1 RID: 8897
		public uint resCode;

		// Token: 0x040022C2 RID: 8898
		public string newName;
	}
}
