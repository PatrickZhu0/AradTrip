using System;

namespace Protocol
{
	// Token: 0x0200089B RID: 2203
	[Protocol]
	public class WorldGuildWatchCanMergerReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060066D0 RID: 26320 RVA: 0x0013039C File Offset: 0x0012E79C
		public uint GetMsgID()
		{
			return 601977U;
		}

		// Token: 0x060066D1 RID: 26321 RVA: 0x001303A3 File Offset: 0x0012E7A3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060066D2 RID: 26322 RVA: 0x001303AB File Offset: 0x0012E7AB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060066D3 RID: 26323 RVA: 0x001303B4 File Offset: 0x0012E7B4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.start);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x060066D4 RID: 26324 RVA: 0x001303D2 File Offset: 0x0012E7D2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.start);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x060066D5 RID: 26325 RVA: 0x001303F0 File Offset: 0x0012E7F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.start);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x060066D6 RID: 26326 RVA: 0x0013040E File Offset: 0x0012E80E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.start);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x060066D7 RID: 26327 RVA: 0x0013042C File Offset: 0x0012E82C
		public int getLen()
		{
			int num = 0;
			num += 2;
			return num + 2;
		}

		// Token: 0x04002DFA RID: 11770
		public const uint MsgID = 601977U;

		// Token: 0x04002DFB RID: 11771
		public uint Sequence;

		// Token: 0x04002DFC RID: 11772
		public ushort start;

		// Token: 0x04002DFD RID: 11773
		public ushort num;
	}
}
