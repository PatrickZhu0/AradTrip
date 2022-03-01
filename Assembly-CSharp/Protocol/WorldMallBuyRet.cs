using System;

namespace Protocol
{
	// Token: 0x02000912 RID: 2322
	[Protocol]
	public class WorldMallBuyRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A12 RID: 27154 RVA: 0x00137E54 File Offset: 0x00136254
		public uint GetMsgID()
		{
			return 602802U;
		}

		// Token: 0x06006A13 RID: 27155 RVA: 0x00137E5B File Offset: 0x0013625B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A14 RID: 27156 RVA: 0x00137E63 File Offset: 0x00136263
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A15 RID: 27157 RVA: 0x00137E6C File Offset: 0x0013626C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mallitemid);
			BaseDLL.encode_int32(buffer, ref pos_, this.restLimitNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountRestBuyNum);
		}

		// Token: 0x06006A16 RID: 27158 RVA: 0x00137EA6 File Offset: 0x001362A6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mallitemid);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.restLimitNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountRestBuyNum);
		}

		// Token: 0x06006A17 RID: 27159 RVA: 0x00137EE0 File Offset: 0x001362E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mallitemid);
			BaseDLL.encode_int32(buffer, ref pos_, this.restLimitNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountRestBuyNum);
		}

		// Token: 0x06006A18 RID: 27160 RVA: 0x00137F1A File Offset: 0x0013631A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mallitemid);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.restLimitNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountRestBuyNum);
		}

		// Token: 0x06006A19 RID: 27161 RVA: 0x00137F54 File Offset: 0x00136354
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400301A RID: 12314
		public const uint MsgID = 602802U;

		// Token: 0x0400301B RID: 12315
		public uint Sequence;

		// Token: 0x0400301C RID: 12316
		public uint code;

		// Token: 0x0400301D RID: 12317
		public uint mallitemid;

		// Token: 0x0400301E RID: 12318
		public int restLimitNum;

		// Token: 0x0400301F RID: 12319
		public uint accountRestBuyNum;
	}
}
