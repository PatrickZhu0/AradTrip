using System;

namespace Protocol
{
	// Token: 0x02000B80 RID: 2944
	[Protocol]
	public class WorldLeaveTeamReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007CDB RID: 31963 RVA: 0x00164292 File Offset: 0x00162692
		public uint GetMsgID()
		{
			return 601603U;
		}

		// Token: 0x06007CDC RID: 31964 RVA: 0x00164299 File Offset: 0x00162699
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007CDD RID: 31965 RVA: 0x001642A1 File Offset: 0x001626A1
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007CDE RID: 31966 RVA: 0x001642AA File Offset: 0x001626AA
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007CDF RID: 31967 RVA: 0x001642BA File Offset: 0x001626BA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007CE0 RID: 31968 RVA: 0x001642CA File Offset: 0x001626CA
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007CE1 RID: 31969 RVA: 0x001642DA File Offset: 0x001626DA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007CE2 RID: 31970 RVA: 0x001642EC File Offset: 0x001626EC
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003B3A RID: 15162
		public const uint MsgID = 601603U;

		// Token: 0x04003B3B RID: 15163
		public uint Sequence;

		// Token: 0x04003B3C RID: 15164
		public ulong id;
	}
}
