using System;

namespace Protocol
{
	// Token: 0x020007E7 RID: 2023
	[Protocol]
	public class WorldDungeonGetAreaIndexRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600618A RID: 24970 RVA: 0x00124100 File Offset: 0x00122500
		public uint GetMsgID()
		{
			return 606816U;
		}

		// Token: 0x0600618B RID: 24971 RVA: 0x00124107 File Offset: 0x00122507
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600618C RID: 24972 RVA: 0x0012410F File Offset: 0x0012250F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600618D RID: 24973 RVA: 0x00124118 File Offset: 0x00122518
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.areaIndex);
		}

		// Token: 0x0600618E RID: 24974 RVA: 0x00124136 File Offset: 0x00122536
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.areaIndex);
		}

		// Token: 0x0600618F RID: 24975 RVA: 0x00124154 File Offset: 0x00122554
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.areaIndex);
		}

		// Token: 0x06006190 RID: 24976 RVA: 0x00124172 File Offset: 0x00122572
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.areaIndex);
		}

		// Token: 0x06006191 RID: 24977 RVA: 0x00124190 File Offset: 0x00122590
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040028A2 RID: 10402
		public const uint MsgID = 606816U;

		// Token: 0x040028A3 RID: 10403
		public uint Sequence;

		// Token: 0x040028A4 RID: 10404
		public uint dungeonId;

		// Token: 0x040028A5 RID: 10405
		public uint areaIndex;
	}
}
