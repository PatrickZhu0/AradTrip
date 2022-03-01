using System;

namespace Protocol
{
	// Token: 0x02000A80 RID: 2688
	[Protocol]
	public class WorldNotifySyncRedPacketStatus : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600758E RID: 30094 RVA: 0x001543F7 File Offset: 0x001527F7
		public uint GetMsgID()
		{
			return 607305U;
		}

		// Token: 0x0600758F RID: 30095 RVA: 0x001543FE File Offset: 0x001527FE
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007590 RID: 30096 RVA: 0x00154406 File Offset: 0x00152806
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007591 RID: 30097 RVA: 0x0015440F File Offset: 0x0015280F
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
		}

		// Token: 0x06007592 RID: 30098 RVA: 0x0015442D File Offset: 0x0015282D
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
		}

		// Token: 0x06007593 RID: 30099 RVA: 0x0015444B File Offset: 0x0015284B
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
		}

		// Token: 0x06007594 RID: 30100 RVA: 0x00154469 File Offset: 0x00152869
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
		}

		// Token: 0x06007595 RID: 30101 RVA: 0x00154488 File Offset: 0x00152888
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x040036BD RID: 14013
		public const uint MsgID = 607305U;

		// Token: 0x040036BE RID: 14014
		public uint Sequence;

		// Token: 0x040036BF RID: 14015
		public ulong id;

		// Token: 0x040036C0 RID: 14016
		public byte status;
	}
}
