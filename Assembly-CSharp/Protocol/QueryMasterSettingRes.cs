using System;

namespace Protocol
{
	// Token: 0x02000C9D RID: 3229
	[Protocol]
	public class QueryMasterSettingRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600853C RID: 34108 RVA: 0x00175A4C File Offset: 0x00173E4C
		public uint GetMsgID()
		{
			return 601721U;
		}

		// Token: 0x0600853D RID: 34109 RVA: 0x00175A53 File Offset: 0x00173E53
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600853E RID: 34110 RVA: 0x00175A5B File Offset: 0x00173E5B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600853F RID: 34111 RVA: 0x00175A64 File Offset: 0x00173E64
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.masternote);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.isRecv);
		}

		// Token: 0x06008540 RID: 34112 RVA: 0x00175A9C File Offset: 0x00173E9C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.masternote = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRecv);
		}

		// Token: 0x06008541 RID: 34113 RVA: 0x00175AF8 File Offset: 0x00173EF8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.masternote);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.isRecv);
		}

		// Token: 0x06008542 RID: 34114 RVA: 0x00175B34 File Offset: 0x00173F34
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.masternote = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRecv);
		}

		// Token: 0x06008543 RID: 34115 RVA: 0x00175B90 File Offset: 0x00173F90
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.masternote);
			num += 2 + array.Length;
			return num + 1;
		}

		// Token: 0x04003FD5 RID: 16341
		public const uint MsgID = 601721U;

		// Token: 0x04003FD6 RID: 16342
		public uint Sequence;

		// Token: 0x04003FD7 RID: 16343
		public string masternote;

		// Token: 0x04003FD8 RID: 16344
		public byte isRecv;
	}
}
