using System;

namespace Protocol
{
	// Token: 0x02000C49 RID: 3145
	[Protocol]
	public class WorldQueryHireAlreadyBindRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060082EA RID: 33514 RVA: 0x00170510 File Offset: 0x0016E910
		public uint GetMsgID()
		{
			return 601798U;
		}

		// Token: 0x060082EB RID: 33515 RVA: 0x00170517 File Offset: 0x0016E917
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060082EC RID: 33516 RVA: 0x0017051F File Offset: 0x0016E91F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060082ED RID: 33517 RVA: 0x00170528 File Offset: 0x0016E928
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zone);
		}

		// Token: 0x060082EE RID: 33518 RVA: 0x00170554 File Offset: 0x0016E954
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zone);
		}

		// Token: 0x060082EF RID: 33519 RVA: 0x00170580 File Offset: 0x0016E980
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zone);
		}

		// Token: 0x060082F0 RID: 33520 RVA: 0x001705AC File Offset: 0x0016E9AC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zone);
		}

		// Token: 0x060082F1 RID: 33521 RVA: 0x001705D8 File Offset: 0x0016E9D8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003E79 RID: 15993
		public const uint MsgID = 601798U;

		// Token: 0x04003E7A RID: 15994
		public uint Sequence;

		// Token: 0x04003E7B RID: 15995
		public uint errorCode;

		// Token: 0x04003E7C RID: 15996
		public uint accid;

		// Token: 0x04003E7D RID: 15997
		public uint zone;
	}
}
