using System;

namespace Protocol
{
	// Token: 0x0200087B RID: 2171
	[Protocol]
	public class WorldGuildSetDungeonTypeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060065C5 RID: 26053 RVA: 0x0012E3B8 File Offset: 0x0012C7B8
		public uint GetMsgID()
		{
			return 601992U;
		}

		// Token: 0x060065C6 RID: 26054 RVA: 0x0012E3BF File Offset: 0x0012C7BF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060065C7 RID: 26055 RVA: 0x0012E3C7 File Offset: 0x0012C7C7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060065C8 RID: 26056 RVA: 0x0012E3D0 File Offset: 0x0012C7D0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonType);
		}

		// Token: 0x060065C9 RID: 26057 RVA: 0x0012E3E0 File Offset: 0x0012C7E0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonType);
		}

		// Token: 0x060065CA RID: 26058 RVA: 0x0012E3F0 File Offset: 0x0012C7F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonType);
		}

		// Token: 0x060065CB RID: 26059 RVA: 0x0012E400 File Offset: 0x0012C800
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonType);
		}

		// Token: 0x060065CC RID: 26060 RVA: 0x0012E410 File Offset: 0x0012C810
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002D90 RID: 11664
		public const uint MsgID = 601992U;

		// Token: 0x04002D91 RID: 11665
		public uint Sequence;

		// Token: 0x04002D92 RID: 11666
		public uint dungeonType;
	}
}
