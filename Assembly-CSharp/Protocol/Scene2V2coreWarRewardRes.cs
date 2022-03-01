using System;

namespace Protocol
{
	// Token: 0x02000668 RID: 1640
	[Protocol]
	public class Scene2V2coreWarRewardRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060055F4 RID: 22004 RVA: 0x0010777C File Offset: 0x00105B7C
		public uint GetMsgID()
		{
			return 509604U;
		}

		// Token: 0x060055F5 RID: 22005 RVA: 0x00107783 File Offset: 0x00105B83
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060055F6 RID: 22006 RVA: 0x0010778B File Offset: 0x00105B8B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060055F7 RID: 22007 RVA: 0x00107794 File Offset: 0x00105B94
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060055F8 RID: 22008 RVA: 0x001077A4 File Offset: 0x00105BA4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060055F9 RID: 22009 RVA: 0x001077B4 File Offset: 0x00105BB4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060055FA RID: 22010 RVA: 0x001077C4 File Offset: 0x00105BC4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060055FB RID: 22011 RVA: 0x001077D4 File Offset: 0x00105BD4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040021FE RID: 8702
		public const uint MsgID = 509604U;

		// Token: 0x040021FF RID: 8703
		public uint Sequence;

		// Token: 0x04002200 RID: 8704
		public uint result;
	}
}
