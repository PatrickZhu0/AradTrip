using System;

namespace Protocol
{
	// Token: 0x020009B5 RID: 2485
	[Protocol]
	public class WorldGetSysRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006FA6 RID: 28582 RVA: 0x001420E8 File Offset: 0x001404E8
		public uint GetMsgID()
		{
			return 600907U;
		}

		// Token: 0x06006FA7 RID: 28583 RVA: 0x001420EF File Offset: 0x001404EF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006FA8 RID: 28584 RVA: 0x001420F7 File Offset: 0x001404F7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006FA9 RID: 28585 RVA: 0x00142100 File Offset: 0x00140500
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.behavoir);
			BaseDLL.encode_uint32(buffer, ref pos_, this.role);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x06006FAA RID: 28586 RVA: 0x0014212C File Offset: 0x0014052C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.behavoir);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.role);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06006FAB RID: 28587 RVA: 0x00142158 File Offset: 0x00140558
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.behavoir);
			BaseDLL.encode_uint32(buffer, ref pos_, this.role);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x06006FAC RID: 28588 RVA: 0x00142184 File Offset: 0x00140584
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.behavoir);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.role);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06006FAD RID: 28589 RVA: 0x001421B0 File Offset: 0x001405B0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040032A5 RID: 12965
		public const uint MsgID = 600907U;

		// Token: 0x040032A6 RID: 12966
		public uint Sequence;

		// Token: 0x040032A7 RID: 12967
		public uint behavoir;

		// Token: 0x040032A8 RID: 12968
		public uint role;

		// Token: 0x040032A9 RID: 12969
		public uint param;
	}
}
