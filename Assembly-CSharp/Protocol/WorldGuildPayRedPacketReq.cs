using System;

namespace Protocol
{
	// Token: 0x02000851 RID: 2129
	[Protocol]
	public class WorldGuildPayRedPacketReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600644B RID: 25675 RVA: 0x0012B7DC File Offset: 0x00129BDC
		public uint GetMsgID()
		{
			return 601941U;
		}

		// Token: 0x0600644C RID: 25676 RVA: 0x0012B7E3 File Offset: 0x00129BE3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600644D RID: 25677 RVA: 0x0012B7EB File Offset: 0x00129BEB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600644E RID: 25678 RVA: 0x0012B7F4 File Offset: 0x00129BF4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.reason);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
		}

		// Token: 0x0600644F RID: 25679 RVA: 0x0012B83C File Offset: 0x00129C3C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.reason);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006450 RID: 25680 RVA: 0x0012B8A8 File Offset: 0x00129CA8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.reason);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
		}

		// Token: 0x06006451 RID: 25681 RVA: 0x0012B8F0 File Offset: 0x00129CF0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.reason);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006452 RID: 25682 RVA: 0x0012B95C File Offset: 0x00129D5C
		public int getLen()
		{
			int num = 0;
			num += 2;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			return num + 1;
		}

		// Token: 0x04002CF1 RID: 11505
		public const uint MsgID = 601941U;

		// Token: 0x04002CF2 RID: 11506
		public uint Sequence;

		// Token: 0x04002CF3 RID: 11507
		public ushort reason;

		// Token: 0x04002CF4 RID: 11508
		public string name;

		// Token: 0x04002CF5 RID: 11509
		public byte num;
	}
}
