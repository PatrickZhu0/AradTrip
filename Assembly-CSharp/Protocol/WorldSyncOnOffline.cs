using System;

namespace Protocol
{
	// Token: 0x02000C92 RID: 3218
	[Protocol]
	public class WorldSyncOnOffline : IProtocolStream, IGetMsgID
	{
		// Token: 0x060084DC RID: 34012 RVA: 0x00175114 File Offset: 0x00173514
		public uint GetMsgID()
		{
			return 601713U;
		}

		// Token: 0x060084DD RID: 34013 RVA: 0x0017511B File Offset: 0x0017351B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060084DE RID: 34014 RVA: 0x00175123 File Offset: 0x00173523
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060084DF RID: 34015 RVA: 0x0017512C File Offset: 0x0017352C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.isOnline);
		}

		// Token: 0x060084E0 RID: 34016 RVA: 0x0017514A File Offset: 0x0017354A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isOnline);
		}

		// Token: 0x060084E1 RID: 34017 RVA: 0x00175168 File Offset: 0x00173568
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.isOnline);
		}

		// Token: 0x060084E2 RID: 34018 RVA: 0x00175186 File Offset: 0x00173586
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isOnline);
		}

		// Token: 0x060084E3 RID: 34019 RVA: 0x001751A4 File Offset: 0x001735A4
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x04003FB4 RID: 16308
		public const uint MsgID = 601713U;

		// Token: 0x04003FB5 RID: 16309
		public uint Sequence;

		// Token: 0x04003FB6 RID: 16310
		public ulong id;

		// Token: 0x04003FB7 RID: 16311
		public byte isOnline;
	}
}
