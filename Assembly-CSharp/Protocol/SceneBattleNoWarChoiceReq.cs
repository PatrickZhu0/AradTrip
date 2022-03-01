using System;

namespace Protocol
{
	// Token: 0x02000722 RID: 1826
	[Protocol]
	public class SceneBattleNoWarChoiceReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005BA2 RID: 23458 RVA: 0x001157CC File Offset: 0x00113BCC
		public uint GetMsgID()
		{
			return 508943U;
		}

		// Token: 0x06005BA3 RID: 23459 RVA: 0x001157D3 File Offset: 0x00113BD3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005BA4 RID: 23460 RVA: 0x001157DB File Offset: 0x00113BDB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005BA5 RID: 23461 RVA: 0x001157E4 File Offset: 0x00113BE4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.isNoWar);
		}

		// Token: 0x06005BA6 RID: 23462 RVA: 0x001157F4 File Offset: 0x00113BF4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isNoWar);
		}

		// Token: 0x06005BA7 RID: 23463 RVA: 0x00115804 File Offset: 0x00113C04
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.isNoWar);
		}

		// Token: 0x06005BA8 RID: 23464 RVA: 0x00115814 File Offset: 0x00113C14
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isNoWar);
		}

		// Token: 0x06005BA9 RID: 23465 RVA: 0x00115824 File Offset: 0x00113C24
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400255C RID: 9564
		public const uint MsgID = 508943U;

		// Token: 0x0400255D RID: 9565
		public uint Sequence;

		// Token: 0x0400255E RID: 9566
		public uint isNoWar;
	}
}
