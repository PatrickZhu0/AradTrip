using System;

namespace Protocol
{
	// Token: 0x02000A58 RID: 2648
	[Protocol]
	public class SceneChangePetSkillReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600746E RID: 29806 RVA: 0x00151570 File Offset: 0x0014F970
		public uint GetMsgID()
		{
			return 502211U;
		}

		// Token: 0x0600746F RID: 29807 RVA: 0x00151577 File Offset: 0x0014F977
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007470 RID: 29808 RVA: 0x0015157F File Offset: 0x0014F97F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007471 RID: 29809 RVA: 0x00151588 File Offset: 0x0014F988
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.skillIndex);
		}

		// Token: 0x06007472 RID: 29810 RVA: 0x001515A6 File Offset: 0x0014F9A6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.skillIndex);
		}

		// Token: 0x06007473 RID: 29811 RVA: 0x001515C4 File Offset: 0x0014F9C4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.skillIndex);
		}

		// Token: 0x06007474 RID: 29812 RVA: 0x001515E2 File Offset: 0x0014F9E2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.skillIndex);
		}

		// Token: 0x06007475 RID: 29813 RVA: 0x00151600 File Offset: 0x0014FA00
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x04003610 RID: 13840
		public const uint MsgID = 502211U;

		// Token: 0x04003611 RID: 13841
		public uint Sequence;

		// Token: 0x04003612 RID: 13842
		public ulong id;

		// Token: 0x04003613 RID: 13843
		public byte skillIndex;
	}
}
