using System;

namespace Protocol
{
	// Token: 0x020007E4 RID: 2020
	[Protocol]
	public class WorldDungeonEnterRaceRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600616F RID: 24943 RVA: 0x00123D24 File Offset: 0x00122124
		public uint GetMsgID()
		{
			return 606810U;
		}

		// Token: 0x06006170 RID: 24944 RVA: 0x00123D2B File Offset: 0x0012212B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006171 RID: 24945 RVA: 0x00123D33 File Offset: 0x00122133
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006172 RID: 24946 RVA: 0x00123D3C File Offset: 0x0012213C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006173 RID: 24947 RVA: 0x00123D4C File Offset: 0x0012214C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006174 RID: 24948 RVA: 0x00123D5C File Offset: 0x0012215C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006175 RID: 24949 RVA: 0x00123D6C File Offset: 0x0012216C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006176 RID: 24950 RVA: 0x00123D7C File Offset: 0x0012217C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002898 RID: 10392
		public const uint MsgID = 606810U;

		// Token: 0x04002899 RID: 10393
		public uint Sequence;

		// Token: 0x0400289A RID: 10394
		public uint result;
	}
}
