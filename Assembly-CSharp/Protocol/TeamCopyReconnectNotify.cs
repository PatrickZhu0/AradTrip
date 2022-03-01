using System;

namespace Protocol
{
	// Token: 0x02000BE2 RID: 3042
	[Protocol]
	public class TeamCopyReconnectNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F90 RID: 32656 RVA: 0x00169D4C File Offset: 0x0016814C
		public uint GetMsgID()
		{
			return 1100040U;
		}

		// Token: 0x06007F91 RID: 32657 RVA: 0x00169D53 File Offset: 0x00168153
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F92 RID: 32658 RVA: 0x00169D5B File Offset: 0x0016815B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F93 RID: 32659 RVA: 0x00169D64 File Offset: 0x00168164
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sceneId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.expireTime);
		}

		// Token: 0x06007F94 RID: 32660 RVA: 0x00169D82 File Offset: 0x00168182
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sceneId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.expireTime);
		}

		// Token: 0x06007F95 RID: 32661 RVA: 0x00169DA0 File Offset: 0x001681A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sceneId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.expireTime);
		}

		// Token: 0x06007F96 RID: 32662 RVA: 0x00169DBE File Offset: 0x001681BE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sceneId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.expireTime);
		}

		// Token: 0x06007F97 RID: 32663 RVA: 0x00169DDC File Offset: 0x001681DC
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x04003CE4 RID: 15588
		public const uint MsgID = 1100040U;

		// Token: 0x04003CE5 RID: 15589
		public uint Sequence;

		// Token: 0x04003CE6 RID: 15590
		public uint sceneId;

		// Token: 0x04003CE7 RID: 15591
		public ulong expireTime;
	}
}
