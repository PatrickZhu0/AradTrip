using System;

namespace Protocol
{
	// Token: 0x020009DF RID: 2527
	[Protocol]
	public class WorldMailListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060070F0 RID: 28912 RVA: 0x001465AC File Offset: 0x001449AC
		public uint GetMsgID()
		{
			return 601502U;
		}

		// Token: 0x060070F1 RID: 28913 RVA: 0x001465B3 File Offset: 0x001449B3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060070F2 RID: 28914 RVA: 0x001465BB File Offset: 0x001449BB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060070F3 RID: 28915 RVA: 0x001465C4 File Offset: 0x001449C4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060070F4 RID: 28916 RVA: 0x001465C6 File Offset: 0x001449C6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060070F5 RID: 28917 RVA: 0x001465C8 File Offset: 0x001449C8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060070F6 RID: 28918 RVA: 0x001465CA File Offset: 0x001449CA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060070F7 RID: 28919 RVA: 0x001465CC File Offset: 0x001449CC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400337A RID: 13178
		public const uint MsgID = 601502U;

		// Token: 0x0400337B RID: 13179
		public uint Sequence;
	}
}
