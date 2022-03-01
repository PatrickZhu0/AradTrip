using System;

namespace Protocol
{
	// Token: 0x02000AB7 RID: 2743
	[Protocol]
	public class SceneChanageRetinueReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007714 RID: 30484 RVA: 0x0015872A File Offset: 0x00156B2A
		public uint GetMsgID()
		{
			return 507003U;
		}

		// Token: 0x06007715 RID: 30485 RVA: 0x00158731 File Offset: 0x00156B31
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007716 RID: 30486 RVA: 0x00158739 File Offset: 0x00156B39
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007717 RID: 30487 RVA: 0x00158742 File Offset: 0x00156B42
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
		}

		// Token: 0x06007718 RID: 30488 RVA: 0x00158760 File Offset: 0x00156B60
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
		}

		// Token: 0x06007719 RID: 30489 RVA: 0x0015877E File Offset: 0x00156B7E
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
		}

		// Token: 0x0600771A RID: 30490 RVA: 0x0015879C File Offset: 0x00156B9C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
		}

		// Token: 0x0600771B RID: 30491 RVA: 0x001587BC File Offset: 0x00156BBC
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x040037C3 RID: 14275
		public const uint MsgID = 507003U;

		// Token: 0x040037C4 RID: 14276
		public uint Sequence;

		// Token: 0x040037C5 RID: 14277
		public ulong id;

		// Token: 0x040037C6 RID: 14278
		public byte index;
	}
}
