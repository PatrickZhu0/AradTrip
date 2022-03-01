using System;

namespace Protocol
{
	// Token: 0x02000B84 RID: 2948
	[Protocol]
	public class WorldSetTeamOption : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007CFF RID: 31999 RVA: 0x001644A0 File Offset: 0x001628A0
		public uint GetMsgID()
		{
			return 601625U;
		}

		// Token: 0x06007D00 RID: 32000 RVA: 0x001644A7 File Offset: 0x001628A7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D01 RID: 32001 RVA: 0x001644AF File Offset: 0x001628AF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D02 RID: 32002 RVA: 0x001644B8 File Offset: 0x001628B8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			byte[] array = StringHelper.StringToUTF8Bytes(this.str);
			BaseDLL.encode_string(buffer, ref pos_, array, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.param1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param2);
		}

		// Token: 0x06007D03 RID: 32003 RVA: 0x0016450C File Offset: 0x0016290C
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

		// Token: 0x06007D04 RID: 32004 RVA: 0x00164584 File Offset: 0x00162984
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			byte[] array = StringHelper.StringToUTF8Bytes(this.str);
			BaseDLL.encode_string(buffer, ref pos_, array, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.param1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param2);
		}

		// Token: 0x06007D05 RID: 32005 RVA: 0x001645DC File Offset: 0x001629DC
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

		// Token: 0x06007D06 RID: 32006 RVA: 0x00164654 File Offset: 0x00162A54
		public int getLen()
		{
			int num = 0;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.str);
			num += 2 + array.Length;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003B47 RID: 15175
		public const uint MsgID = 601625U;

		// Token: 0x04003B48 RID: 15176
		public uint Sequence;

		// Token: 0x04003B49 RID: 15177
		public byte type;

		// Token: 0x04003B4A RID: 15178
		public string str;

		// Token: 0x04003B4B RID: 15179
		public uint param1;

		// Token: 0x04003B4C RID: 15180
		public uint param2;
	}
}
