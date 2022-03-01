using System;

namespace Protocol
{
	// Token: 0x020009D7 RID: 2519
	[Protocol]
	public class WorldNotifyGameStartTime : IProtocolStream, IGetMsgID
	{
		// Token: 0x060070B7 RID: 28855 RVA: 0x00145CC0 File Offset: 0x001440C0
		public uint GetMsgID()
		{
			return 604401U;
		}

		// Token: 0x060070B8 RID: 28856 RVA: 0x00145CC7 File Offset: 0x001440C7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060070B9 RID: 28857 RVA: 0x00145CCF File Offset: 0x001440CF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060070BA RID: 28858 RVA: 0x00145CD8 File Offset: 0x001440D8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
		}

		// Token: 0x060070BB RID: 28859 RVA: 0x00145CE8 File Offset: 0x001440E8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
		}

		// Token: 0x060070BC RID: 28860 RVA: 0x00145CF8 File Offset: 0x001440F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
		}

		// Token: 0x060070BD RID: 28861 RVA: 0x00145D08 File Offset: 0x00144108
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
		}

		// Token: 0x060070BE RID: 28862 RVA: 0x00145D18 File Offset: 0x00144118
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003356 RID: 13142
		public const uint MsgID = 604401U;

		// Token: 0x04003357 RID: 13143
		public uint Sequence;

		// Token: 0x04003358 RID: 13144
		public uint time;
	}
}
