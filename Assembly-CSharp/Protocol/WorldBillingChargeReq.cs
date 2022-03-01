using System;

namespace Protocol
{
	// Token: 0x02000C33 RID: 3123
	[Protocol]
	public class WorldBillingChargeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008233 RID: 33331 RVA: 0x0016F2BD File Offset: 0x0016D6BD
		public uint GetMsgID()
		{
			return 604011U;
		}

		// Token: 0x06008234 RID: 33332 RVA: 0x0016F2C4 File Offset: 0x0016D6C4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008235 RID: 33333 RVA: 0x0016F2CC File Offset: 0x0016D6CC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008236 RID: 33334 RVA: 0x0016F2D5 File Offset: 0x0016D6D5
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mallType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goodsId);
		}

		// Token: 0x06008237 RID: 33335 RVA: 0x0016F2F3 File Offset: 0x0016D6F3
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mallType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goodsId);
		}

		// Token: 0x06008238 RID: 33336 RVA: 0x0016F311 File Offset: 0x0016D711
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mallType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goodsId);
		}

		// Token: 0x06008239 RID: 33337 RVA: 0x0016F32F File Offset: 0x0016D72F
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mallType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goodsId);
		}

		// Token: 0x0600823A RID: 33338 RVA: 0x0016F350 File Offset: 0x0016D750
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 4;
		}

		// Token: 0x04003E33 RID: 15923
		public const uint MsgID = 604011U;

		// Token: 0x04003E34 RID: 15924
		public uint Sequence;

		// Token: 0x04003E35 RID: 15925
		public byte mallType;

		// Token: 0x04003E36 RID: 15926
		public uint goodsId;
	}
}
