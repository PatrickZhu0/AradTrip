using System;

namespace Protocol
{
	// Token: 0x0200087C RID: 2172
	[Protocol]
	public class WorldGuildSetDungeonTypeRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060065CE RID: 26062 RVA: 0x0012E42C File Offset: 0x0012C82C
		public uint GetMsgID()
		{
			return 601993U;
		}

		// Token: 0x060065CF RID: 26063 RVA: 0x0012E433 File Offset: 0x0012C833
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060065D0 RID: 26064 RVA: 0x0012E43B File Offset: 0x0012C83B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060065D1 RID: 26065 RVA: 0x0012E444 File Offset: 0x0012C844
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonType);
		}

		// Token: 0x060065D2 RID: 26066 RVA: 0x0012E462 File Offset: 0x0012C862
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonType);
		}

		// Token: 0x060065D3 RID: 26067 RVA: 0x0012E480 File Offset: 0x0012C880
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonType);
		}

		// Token: 0x060065D4 RID: 26068 RVA: 0x0012E49E File Offset: 0x0012C89E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonType);
		}

		// Token: 0x060065D5 RID: 26069 RVA: 0x0012E4BC File Offset: 0x0012C8BC
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002D93 RID: 11667
		public const uint MsgID = 601993U;

		// Token: 0x04002D94 RID: 11668
		public uint Sequence;

		// Token: 0x04002D95 RID: 11669
		public uint result;

		// Token: 0x04002D96 RID: 11670
		public uint dungeonType;
	}
}
