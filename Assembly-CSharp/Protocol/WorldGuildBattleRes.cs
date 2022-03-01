using System;

namespace Protocol
{
	// Token: 0x02000854 RID: 2132
	[Protocol]
	public class WorldGuildBattleRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006466 RID: 25702 RVA: 0x0012BA3C File Offset: 0x00129E3C
		public uint GetMsgID()
		{
			return 601943U;
		}

		// Token: 0x06006467 RID: 25703 RVA: 0x0012BA43 File Offset: 0x00129E43
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006468 RID: 25704 RVA: 0x0012BA4B File Offset: 0x00129E4B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006469 RID: 25705 RVA: 0x0012BA54 File Offset: 0x00129E54
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.terrId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.enrollSize);
		}

		// Token: 0x0600646A RID: 25706 RVA: 0x0012BA80 File Offset: 0x00129E80
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.terrId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.enrollSize);
		}

		// Token: 0x0600646B RID: 25707 RVA: 0x0012BAAC File Offset: 0x00129EAC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.terrId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.enrollSize);
		}

		// Token: 0x0600646C RID: 25708 RVA: 0x0012BAD8 File Offset: 0x00129ED8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.terrId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.enrollSize);
		}

		// Token: 0x0600646D RID: 25709 RVA: 0x0012BB04 File Offset: 0x00129F04
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			return num + 4;
		}

		// Token: 0x04002CFB RID: 11515
		public const uint MsgID = 601943U;

		// Token: 0x04002CFC RID: 11516
		public uint Sequence;

		// Token: 0x04002CFD RID: 11517
		public uint result;

		// Token: 0x04002CFE RID: 11518
		public byte terrId;

		// Token: 0x04002CFF RID: 11519
		public uint enrollSize;
	}
}
