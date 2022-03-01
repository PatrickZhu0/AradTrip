using System;

namespace Protocol
{
	// Token: 0x02000C39 RID: 3129
	[Protocol]
	public class WorldUseHireCodeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008260 RID: 33376 RVA: 0x0016F640 File Offset: 0x0016DA40
		public uint GetMsgID()
		{
			return 601784U;
		}

		// Token: 0x06008261 RID: 33377 RVA: 0x0016F647 File Offset: 0x0016DA47
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008262 RID: 33378 RVA: 0x0016F64F File Offset: 0x0016DA4F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008263 RID: 33379 RVA: 0x0016F658 File Offset: 0x0016DA58
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.code);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06008264 RID: 33380 RVA: 0x0016F684 File Offset: 0x0016DA84
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.code = StringHelper.BytesToString(array);
		}

		// Token: 0x06008265 RID: 33381 RVA: 0x0016F6D4 File Offset: 0x0016DAD4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.code);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06008266 RID: 33382 RVA: 0x0016F700 File Offset: 0x0016DB00
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.code = StringHelper.BytesToString(array);
		}

		// Token: 0x06008267 RID: 33383 RVA: 0x0016F750 File Offset: 0x0016DB50
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.code);
			return num + (2 + array.Length);
		}

		// Token: 0x04003E48 RID: 15944
		public const uint MsgID = 601784U;

		// Token: 0x04003E49 RID: 15945
		public uint Sequence;

		// Token: 0x04003E4A RID: 15946
		public string code;
	}
}
