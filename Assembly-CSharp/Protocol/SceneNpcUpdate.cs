using System;

namespace Protocol
{
	// Token: 0x02000B0F RID: 2831
	[Protocol]
	public class SceneNpcUpdate : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600799F RID: 31135 RVA: 0x0015DF1A File Offset: 0x0015C31A
		public uint GetMsgID()
		{
			return 500624U;
		}

		// Token: 0x060079A0 RID: 31136 RVA: 0x0015DF21 File Offset: 0x0015C321
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060079A1 RID: 31137 RVA: 0x0015DF29 File Offset: 0x0015C329
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060079A2 RID: 31138 RVA: 0x0015DF32 File Offset: 0x0015C332
		public void encode(byte[] buffer, ref int pos_)
		{
			this.data.encode(buffer, ref pos_);
		}

		// Token: 0x060079A3 RID: 31139 RVA: 0x0015DF41 File Offset: 0x0015C341
		public void decode(byte[] buffer, ref int pos_)
		{
			this.data.decode(buffer, ref pos_);
		}

		// Token: 0x060079A4 RID: 31140 RVA: 0x0015DF50 File Offset: 0x0015C350
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.data.encode(buffer, ref pos_);
		}

		// Token: 0x060079A5 RID: 31141 RVA: 0x0015DF5F File Offset: 0x0015C35F
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.data.decode(buffer, ref pos_);
		}

		// Token: 0x060079A6 RID: 31142 RVA: 0x0015DF70 File Offset: 0x0015C370
		public int getLen()
		{
			int num = 0;
			return num + this.data.getLen();
		}

		// Token: 0x04003960 RID: 14688
		public const uint MsgID = 500624U;

		// Token: 0x04003961 RID: 14689
		public uint Sequence;

		// Token: 0x04003962 RID: 14690
		public SceneNpcInfo data = new SceneNpcInfo();
	}
}
