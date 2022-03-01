using System;

namespace Protocol
{
	// Token: 0x02000B69 RID: 2921
	[Protocol]
	public class WorldSortListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C54 RID: 31828 RVA: 0x001631E4 File Offset: 0x001615E4
		public uint GetMsgID()
		{
			return 602601U;
		}

		// Token: 0x06007C55 RID: 31829 RVA: 0x001631EB File Offset: 0x001615EB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C56 RID: 31830 RVA: 0x001631F3 File Offset: 0x001615F3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C57 RID: 31831 RVA: 0x001631FC File Offset: 0x001615FC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.start);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06007C58 RID: 31832 RVA: 0x00163236 File Offset: 0x00161636
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.start);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06007C59 RID: 31833 RVA: 0x00163270 File Offset: 0x00161670
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.start);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06007C5A RID: 31834 RVA: 0x001632AA File Offset: 0x001616AA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.start);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06007C5B RID: 31835 RVA: 0x001632E4 File Offset: 0x001616E4
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num += 2;
			return num + 2;
		}

		// Token: 0x04003AE2 RID: 15074
		public const uint MsgID = 602601U;

		// Token: 0x04003AE3 RID: 15075
		public uint Sequence;

		// Token: 0x04003AE4 RID: 15076
		public byte type;

		// Token: 0x04003AE5 RID: 15077
		public byte occu;

		// Token: 0x04003AE6 RID: 15078
		public ushort start;

		// Token: 0x04003AE7 RID: 15079
		public ushort num;
	}
}
