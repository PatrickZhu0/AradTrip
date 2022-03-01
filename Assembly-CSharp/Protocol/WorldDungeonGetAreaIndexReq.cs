using System;

namespace Protocol
{
	// Token: 0x020007E6 RID: 2022
	[Protocol]
	public class WorldDungeonGetAreaIndexReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006181 RID: 24961 RVA: 0x0012408A File Offset: 0x0012248A
		public uint GetMsgID()
		{
			return 606815U;
		}

		// Token: 0x06006182 RID: 24962 RVA: 0x00124091 File Offset: 0x00122491
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006183 RID: 24963 RVA: 0x00124099 File Offset: 0x00122499
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006184 RID: 24964 RVA: 0x001240A2 File Offset: 0x001224A2
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
		}

		// Token: 0x06006185 RID: 24965 RVA: 0x001240B2 File Offset: 0x001224B2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
		}

		// Token: 0x06006186 RID: 24966 RVA: 0x001240C2 File Offset: 0x001224C2
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
		}

		// Token: 0x06006187 RID: 24967 RVA: 0x001240D2 File Offset: 0x001224D2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
		}

		// Token: 0x06006188 RID: 24968 RVA: 0x001240E4 File Offset: 0x001224E4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400289F RID: 10399
		public const uint MsgID = 606815U;

		// Token: 0x040028A0 RID: 10400
		public uint Sequence;

		// Token: 0x040028A1 RID: 10401
		public uint dungeonId;
	}
}
