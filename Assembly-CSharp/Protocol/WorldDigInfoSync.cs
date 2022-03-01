using System;

namespace Protocol
{
	// Token: 0x02000794 RID: 1940
	[Protocol]
	public class WorldDigInfoSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F08 RID: 24328 RVA: 0x0011D13F File Offset: 0x0011B53F
		public uint GetMsgID()
		{
			return 608201U;
		}

		// Token: 0x06005F09 RID: 24329 RVA: 0x0011D146 File Offset: 0x0011B546
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F0A RID: 24330 RVA: 0x0011D14E File Offset: 0x0011B54E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F0B RID: 24331 RVA: 0x0011D157 File Offset: 0x0011B557
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06005F0C RID: 24332 RVA: 0x0011D174 File Offset: 0x0011B574
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06005F0D RID: 24333 RVA: 0x0011D191 File Offset: 0x0011B591
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06005F0E RID: 24334 RVA: 0x0011D1AE File Offset: 0x0011B5AE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06005F0F RID: 24335 RVA: 0x0011D1CC File Offset: 0x0011B5CC
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.info.getLen();
		}

		// Token: 0x04002737 RID: 10039
		public const uint MsgID = 608201U;

		// Token: 0x04002738 RID: 10040
		public uint Sequence;

		// Token: 0x04002739 RID: 10041
		public uint mapId;

		// Token: 0x0400273A RID: 10042
		public DigInfo info = new DigInfo();
	}
}
