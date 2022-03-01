using System;

namespace Protocol
{
	// Token: 0x02000948 RID: 2376
	[Protocol]
	public class PayingGambleReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006BEC RID: 27628 RVA: 0x0013AE4D File Offset: 0x0013924D
		public uint GetMsgID()
		{
			return 707901U;
		}

		// Token: 0x06006BED RID: 27629 RVA: 0x0013AE54 File Offset: 0x00139254
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006BEE RID: 27630 RVA: 0x0013AE5C File Offset: 0x0013925C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006BEF RID: 27631 RVA: 0x0013AE65 File Offset: 0x00139265
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.groupId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.investCopies);
			BaseDLL.encode_int8(buffer, ref pos_, this.bBuyAll);
		}

		// Token: 0x06006BF0 RID: 27632 RVA: 0x0013AE9F File Offset: 0x0013929F
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.groupId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.investCopies);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.bBuyAll);
		}

		// Token: 0x06006BF1 RID: 27633 RVA: 0x0013AED9 File Offset: 0x001392D9
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.groupId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.investCopies);
			BaseDLL.encode_int8(buffer, ref pos_, this.bBuyAll);
		}

		// Token: 0x06006BF2 RID: 27634 RVA: 0x0013AF13 File Offset: 0x00139313
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.groupId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.investCopies);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.bBuyAll);
		}

		// Token: 0x06006BF3 RID: 27635 RVA: 0x0013AF50 File Offset: 0x00139350
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			num += 4;
			return num + 1;
		}

		// Token: 0x040030DC RID: 12508
		public const uint MsgID = 707901U;

		// Token: 0x040030DD RID: 12509
		public uint Sequence;

		// Token: 0x040030DE RID: 12510
		public uint gambingItemId;

		// Token: 0x040030DF RID: 12511
		public ushort groupId;

		// Token: 0x040030E0 RID: 12512
		public uint investCopies;

		// Token: 0x040030E1 RID: 12513
		public byte bBuyAll;
	}
}
