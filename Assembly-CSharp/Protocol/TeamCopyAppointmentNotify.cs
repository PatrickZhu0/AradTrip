using System;

namespace Protocol
{
	// Token: 0x02000BF3 RID: 3059
	[Protocol]
	public class TeamCopyAppointmentNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008026 RID: 32806 RVA: 0x0016B01F File Offset: 0x0016941F
		public uint GetMsgID()
		{
			return 1100056U;
		}

		// Token: 0x06008027 RID: 32807 RVA: 0x0016B026 File Offset: 0x00169426
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008028 RID: 32808 RVA: 0x0016B02E File Offset: 0x0016942E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008029 RID: 32809 RVA: 0x0016B038 File Offset: 0x00169438
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.post);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600802A RID: 32810 RVA: 0x0016B070 File Offset: 0x00169470
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.post);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
		}

		// Token: 0x0600802B RID: 32811 RVA: 0x0016B0CC File Offset: 0x001694CC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.post);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600802C RID: 32812 RVA: 0x0016B108 File Offset: 0x00169508
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.post);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
		}

		// Token: 0x0600802D RID: 32813 RVA: 0x0016B164 File Offset: 0x00169564
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			return num + (2 + array.Length);
		}

		// Token: 0x04003D28 RID: 15656
		public const uint MsgID = 1100056U;

		// Token: 0x04003D29 RID: 15657
		public uint Sequence;

		// Token: 0x04003D2A RID: 15658
		public uint post;

		// Token: 0x04003D2B RID: 15659
		public string name;
	}
}
