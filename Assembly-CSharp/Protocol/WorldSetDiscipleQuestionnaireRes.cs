using System;

namespace Protocol
{
	// Token: 0x02000CAC RID: 3244
	[Protocol]
	public class WorldSetDiscipleQuestionnaireRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060085C3 RID: 34243 RVA: 0x00176C98 File Offset: 0x00175098
		public uint GetMsgID()
		{
			return 601740U;
		}

		// Token: 0x060085C4 RID: 34244 RVA: 0x00176C9F File Offset: 0x0017509F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060085C5 RID: 34245 RVA: 0x00176CA7 File Offset: 0x001750A7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060085C6 RID: 34246 RVA: 0x00176CB0 File Offset: 0x001750B0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x060085C7 RID: 34247 RVA: 0x00176CC0 File Offset: 0x001750C0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x060085C8 RID: 34248 RVA: 0x00176CD0 File Offset: 0x001750D0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x060085C9 RID: 34249 RVA: 0x00176CE0 File Offset: 0x001750E0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x060085CA RID: 34250 RVA: 0x00176CF0 File Offset: 0x001750F0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04004013 RID: 16403
		public const uint MsgID = 601740U;

		// Token: 0x04004014 RID: 16404
		public uint Sequence;

		// Token: 0x04004015 RID: 16405
		public uint code;
	}
}
