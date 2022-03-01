using System;

namespace Protocol
{
	// Token: 0x020009E5 RID: 2533
	[Protocol]
	public class WorldDeleteMail : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007126 RID: 28966 RVA: 0x00146A76 File Offset: 0x00144E76
		public uint GetMsgID()
		{
			return 601510U;
		}

		// Token: 0x06007127 RID: 28967 RVA: 0x00146A7D File Offset: 0x00144E7D
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007128 RID: 28968 RVA: 0x00146A85 File Offset: 0x00144E85
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007129 RID: 28969 RVA: 0x00146A90 File Offset: 0x00144E90
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.ids.Length);
			for (int i = 0; i < this.ids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.ids[i]);
			}
		}

		// Token: 0x0600712A RID: 28970 RVA: 0x00146AD8 File Offset: 0x00144ED8
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.ids = new ulong[(int)num];
			for (int i = 0; i < this.ids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.ids[i]);
			}
		}

		// Token: 0x0600712B RID: 28971 RVA: 0x00146B2C File Offset: 0x00144F2C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.ids.Length);
			for (int i = 0; i < this.ids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.ids[i]);
			}
		}

		// Token: 0x0600712C RID: 28972 RVA: 0x00146B74 File Offset: 0x00144F74
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.ids = new ulong[(int)num];
			for (int i = 0; i < this.ids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.ids[i]);
			}
		}

		// Token: 0x0600712D RID: 28973 RVA: 0x00146BC8 File Offset: 0x00144FC8
		public int getLen()
		{
			int num = 0;
			return num + (2 + 8 * this.ids.Length);
		}

		// Token: 0x0400338F RID: 13199
		public const uint MsgID = 601510U;

		// Token: 0x04003390 RID: 13200
		public uint Sequence;

		// Token: 0x04003391 RID: 13201
		public ulong[] ids = new ulong[0];
	}
}
