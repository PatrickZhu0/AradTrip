using System;

namespace Protocol
{
	// Token: 0x02000AAB RID: 2731
	[Protocol]
	public class SceneReplayListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060076C3 RID: 30403 RVA: 0x001575CD File Offset: 0x001559CD
		public uint GetMsgID()
		{
			return 507501U;
		}

		// Token: 0x060076C4 RID: 30404 RVA: 0x001575D4 File Offset: 0x001559D4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060076C5 RID: 30405 RVA: 0x001575DC File Offset: 0x001559DC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060076C6 RID: 30406 RVA: 0x001575E5 File Offset: 0x001559E5
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x060076C7 RID: 30407 RVA: 0x001575F5 File Offset: 0x001559F5
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x060076C8 RID: 30408 RVA: 0x00157605 File Offset: 0x00155A05
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x060076C9 RID: 30409 RVA: 0x00157615 File Offset: 0x00155A15
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x060076CA RID: 30410 RVA: 0x00157628 File Offset: 0x00155A28
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003797 RID: 14231
		public const uint MsgID = 507501U;

		// Token: 0x04003798 RID: 14232
		public uint Sequence;

		// Token: 0x04003799 RID: 14233
		public byte type;
	}
}
