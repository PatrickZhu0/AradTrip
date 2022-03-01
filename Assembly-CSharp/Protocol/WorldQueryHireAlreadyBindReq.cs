using System;

namespace Protocol
{
	// Token: 0x02000C48 RID: 3144
	[Protocol]
	public class WorldQueryHireAlreadyBindReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060082E1 RID: 33505 RVA: 0x0017035C File Offset: 0x0016E75C
		public uint GetMsgID()
		{
			return 601797U;
		}

		// Token: 0x060082E2 RID: 33506 RVA: 0x00170363 File Offset: 0x0016E763
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060082E3 RID: 33507 RVA: 0x0017036B File Offset: 0x0016E76B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060082E4 RID: 33508 RVA: 0x00170374 File Offset: 0x0016E774
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.platform);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zone);
		}

		// Token: 0x060082E5 RID: 33509 RVA: 0x001703BC File Offset: 0x0016E7BC
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.platform = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zone);
		}

		// Token: 0x060082E6 RID: 33510 RVA: 0x00170428 File Offset: 0x0016E828
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.platform);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zone);
		}

		// Token: 0x060082E7 RID: 33511 RVA: 0x00170470 File Offset: 0x0016E870
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.platform = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zone);
		}

		// Token: 0x060082E8 RID: 33512 RVA: 0x001704DC File Offset: 0x0016E8DC
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.platform);
			num += 2 + array.Length;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003E74 RID: 15988
		public const uint MsgID = 601797U;

		// Token: 0x04003E75 RID: 15989
		public uint Sequence;

		// Token: 0x04003E76 RID: 15990
		public string platform;

		// Token: 0x04003E77 RID: 15991
		public uint accid;

		// Token: 0x04003E78 RID: 15992
		public uint zone;
	}
}
