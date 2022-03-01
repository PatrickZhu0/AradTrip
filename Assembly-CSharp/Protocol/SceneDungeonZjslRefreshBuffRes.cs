using System;

namespace Protocol
{
	// Token: 0x020007EA RID: 2026
	[Protocol]
	public class SceneDungeonZjslRefreshBuffRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060061A5 RID: 24997 RVA: 0x001242D4 File Offset: 0x001226D4
		public uint GetMsgID()
		{
			return 506836U;
		}

		// Token: 0x060061A6 RID: 24998 RVA: 0x001242DB File Offset: 0x001226DB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060061A7 RID: 24999 RVA: 0x001242E3 File Offset: 0x001226E3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060061A8 RID: 25000 RVA: 0x001242EC File Offset: 0x001226EC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060061A9 RID: 25001 RVA: 0x001242FC File Offset: 0x001226FC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060061AA RID: 25002 RVA: 0x0012430C File Offset: 0x0012270C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060061AB RID: 25003 RVA: 0x0012431C File Offset: 0x0012271C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060061AC RID: 25004 RVA: 0x0012432C File Offset: 0x0012272C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040028AD RID: 10413
		public const uint MsgID = 506836U;

		// Token: 0x040028AE RID: 10414
		public uint Sequence;

		// Token: 0x040028AF RID: 10415
		public uint result;
	}
}
