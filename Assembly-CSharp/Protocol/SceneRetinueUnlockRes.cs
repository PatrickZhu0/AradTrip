using System;

namespace Protocol
{
	// Token: 0x02000ABC RID: 2748
	[Protocol]
	public class SceneRetinueUnlockRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007741 RID: 30529 RVA: 0x00158C80 File Offset: 0x00157080
		public uint GetMsgID()
		{
			return 507008U;
		}

		// Token: 0x06007742 RID: 30530 RVA: 0x00158C87 File Offset: 0x00157087
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007743 RID: 30531 RVA: 0x00158C8F File Offset: 0x0015708F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007744 RID: 30532 RVA: 0x00158C98 File Offset: 0x00157098
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
		}

		// Token: 0x06007745 RID: 30533 RVA: 0x00158CB6 File Offset: 0x001570B6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
		}

		// Token: 0x06007746 RID: 30534 RVA: 0x00158CD4 File Offset: 0x001570D4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
		}

		// Token: 0x06007747 RID: 30535 RVA: 0x00158CF2 File Offset: 0x001570F2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
		}

		// Token: 0x06007748 RID: 30536 RVA: 0x00158D10 File Offset: 0x00157110
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040037D6 RID: 14294
		public const uint MsgID = 507008U;

		// Token: 0x040037D7 RID: 14295
		public uint Sequence;

		// Token: 0x040037D8 RID: 14296
		public uint result;

		// Token: 0x040037D9 RID: 14297
		public uint dataId;
	}
}
