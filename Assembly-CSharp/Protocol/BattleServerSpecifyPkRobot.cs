using System;

namespace Protocol
{
	// Token: 0x02000702 RID: 1794
	[Protocol]
	public class BattleServerSpecifyPkRobot : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A8B RID: 23179 RVA: 0x0011365C File Offset: 0x00111A5C
		public uint GetMsgID()
		{
			return 2200011U;
		}

		// Token: 0x06005A8C RID: 23180 RVA: 0x00113663 File Offset: 0x00111A63
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A8D RID: 23181 RVA: 0x0011366B File Offset: 0x00111A6B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A8E RID: 23182 RVA: 0x00113674 File Offset: 0x00111A74
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.hard);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_int8(buffer, ref pos_, this.ai);
		}

		// Token: 0x06005A8F RID: 23183 RVA: 0x001136A0 File Offset: 0x00111AA0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hard);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.ai);
		}

		// Token: 0x06005A90 RID: 23184 RVA: 0x001136CC File Offset: 0x00111ACC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.hard);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_int8(buffer, ref pos_, this.ai);
		}

		// Token: 0x06005A91 RID: 23185 RVA: 0x001136F8 File Offset: 0x00111AF8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hard);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.ai);
		}

		// Token: 0x06005A92 RID: 23186 RVA: 0x00113724 File Offset: 0x00111B24
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			return num + 1;
		}

		// Token: 0x040024CE RID: 9422
		public const uint MsgID = 2200011U;

		// Token: 0x040024CF RID: 9423
		public uint Sequence;

		// Token: 0x040024D0 RID: 9424
		public byte hard;

		// Token: 0x040024D1 RID: 9425
		public byte occu;

		// Token: 0x040024D2 RID: 9426
		public byte ai;
	}
}
