using System;

namespace Protocol
{
	// Token: 0x02000AC0 RID: 2752
	[Protocol]
	public class WorldExtensibleRoleFieldUnlockReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600775C RID: 30556 RVA: 0x00158ECC File Offset: 0x001572CC
		public uint GetMsgID()
		{
			return 608701U;
		}

		// Token: 0x0600775D RID: 30557 RVA: 0x00158ED3 File Offset: 0x001572D3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600775E RID: 30558 RVA: 0x00158EDB File Offset: 0x001572DB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600775F RID: 30559 RVA: 0x00158EE4 File Offset: 0x001572E4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.costItemUId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.costItemDataId);
		}

		// Token: 0x06007760 RID: 30560 RVA: 0x00158F02 File Offset: 0x00157302
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.costItemUId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.costItemDataId);
		}

		// Token: 0x06007761 RID: 30561 RVA: 0x00158F20 File Offset: 0x00157320
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.costItemUId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.costItemDataId);
		}

		// Token: 0x06007762 RID: 30562 RVA: 0x00158F3E File Offset: 0x0015733E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.costItemUId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.costItemDataId);
		}

		// Token: 0x06007763 RID: 30563 RVA: 0x00158F5C File Offset: 0x0015735C
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x040037F0 RID: 14320
		public const uint MsgID = 608701U;

		// Token: 0x040037F1 RID: 14321
		public uint Sequence;

		// Token: 0x040037F2 RID: 14322
		public ulong costItemUId;

		// Token: 0x040037F3 RID: 14323
		public uint costItemDataId;
	}
}
