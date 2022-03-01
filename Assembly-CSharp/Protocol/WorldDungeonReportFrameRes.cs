using System;

namespace Protocol
{
	// Token: 0x020007E8 RID: 2024
	[Protocol]
	public class WorldDungeonReportFrameRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006193 RID: 24979 RVA: 0x001241B0 File Offset: 0x001225B0
		public uint GetMsgID()
		{
			return 606812U;
		}

		// Token: 0x06006194 RID: 24980 RVA: 0x001241B7 File Offset: 0x001225B7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006195 RID: 24981 RVA: 0x001241BF File Offset: 0x001225BF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006196 RID: 24982 RVA: 0x001241C8 File Offset: 0x001225C8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastFrame);
		}

		// Token: 0x06006197 RID: 24983 RVA: 0x001241D8 File Offset: 0x001225D8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastFrame);
		}

		// Token: 0x06006198 RID: 24984 RVA: 0x001241E8 File Offset: 0x001225E8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastFrame);
		}

		// Token: 0x06006199 RID: 24985 RVA: 0x001241F8 File Offset: 0x001225F8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastFrame);
		}

		// Token: 0x0600619A RID: 24986 RVA: 0x00124208 File Offset: 0x00122608
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040028A6 RID: 10406
		public const uint MsgID = 606812U;

		// Token: 0x040028A7 RID: 10407
		public uint Sequence;

		// Token: 0x040028A8 RID: 10408
		public uint lastFrame;
	}
}
