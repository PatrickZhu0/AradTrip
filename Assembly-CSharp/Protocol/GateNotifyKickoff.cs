using System;

namespace Protocol
{
	// Token: 0x020009D6 RID: 2518
	[Protocol]
	public class GateNotifyKickoff : IProtocolStream, IGetMsgID
	{
		// Token: 0x060070AE RID: 28846 RVA: 0x00145B4C File Offset: 0x00143F4C
		public uint GetMsgID()
		{
			return 300404U;
		}

		// Token: 0x060070AF RID: 28847 RVA: 0x00145B53 File Offset: 0x00143F53
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060070B0 RID: 28848 RVA: 0x00145B5B File Offset: 0x00143F5B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060070B1 RID: 28849 RVA: 0x00145B64 File Offset: 0x00143F64
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
			byte[] str = StringHelper.StringToUTF8Bytes(this.msg);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060070B2 RID: 28850 RVA: 0x00145B9C File Offset: 0x00143F9C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.msg = StringHelper.BytesToString(array);
		}

		// Token: 0x060070B3 RID: 28851 RVA: 0x00145BF8 File Offset: 0x00143FF8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
			byte[] str = StringHelper.StringToUTF8Bytes(this.msg);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060070B4 RID: 28852 RVA: 0x00145C34 File Offset: 0x00144034
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.msg = StringHelper.BytesToString(array);
		}

		// Token: 0x060070B5 RID: 28853 RVA: 0x00145C90 File Offset: 0x00144090
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.msg);
			return num + (2 + array.Length);
		}

		// Token: 0x04003352 RID: 13138
		public const uint MsgID = 300404U;

		// Token: 0x04003353 RID: 13139
		public uint Sequence;

		// Token: 0x04003354 RID: 13140
		public uint errorCode;

		// Token: 0x04003355 RID: 13141
		public string msg;
	}
}
