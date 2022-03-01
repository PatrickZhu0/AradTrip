using System;

namespace Protocol
{
	// Token: 0x02000992 RID: 2450
	[Protocol]
	public class SceneEnhanceMaterialCombo : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E74 RID: 28276 RVA: 0x0013FBFC File Offset: 0x0013DFFC
		public uint GetMsgID()
		{
			return 501068U;
		}

		// Token: 0x06006E75 RID: 28277 RVA: 0x0013FC03 File Offset: 0x0013E003
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E76 RID: 28278 RVA: 0x0013FC0B File Offset: 0x0013E00B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E77 RID: 28279 RVA: 0x0013FC14 File Offset: 0x0013E014
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.goalId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goalNum);
		}

		// Token: 0x06006E78 RID: 28280 RVA: 0x0013FC32 File Offset: 0x0013E032
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goalId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goalNum);
		}

		// Token: 0x06006E79 RID: 28281 RVA: 0x0013FC50 File Offset: 0x0013E050
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.goalId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goalNum);
		}

		// Token: 0x06006E7A RID: 28282 RVA: 0x0013FC6E File Offset: 0x0013E06E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goalId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goalNum);
		}

		// Token: 0x06006E7B RID: 28283 RVA: 0x0013FC8C File Offset: 0x0013E08C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003209 RID: 12809
		public const uint MsgID = 501068U;

		// Token: 0x0400320A RID: 12810
		public uint Sequence;

		// Token: 0x0400320B RID: 12811
		public uint goalId;

		// Token: 0x0400320C RID: 12812
		public uint goalNum;
	}
}
