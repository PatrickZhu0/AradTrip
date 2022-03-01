using System;

namespace Protocol
{
	// Token: 0x02000C81 RID: 3201
	[Protocol]
	public class WorldSyncRelationData : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008452 RID: 33874 RVA: 0x00172FA4 File Offset: 0x001713A4
		public uint GetMsgID()
		{
			return 601707U;
		}

		// Token: 0x06008453 RID: 33875 RVA: 0x00172FAB File Offset: 0x001713AB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008454 RID: 33876 RVA: 0x00172FB3 File Offset: 0x001713B3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008455 RID: 33877 RVA: 0x00172FBC File Offset: 0x001713BC
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008456 RID: 33878 RVA: 0x00172FBE File Offset: 0x001713BE
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008457 RID: 33879 RVA: 0x00172FC0 File Offset: 0x001713C0
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008458 RID: 33880 RVA: 0x00172FC2 File Offset: 0x001713C2
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008459 RID: 33881 RVA: 0x00172FC4 File Offset: 0x001713C4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003F54 RID: 16212
		public const uint MsgID = 601707U;

		// Token: 0x04003F55 RID: 16213
		public uint Sequence;
	}
}
