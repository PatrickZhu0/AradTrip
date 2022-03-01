using System;

namespace Protocol
{
	// Token: 0x02000C1E RID: 3102
	[Protocol]
	public class SceneWarpStoneUnlockRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600818E RID: 33166 RVA: 0x0016DA7C File Offset: 0x0016BE7C
		public uint GetMsgID()
		{
			return 506902U;
		}

		// Token: 0x0600818F RID: 33167 RVA: 0x0016DA83 File Offset: 0x0016BE83
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008190 RID: 33168 RVA: 0x0016DA8B File Offset: 0x0016BE8B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008191 RID: 33169 RVA: 0x0016DA94 File Offset: 0x0016BE94
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06008192 RID: 33170 RVA: 0x0016DAA4 File Offset: 0x0016BEA4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06008193 RID: 33171 RVA: 0x0016DAB4 File Offset: 0x0016BEB4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06008194 RID: 33172 RVA: 0x0016DAC4 File Offset: 0x0016BEC4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06008195 RID: 33173 RVA: 0x0016DAD4 File Offset: 0x0016BED4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003DD6 RID: 15830
		public const uint MsgID = 506902U;

		// Token: 0x04003DD7 RID: 15831
		public uint Sequence;

		// Token: 0x04003DD8 RID: 15832
		public uint result;
	}
}
