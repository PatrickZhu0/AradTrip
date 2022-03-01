using System;

namespace Protocol
{
	// Token: 0x02000BEB RID: 3051
	[Protocol]
	public class TeamCopyMemberNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007FE1 RID: 32737 RVA: 0x0016A558 File Offset: 0x00168958
		public uint GetMsgID()
		{
			return 1100049U;
		}

		// Token: 0x06007FE2 RID: 32738 RVA: 0x0016A55F File Offset: 0x0016895F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007FE3 RID: 32739 RVA: 0x0016A567 File Offset: 0x00168967
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007FE4 RID: 32740 RVA: 0x0016A570 File Offset: 0x00168970
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.memberName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.flag);
		}

		// Token: 0x06007FE5 RID: 32741 RVA: 0x0016A5A8 File Offset: 0x001689A8
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.memberName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.flag);
		}

		// Token: 0x06007FE6 RID: 32742 RVA: 0x0016A604 File Offset: 0x00168A04
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.memberName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.flag);
		}

		// Token: 0x06007FE7 RID: 32743 RVA: 0x0016A640 File Offset: 0x00168A40
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.memberName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.flag);
		}

		// Token: 0x06007FE8 RID: 32744 RVA: 0x0016A69C File Offset: 0x00168A9C
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.memberName);
			num += 2 + array.Length;
			return num + 4;
		}

		// Token: 0x04003D08 RID: 15624
		public const uint MsgID = 1100049U;

		// Token: 0x04003D09 RID: 15625
		public uint Sequence;

		// Token: 0x04003D0A RID: 15626
		public string memberName;

		// Token: 0x04003D0B RID: 15627
		public uint flag;
	}
}
