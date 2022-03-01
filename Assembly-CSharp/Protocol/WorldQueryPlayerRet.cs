using System;

namespace Protocol
{
	// Token: 0x02000C8F RID: 3215
	[Protocol]
	public class WorldQueryPlayerRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060084C1 RID: 33985 RVA: 0x00174F23 File Offset: 0x00173323
		public uint GetMsgID()
		{
			return 601702U;
		}

		// Token: 0x060084C2 RID: 33986 RVA: 0x00174F2A File Offset: 0x0017332A
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060084C3 RID: 33987 RVA: 0x00174F32 File Offset: 0x00173332
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060084C4 RID: 33988 RVA: 0x00174F3B File Offset: 0x0017333B
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.queryType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x060084C5 RID: 33989 RVA: 0x00174F66 File Offset: 0x00173366
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.queryType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneId);
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x060084C6 RID: 33990 RVA: 0x00174F91 File Offset: 0x00173391
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.queryType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x060084C7 RID: 33991 RVA: 0x00174FBC File Offset: 0x001733BC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.queryType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneId);
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x060084C8 RID: 33992 RVA: 0x00174FE8 File Offset: 0x001733E8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + this.info.getLen();
		}

		// Token: 0x04003FA9 RID: 16297
		public const uint MsgID = 601702U;

		// Token: 0x04003FAA RID: 16298
		public uint Sequence;

		// Token: 0x04003FAB RID: 16299
		public uint queryType;

		// Token: 0x04003FAC RID: 16300
		public uint zoneId;

		// Token: 0x04003FAD RID: 16301
		public PlayerWatchInfo info = new PlayerWatchInfo();
	}
}
