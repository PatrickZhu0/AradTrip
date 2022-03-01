using System;

namespace Protocol
{
	// Token: 0x02000CB8 RID: 3256
	[Protocol]
	public class WorldAutomaticFinishSchoolReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600862F RID: 34351 RVA: 0x00177480 File Offset: 0x00175880
		public uint GetMsgID()
		{
			return 601772U;
		}

		// Token: 0x06008630 RID: 34352 RVA: 0x00177487 File Offset: 0x00175887
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008631 RID: 34353 RVA: 0x0017748F File Offset: 0x0017588F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008632 RID: 34354 RVA: 0x00177498 File Offset: 0x00175898
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetId);
		}

		// Token: 0x06008633 RID: 34355 RVA: 0x001774A8 File Offset: 0x001758A8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetId);
		}

		// Token: 0x06008634 RID: 34356 RVA: 0x001774B8 File Offset: 0x001758B8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetId);
		}

		// Token: 0x06008635 RID: 34357 RVA: 0x001774C8 File Offset: 0x001758C8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetId);
		}

		// Token: 0x06008636 RID: 34358 RVA: 0x001774D8 File Offset: 0x001758D8
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x0400403B RID: 16443
		public const uint MsgID = 601772U;

		// Token: 0x0400403C RID: 16444
		public uint Sequence;

		// Token: 0x0400403D RID: 16445
		public ulong targetId;
	}
}
