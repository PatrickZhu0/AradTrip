using System;

namespace Protocol
{
	// Token: 0x02000C20 RID: 3104
	[Protocol]
	public class SceneWarpStoneChargeRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060081A0 RID: 33184 RVA: 0x0016DCD5 File Offset: 0x0016C0D5
		public uint GetMsgID()
		{
			return 506904U;
		}

		// Token: 0x060081A1 RID: 33185 RVA: 0x0016DCDC File Offset: 0x0016C0DC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060081A2 RID: 33186 RVA: 0x0016DCE4 File Offset: 0x0016C0E4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060081A3 RID: 33187 RVA: 0x0016DCED File Offset: 0x0016C0ED
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060081A4 RID: 33188 RVA: 0x0016DCFD File Offset: 0x0016C0FD
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060081A5 RID: 33189 RVA: 0x0016DD0D File Offset: 0x0016C10D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060081A6 RID: 33190 RVA: 0x0016DD1D File Offset: 0x0016C11D
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060081A7 RID: 33191 RVA: 0x0016DD30 File Offset: 0x0016C130
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003DDD RID: 15837
		public const uint MsgID = 506904U;

		// Token: 0x04003DDE RID: 15838
		public uint Sequence;

		// Token: 0x04003DDF RID: 15839
		public uint result;
	}
}
