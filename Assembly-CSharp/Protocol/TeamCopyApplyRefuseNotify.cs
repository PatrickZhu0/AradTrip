using System;

namespace Protocol
{
	// Token: 0x02000BFC RID: 3068
	[Protocol]
	public class TeamCopyApplyRefuseNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008077 RID: 32887 RVA: 0x0016BA04 File Offset: 0x00169E04
		public uint GetMsgID()
		{
			return 1100065U;
		}

		// Token: 0x06008078 RID: 32888 RVA: 0x0016BA0B File Offset: 0x00169E0B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008079 RID: 32889 RVA: 0x0016BA13 File Offset: 0x00169E13
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600807A RID: 32890 RVA: 0x0016BA1C File Offset: 0x00169E1C
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.chiefName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600807B RID: 32891 RVA: 0x0016BA48 File Offset: 0x00169E48
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.chiefName = StringHelper.BytesToString(array);
		}

		// Token: 0x0600807C RID: 32892 RVA: 0x0016BA98 File Offset: 0x00169E98
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.chiefName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600807D RID: 32893 RVA: 0x0016BAC4 File Offset: 0x00169EC4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.chiefName = StringHelper.BytesToString(array);
		}

		// Token: 0x0600807E RID: 32894 RVA: 0x0016BB14 File Offset: 0x00169F14
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.chiefName);
			return num + (2 + array.Length);
		}

		// Token: 0x04003D54 RID: 15700
		public const uint MsgID = 1100065U;

		// Token: 0x04003D55 RID: 15701
		public uint Sequence;

		// Token: 0x04003D56 RID: 15702
		public string chiefName;
	}
}
