using System;

namespace Protocol
{
	// Token: 0x02000A01 RID: 2561
	[Protocol]
	public class SceneWudaoJoinRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060071D1 RID: 29137 RVA: 0x0014A958 File Offset: 0x00148D58
		public uint GetMsgID()
		{
			return 506707U;
		}

		// Token: 0x060071D2 RID: 29138 RVA: 0x0014A95F File Offset: 0x00148D5F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060071D3 RID: 29139 RVA: 0x0014A967 File Offset: 0x00148D67
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060071D4 RID: 29140 RVA: 0x0014A970 File Offset: 0x00148D70
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060071D5 RID: 29141 RVA: 0x0014A980 File Offset: 0x00148D80
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060071D6 RID: 29142 RVA: 0x0014A990 File Offset: 0x00148D90
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060071D7 RID: 29143 RVA: 0x0014A9A0 File Offset: 0x00148DA0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060071D8 RID: 29144 RVA: 0x0014A9B0 File Offset: 0x00148DB0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003456 RID: 13398
		public const uint MsgID = 506707U;

		// Token: 0x04003457 RID: 13399
		public uint Sequence;

		// Token: 0x04003458 RID: 13400
		public uint result;
	}
}
