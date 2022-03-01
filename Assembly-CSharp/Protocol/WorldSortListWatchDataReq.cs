using System;

namespace Protocol
{
	// Token: 0x02000B6D RID: 2925
	[Protocol]
	public class WorldSortListWatchDataReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C78 RID: 31864 RVA: 0x0016342C File Offset: 0x0016182C
		public uint GetMsgID()
		{
			return 602603U;
		}

		// Token: 0x06007C79 RID: 31865 RVA: 0x00163433 File Offset: 0x00161833
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C7A RID: 31866 RVA: 0x0016343B File Offset: 0x0016183B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C7B RID: 31867 RVA: 0x00163444 File Offset: 0x00161844
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007C7C RID: 31868 RVA: 0x00163462 File Offset: 0x00161862
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007C7D RID: 31869 RVA: 0x00163480 File Offset: 0x00161880
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007C7E RID: 31870 RVA: 0x0016349E File Offset: 0x0016189E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007C7F RID: 31871 RVA: 0x001634BC File Offset: 0x001618BC
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 8;
		}

		// Token: 0x04003AF0 RID: 15088
		public const uint MsgID = 602603U;

		// Token: 0x04003AF1 RID: 15089
		public uint Sequence;

		// Token: 0x04003AF2 RID: 15090
		public byte type;

		// Token: 0x04003AF3 RID: 15091
		public ulong id;
	}
}
