using System;

namespace Protocol
{
	// Token: 0x02000A43 RID: 2627
	[Protocol]
	public class SceneWeekSignRewardReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060073BD RID: 29629 RVA: 0x0014FDE1 File Offset: 0x0014E1E1
		public uint GetMsgID()
		{
			return 507408U;
		}

		// Token: 0x060073BE RID: 29630 RVA: 0x0014FDE8 File Offset: 0x0014E1E8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060073BF RID: 29631 RVA: 0x0014FDF0 File Offset: 0x0014E1F0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060073C0 RID: 29632 RVA: 0x0014FDF9 File Offset: 0x0014E1F9
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekID);
		}

		// Token: 0x060073C1 RID: 29633 RVA: 0x0014FE17 File Offset: 0x0014E217
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekID);
		}

		// Token: 0x060073C2 RID: 29634 RVA: 0x0014FE35 File Offset: 0x0014E235
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekID);
		}

		// Token: 0x060073C3 RID: 29635 RVA: 0x0014FE53 File Offset: 0x0014E253
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekID);
		}

		// Token: 0x060073C4 RID: 29636 RVA: 0x0014FE74 File Offset: 0x0014E274
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040035B6 RID: 13750
		public const uint MsgID = 507408U;

		// Token: 0x040035B7 RID: 13751
		public uint Sequence;

		// Token: 0x040035B8 RID: 13752
		public uint opActType;

		// Token: 0x040035B9 RID: 13753
		public uint weekID;
	}
}
