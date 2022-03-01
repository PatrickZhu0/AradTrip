using System;

namespace Protocol
{
	// Token: 0x02000BE7 RID: 3047
	[Protocol]
	public class TeamCopyKickReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007FBD RID: 32701 RVA: 0x0016A349 File Offset: 0x00168749
		public uint GetMsgID()
		{
			return 1100045U;
		}

		// Token: 0x06007FBE RID: 32702 RVA: 0x0016A350 File Offset: 0x00168750
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007FBF RID: 32703 RVA: 0x0016A358 File Offset: 0x00168758
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007FC0 RID: 32704 RVA: 0x0016A361 File Offset: 0x00168761
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
		}

		// Token: 0x06007FC1 RID: 32705 RVA: 0x0016A371 File Offset: 0x00168771
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
		}

		// Token: 0x06007FC2 RID: 32706 RVA: 0x0016A381 File Offset: 0x00168781
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
		}

		// Token: 0x06007FC3 RID: 32707 RVA: 0x0016A391 File Offset: 0x00168791
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
		}

		// Token: 0x06007FC4 RID: 32708 RVA: 0x0016A3A4 File Offset: 0x001687A4
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003CFB RID: 15611
		public const uint MsgID = 1100045U;

		// Token: 0x04003CFC RID: 15612
		public uint Sequence;

		// Token: 0x04003CFD RID: 15613
		public ulong playerId;
	}
}
