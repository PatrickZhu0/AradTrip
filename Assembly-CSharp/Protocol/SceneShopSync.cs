using System;

namespace Protocol
{
	// Token: 0x020008F0 RID: 2288
	[Protocol]
	public class SceneShopSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x060068E0 RID: 26848 RVA: 0x001362A4 File Offset: 0x001346A4
		public uint GetMsgID()
		{
			return 500926U;
		}

		// Token: 0x060068E1 RID: 26849 RVA: 0x001362AB File Offset: 0x001346AB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060068E2 RID: 26850 RVA: 0x001362B3 File Offset: 0x001346B3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060068E3 RID: 26851 RVA: 0x001362BC File Offset: 0x001346BC
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060068E4 RID: 26852 RVA: 0x001362BE File Offset: 0x001346BE
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060068E5 RID: 26853 RVA: 0x001362C0 File Offset: 0x001346C0
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060068E6 RID: 26854 RVA: 0x001362C2 File Offset: 0x001346C2
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060068E7 RID: 26855 RVA: 0x001362C4 File Offset: 0x001346C4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002F95 RID: 12181
		public const uint MsgID = 500926U;

		// Token: 0x04002F96 RID: 12182
		public uint Sequence;
	}
}
