using System;

namespace Protocol
{
	// Token: 0x02000CB5 RID: 3253
	[Protocol]
	public class WorldDiscipleFinishSchoolReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008614 RID: 34324 RVA: 0x001772E8 File Offset: 0x001756E8
		public uint GetMsgID()
		{
			return 601749U;
		}

		// Token: 0x06008615 RID: 34325 RVA: 0x001772EF File Offset: 0x001756EF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008616 RID: 34326 RVA: 0x001772F7 File Offset: 0x001756F7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008617 RID: 34327 RVA: 0x00177300 File Offset: 0x00175700
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipleId);
		}

		// Token: 0x06008618 RID: 34328 RVA: 0x00177310 File Offset: 0x00175710
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipleId);
		}

		// Token: 0x06008619 RID: 34329 RVA: 0x00177320 File Offset: 0x00175720
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipleId);
		}

		// Token: 0x0600861A RID: 34330 RVA: 0x00177330 File Offset: 0x00175730
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipleId);
		}

		// Token: 0x0600861B RID: 34331 RVA: 0x00177340 File Offset: 0x00175740
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04004031 RID: 16433
		public const uint MsgID = 601749U;

		// Token: 0x04004032 RID: 16434
		public uint Sequence;

		// Token: 0x04004033 RID: 16435
		public ulong discipleId;
	}
}
