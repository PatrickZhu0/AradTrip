using System;

namespace Protocol
{
	// Token: 0x02000B85 RID: 2949
	[Protocol]
	public class WorldSyncTeamOption : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D08 RID: 32008 RVA: 0x0016468C File Offset: 0x00162A8C
		public uint GetMsgID()
		{
			return 601626U;
		}

		// Token: 0x06007D09 RID: 32009 RVA: 0x00164693 File Offset: 0x00162A93
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D0A RID: 32010 RVA: 0x0016469B File Offset: 0x00162A9B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D0B RID: 32011 RVA: 0x001646A4 File Offset: 0x00162AA4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			byte[] array = StringHelper.StringToUTF8Bytes(this.str);
			BaseDLL.encode_string(buffer, ref pos_, array, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.param1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param2);
		}

		// Token: 0x06007D0C RID: 32012 RVA: 0x001646F8 File Offset: 0x00162AF8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.str = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param2);
		}

		// Token: 0x06007D0D RID: 32013 RVA: 0x00164770 File Offset: 0x00162B70
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			byte[] array = StringHelper.StringToUTF8Bytes(this.str);
			BaseDLL.encode_string(buffer, ref pos_, array, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.param1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param2);
		}

		// Token: 0x06007D0E RID: 32014 RVA: 0x001647C8 File Offset: 0x00162BC8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.str = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param2);
		}

		// Token: 0x06007D0F RID: 32015 RVA: 0x00164840 File Offset: 0x00162C40
		public int getLen()
		{
			int num = 0;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.str);
			num += 2 + array.Length;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003B4D RID: 15181
		public const uint MsgID = 601626U;

		// Token: 0x04003B4E RID: 15182
		public uint Sequence;

		// Token: 0x04003B4F RID: 15183
		public byte type;

		// Token: 0x04003B50 RID: 15184
		public string str;

		// Token: 0x04003B51 RID: 15185
		public uint param1;

		// Token: 0x04003B52 RID: 15186
		public uint param2;
	}
}
