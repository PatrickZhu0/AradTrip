using System;

namespace Protocol
{
	// Token: 0x0200070B RID: 1803
	[Protocol]
	public class SceneBattleNotifyWaveInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005AD9 RID: 23257 RVA: 0x00113F85 File Offset: 0x00112385
		public uint GetMsgID()
		{
			return 508918U;
		}

		// Token: 0x06005ADA RID: 23258 RVA: 0x00113F8C File Offset: 0x0011238C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005ADB RID: 23259 RVA: 0x00113F94 File Offset: 0x00112394
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005ADC RID: 23260 RVA: 0x00113F9D File Offset: 0x0011239D
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.waveID);
		}

		// Token: 0x06005ADD RID: 23261 RVA: 0x00113FBB File Offset: 0x001123BB
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.waveID);
		}

		// Token: 0x06005ADE RID: 23262 RVA: 0x00113FD9 File Offset: 0x001123D9
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.waveID);
		}

		// Token: 0x06005ADF RID: 23263 RVA: 0x00113FF7 File Offset: 0x001123F7
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.waveID);
		}

		// Token: 0x06005AE0 RID: 23264 RVA: 0x00114018 File Offset: 0x00112418
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040024F7 RID: 9463
		public const uint MsgID = 508918U;

		// Token: 0x040024F8 RID: 9464
		public uint Sequence;

		// Token: 0x040024F9 RID: 9465
		public uint battleID;

		// Token: 0x040024FA RID: 9466
		public uint waveID;
	}
}
