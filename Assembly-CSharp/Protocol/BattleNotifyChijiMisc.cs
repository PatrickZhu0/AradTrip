using System;

namespace Protocol
{
	// Token: 0x02000728 RID: 1832
	[Protocol]
	public class BattleNotifyChijiMisc : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005BD8 RID: 23512 RVA: 0x00115ADF File Offset: 0x00113EDF
		public uint GetMsgID()
		{
			return 2200022U;
		}

		// Token: 0x06005BD9 RID: 23513 RVA: 0x00115AE6 File Offset: 0x00113EE6
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005BDA RID: 23514 RVA: 0x00115AEE File Offset: 0x00113EEE
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005BDB RID: 23515 RVA: 0x00115AF7 File Offset: 0x00113EF7
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.moveIntervalMs);
		}

		// Token: 0x06005BDC RID: 23516 RVA: 0x00115B07 File Offset: 0x00113F07
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.moveIntervalMs);
		}

		// Token: 0x06005BDD RID: 23517 RVA: 0x00115B17 File Offset: 0x00113F17
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.moveIntervalMs);
		}

		// Token: 0x06005BDE RID: 23518 RVA: 0x00115B27 File Offset: 0x00113F27
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.moveIntervalMs);
		}

		// Token: 0x06005BDF RID: 23519 RVA: 0x00115B38 File Offset: 0x00113F38
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400256B RID: 9579
		public const uint MsgID = 2200022U;

		// Token: 0x0400256C RID: 9580
		public uint Sequence;

		// Token: 0x0400256D RID: 9581
		public uint moveIntervalMs;
	}
}
