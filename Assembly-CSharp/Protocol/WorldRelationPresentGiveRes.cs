using System;

namespace Protocol
{
	// Token: 0x02000CBC RID: 3260
	[Protocol]
	public class WorldRelationPresentGiveRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008653 RID: 34387 RVA: 0x00177750 File Offset: 0x00175B50
		public uint GetMsgID()
		{
			return 601775U;
		}

		// Token: 0x06008654 RID: 34388 RVA: 0x00177757 File Offset: 0x00175B57
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008655 RID: 34389 RVA: 0x0017775F File Offset: 0x00175B5F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008656 RID: 34390 RVA: 0x00177768 File Offset: 0x00175B68
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint64(buffer, ref pos_, this.friendID);
		}

		// Token: 0x06008657 RID: 34391 RVA: 0x00177786 File Offset: 0x00175B86
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.friendID);
		}

		// Token: 0x06008658 RID: 34392 RVA: 0x001777A4 File Offset: 0x00175BA4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint64(buffer, ref pos_, this.friendID);
		}

		// Token: 0x06008659 RID: 34393 RVA: 0x001777C2 File Offset: 0x00175BC2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.friendID);
		}

		// Token: 0x0600865A RID: 34394 RVA: 0x001777E0 File Offset: 0x00175BE0
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x04004048 RID: 16456
		public const uint MsgID = 601775U;

		// Token: 0x04004049 RID: 16457
		public uint Sequence;

		// Token: 0x0400404A RID: 16458
		public uint code;

		// Token: 0x0400404B RID: 16459
		public ulong friendID;
	}
}
