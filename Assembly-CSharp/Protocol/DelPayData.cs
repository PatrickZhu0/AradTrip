using System;

namespace Protocol
{
	// Token: 0x02000CA4 RID: 3236
	[Protocol]
	public class DelPayData : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600857B RID: 34171 RVA: 0x001767A6 File Offset: 0x00174BA6
		public uint GetMsgID()
		{
			return 501711U;
		}

		// Token: 0x0600857C RID: 34172 RVA: 0x001767AD File Offset: 0x00174BAD
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600857D RID: 34173 RVA: 0x001767B5 File Offset: 0x00174BB5
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600857E RID: 34174 RVA: 0x001767BE File Offset: 0x00174BBE
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x0600857F RID: 34175 RVA: 0x001767CE File Offset: 0x00174BCE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06008580 RID: 34176 RVA: 0x001767DE File Offset: 0x00174BDE
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06008581 RID: 34177 RVA: 0x001767EE File Offset: 0x00174BEE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06008582 RID: 34178 RVA: 0x00176800 File Offset: 0x00174C00
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003FFC RID: 16380
		public const uint MsgID = 501711U;

		// Token: 0x04003FFD RID: 16381
		public uint Sequence;

		// Token: 0x04003FFE RID: 16382
		public ulong id;
	}
}
