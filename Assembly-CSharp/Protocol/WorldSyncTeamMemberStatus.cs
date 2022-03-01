using System;

namespace Protocol
{
	// Token: 0x02000B82 RID: 2946
	[Protocol]
	public class WorldSyncTeamMemberStatus : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007CED RID: 31981 RVA: 0x0016437C File Offset: 0x0016277C
		public uint GetMsgID()
		{
			return 601605U;
		}

		// Token: 0x06007CEE RID: 31982 RVA: 0x00164383 File Offset: 0x00162783
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007CEF RID: 31983 RVA: 0x0016438B File Offset: 0x0016278B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007CF0 RID: 31984 RVA: 0x00164394 File Offset: 0x00162794
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.statusMask);
		}

		// Token: 0x06007CF1 RID: 31985 RVA: 0x001643B2 File Offset: 0x001627B2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.statusMask);
		}

		// Token: 0x06007CF2 RID: 31986 RVA: 0x001643D0 File Offset: 0x001627D0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.statusMask);
		}

		// Token: 0x06007CF3 RID: 31987 RVA: 0x001643EE File Offset: 0x001627EE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.statusMask);
		}

		// Token: 0x06007CF4 RID: 31988 RVA: 0x0016440C File Offset: 0x0016280C
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x04003B40 RID: 15168
		public const uint MsgID = 601605U;

		// Token: 0x04003B41 RID: 15169
		public uint Sequence;

		// Token: 0x04003B42 RID: 15170
		public ulong id;

		// Token: 0x04003B43 RID: 15171
		public byte statusMask;
	}
}
