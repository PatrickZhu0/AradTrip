using System;

namespace Protocol
{
	// Token: 0x02000C67 RID: 3175
	[Protocol]
	public class SceneSubmitLegendTask : IProtocolStream, IGetMsgID
	{
		// Token: 0x060083AA RID: 33706 RVA: 0x00171C8D File Offset: 0x0017008D
		public uint GetMsgID()
		{
			return 501115U;
		}

		// Token: 0x060083AB RID: 33707 RVA: 0x00171C94 File Offset: 0x00170094
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060083AC RID: 33708 RVA: 0x00171C9C File Offset: 0x0017009C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060083AD RID: 33709 RVA: 0x00171CA5 File Offset: 0x001700A5
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
		}

		// Token: 0x060083AE RID: 33710 RVA: 0x00171CB5 File Offset: 0x001700B5
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
		}

		// Token: 0x060083AF RID: 33711 RVA: 0x00171CC5 File Offset: 0x001700C5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
		}

		// Token: 0x060083B0 RID: 33712 RVA: 0x00171CD5 File Offset: 0x001700D5
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
		}

		// Token: 0x060083B1 RID: 33713 RVA: 0x00171CE8 File Offset: 0x001700E8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003EEE RID: 16110
		public const uint MsgID = 501115U;

		// Token: 0x04003EEF RID: 16111
		public uint Sequence;

		// Token: 0x04003EF0 RID: 16112
		public uint taskId;
	}
}
