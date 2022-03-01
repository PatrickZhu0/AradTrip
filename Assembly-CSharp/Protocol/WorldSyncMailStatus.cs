using System;

namespace Protocol
{
	// Token: 0x020009E3 RID: 2531
	[Protocol]
	public class WorldSyncMailStatus : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007114 RID: 28948 RVA: 0x001468F8 File Offset: 0x00144CF8
		public uint GetMsgID()
		{
			return 601507U;
		}

		// Token: 0x06007115 RID: 28949 RVA: 0x001468FF File Offset: 0x00144CFF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007116 RID: 28950 RVA: 0x00146907 File Offset: 0x00144D07
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007117 RID: 28951 RVA: 0x00146910 File Offset: 0x00144D10
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_int8(buffer, ref pos_, this.hasItem);
		}

		// Token: 0x06007118 RID: 28952 RVA: 0x0014693C File Offset: 0x00144D3C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hasItem);
		}

		// Token: 0x06007119 RID: 28953 RVA: 0x00146968 File Offset: 0x00144D68
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_int8(buffer, ref pos_, this.hasItem);
		}

		// Token: 0x0600711A RID: 28954 RVA: 0x00146994 File Offset: 0x00144D94
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hasItem);
		}

		// Token: 0x0600711B RID: 28955 RVA: 0x001469C0 File Offset: 0x00144DC0
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			return num + 1;
		}

		// Token: 0x04003387 RID: 13191
		public const uint MsgID = 601507U;

		// Token: 0x04003388 RID: 13192
		public uint Sequence;

		// Token: 0x04003389 RID: 13193
		public ulong id;

		// Token: 0x0400338A RID: 13194
		public byte status;

		// Token: 0x0400338B RID: 13195
		public byte hasItem;
	}
}
