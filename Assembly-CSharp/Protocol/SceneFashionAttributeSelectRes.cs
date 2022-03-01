using System;

namespace Protocol
{
	// Token: 0x0200092A RID: 2346
	[Protocol]
	public class SceneFashionAttributeSelectRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006AE7 RID: 27367 RVA: 0x001394DC File Offset: 0x001378DC
		public uint GetMsgID()
		{
			return 500959U;
		}

		// Token: 0x06006AE8 RID: 27368 RVA: 0x001394E3 File Offset: 0x001378E3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006AE9 RID: 27369 RVA: 0x001394EB File Offset: 0x001378EB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006AEA RID: 27370 RVA: 0x001394F4 File Offset: 0x001378F4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006AEB RID: 27371 RVA: 0x00139504 File Offset: 0x00137904
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006AEC RID: 27372 RVA: 0x00139514 File Offset: 0x00137914
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006AED RID: 27373 RVA: 0x00139524 File Offset: 0x00137924
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006AEE RID: 27374 RVA: 0x00139534 File Offset: 0x00137934
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400307B RID: 12411
		public const uint MsgID = 500959U;

		// Token: 0x0400307C RID: 12412
		public uint Sequence;

		// Token: 0x0400307D RID: 12413
		public uint result;
	}
}
