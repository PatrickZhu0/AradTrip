using System;

namespace Protocol
{
	// Token: 0x02000A3D RID: 2621
	[Protocol]
	public class SceneArtifactJarDiscountInfoSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600738A RID: 29578 RVA: 0x0014F5E4 File Offset: 0x0014D9E4
		public uint GetMsgID()
		{
			return 507403U;
		}

		// Token: 0x0600738B RID: 29579 RVA: 0x0014F5EB File Offset: 0x0014D9EB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600738C RID: 29580 RVA: 0x0014F5F3 File Offset: 0x0014D9F3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600738D RID: 29581 RVA: 0x0014F5FC File Offset: 0x0014D9FC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_int8(buffer, ref pos_, this.extractDiscountStatus);
			BaseDLL.encode_uint32(buffer, ref pos_, this.discountRate);
			BaseDLL.encode_uint32(buffer, ref pos_, this.discountEffectTimes);
		}

		// Token: 0x0600738E RID: 29582 RVA: 0x0014F636 File Offset: 0x0014DA36
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.extractDiscountStatus);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discountRate);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discountEffectTimes);
		}

		// Token: 0x0600738F RID: 29583 RVA: 0x0014F670 File Offset: 0x0014DA70
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_int8(buffer, ref pos_, this.extractDiscountStatus);
			BaseDLL.encode_uint32(buffer, ref pos_, this.discountRate);
			BaseDLL.encode_uint32(buffer, ref pos_, this.discountEffectTimes);
		}

		// Token: 0x06007390 RID: 29584 RVA: 0x0014F6AA File Offset: 0x0014DAAA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.extractDiscountStatus);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discountRate);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discountEffectTimes);
		}

		// Token: 0x06007391 RID: 29585 RVA: 0x0014F6E4 File Offset: 0x0014DAE4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400359E RID: 13726
		public const uint MsgID = 507403U;

		// Token: 0x0400359F RID: 13727
		public uint Sequence;

		// Token: 0x040035A0 RID: 13728
		public uint opActId;

		// Token: 0x040035A1 RID: 13729
		public byte extractDiscountStatus;

		// Token: 0x040035A2 RID: 13730
		public uint discountRate;

		// Token: 0x040035A3 RID: 13731
		public uint discountEffectTimes;
	}
}
