using System;

namespace Protocol
{
	// Token: 0x02000C27 RID: 3111
	[Protocol]
	public class WorldAventurePassExpPackReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060081DF RID: 33247 RVA: 0x0016E310 File Offset: 0x0016C710
		public uint GetMsgID()
		{
			return 609507U;
		}

		// Token: 0x060081E0 RID: 33248 RVA: 0x0016E317 File Offset: 0x0016C717
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060081E1 RID: 33249 RVA: 0x0016E31F File Offset: 0x0016C71F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060081E2 RID: 33250 RVA: 0x0016E328 File Offset: 0x0016C728
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.op);
		}

		// Token: 0x060081E3 RID: 33251 RVA: 0x0016E338 File Offset: 0x0016C738
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.op);
		}

		// Token: 0x060081E4 RID: 33252 RVA: 0x0016E348 File Offset: 0x0016C748
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.op);
		}

		// Token: 0x060081E5 RID: 33253 RVA: 0x0016E358 File Offset: 0x0016C758
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.op);
		}

		// Token: 0x060081E6 RID: 33254 RVA: 0x0016E368 File Offset: 0x0016C768
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003DF9 RID: 15865
		public const uint MsgID = 609507U;

		// Token: 0x04003DFA RID: 15866
		public uint Sequence;

		// Token: 0x04003DFB RID: 15867
		public byte op;
	}
}
