using System;

namespace Protocol
{
	// Token: 0x02000BDD RID: 3037
	[Protocol]
	public class TeamCopyStageFlopReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F66 RID: 32614 RVA: 0x00169704 File Offset: 0x00167B04
		public uint GetMsgID()
		{
			return 1100035U;
		}

		// Token: 0x06007F67 RID: 32615 RVA: 0x0016970B File Offset: 0x00167B0B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F68 RID: 32616 RVA: 0x00169713 File Offset: 0x00167B13
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F69 RID: 32617 RVA: 0x0016971C File Offset: 0x00167B1C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.stageId);
		}

		// Token: 0x06007F6A RID: 32618 RVA: 0x0016972C File Offset: 0x00167B2C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stageId);
		}

		// Token: 0x06007F6B RID: 32619 RVA: 0x0016973C File Offset: 0x00167B3C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.stageId);
		}

		// Token: 0x06007F6C RID: 32620 RVA: 0x0016974C File Offset: 0x00167B4C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stageId);
		}

		// Token: 0x06007F6D RID: 32621 RVA: 0x0016975C File Offset: 0x00167B5C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003CCE RID: 15566
		public const uint MsgID = 1100035U;

		// Token: 0x04003CCF RID: 15567
		public uint Sequence;

		// Token: 0x04003CD0 RID: 15568
		public uint stageId;
	}
}
