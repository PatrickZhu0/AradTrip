using System;

namespace Protocol
{
	// Token: 0x020007C1 RID: 1985
	[Protocol]
	public class SceneDungeonEnterNextAreaRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600603A RID: 24634 RVA: 0x00121106 File Offset: 0x0011F506
		public uint GetMsgID()
		{
			return 506808U;
		}

		// Token: 0x0600603B RID: 24635 RVA: 0x0012110D File Offset: 0x0011F50D
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600603C RID: 24636 RVA: 0x00121115 File Offset: 0x0011F515
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600603D RID: 24637 RVA: 0x0012111E File Offset: 0x0011F51E
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.areaId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600603E RID: 24638 RVA: 0x0012113C File Offset: 0x0011F53C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.areaId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600603F RID: 24639 RVA: 0x0012115A File Offset: 0x0011F55A
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.areaId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006040 RID: 24640 RVA: 0x00121178 File Offset: 0x0011F578
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.areaId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006041 RID: 24641 RVA: 0x00121198 File Offset: 0x0011F598
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040027FE RID: 10238
		public const uint MsgID = 506808U;

		// Token: 0x040027FF RID: 10239
		public uint Sequence;

		// Token: 0x04002800 RID: 10240
		public uint areaId;

		// Token: 0x04002801 RID: 10241
		public uint result;
	}
}
