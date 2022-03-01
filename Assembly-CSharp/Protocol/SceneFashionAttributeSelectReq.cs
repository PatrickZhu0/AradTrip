using System;

namespace Protocol
{
	// Token: 0x02000929 RID: 2345
	[Protocol]
	public class SceneFashionAttributeSelectReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006ADE RID: 27358 RVA: 0x0013942C File Offset: 0x0013782C
		public uint GetMsgID()
		{
			return 500958U;
		}

		// Token: 0x06006ADF RID: 27359 RVA: 0x00139433 File Offset: 0x00137833
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006AE0 RID: 27360 RVA: 0x0013943B File Offset: 0x0013783B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006AE1 RID: 27361 RVA: 0x00139444 File Offset: 0x00137844
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_int32(buffer, ref pos_, this.attributeId);
		}

		// Token: 0x06006AE2 RID: 27362 RVA: 0x00139462 File Offset: 0x00137862
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.attributeId);
		}

		// Token: 0x06006AE3 RID: 27363 RVA: 0x00139480 File Offset: 0x00137880
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_int32(buffer, ref pos_, this.attributeId);
		}

		// Token: 0x06006AE4 RID: 27364 RVA: 0x0013949E File Offset: 0x0013789E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.attributeId);
		}

		// Token: 0x06006AE5 RID: 27365 RVA: 0x001394BC File Offset: 0x001378BC
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x04003077 RID: 12407
		public const uint MsgID = 500958U;

		// Token: 0x04003078 RID: 12408
		public uint Sequence;

		// Token: 0x04003079 RID: 12409
		public ulong guid;

		// Token: 0x0400307A RID: 12410
		public int attributeId;
	}
}
