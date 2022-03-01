using System;

namespace Protocol
{
	// Token: 0x020008A0 RID: 2208
	[Protocol]
	public class WorldGuildReceiveMergerRequestRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060066FD RID: 26365 RVA: 0x00130810 File Offset: 0x0012EC10
		public uint GetMsgID()
		{
			return 601982U;
		}

		// Token: 0x060066FE RID: 26366 RVA: 0x00130817 File Offset: 0x0012EC17
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060066FF RID: 26367 RVA: 0x0013081F File Offset: 0x0012EC1F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006700 RID: 26368 RVA: 0x00130828 File Offset: 0x0012EC28
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isHave);
		}

		// Token: 0x06006701 RID: 26369 RVA: 0x00130838 File Offset: 0x0012EC38
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isHave);
		}

		// Token: 0x06006702 RID: 26370 RVA: 0x00130848 File Offset: 0x0012EC48
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isHave);
		}

		// Token: 0x06006703 RID: 26371 RVA: 0x00130858 File Offset: 0x0012EC58
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isHave);
		}

		// Token: 0x06006704 RID: 26372 RVA: 0x00130868 File Offset: 0x0012EC68
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04002E0D RID: 11789
		public const uint MsgID = 601982U;

		// Token: 0x04002E0E RID: 11790
		public uint Sequence;

		// Token: 0x04002E0F RID: 11791
		public byte isHave;
	}
}
