using System;

namespace Protocol
{
	// Token: 0x020006AA RID: 1706
	[Protocol]
	public class WorldQueryAllExpeditionMapsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600580D RID: 22541 RVA: 0x0010BF88 File Offset: 0x0010A388
		public uint GetMsgID()
		{
			return 608621U;
		}

		// Token: 0x0600580E RID: 22542 RVA: 0x0010BF8F File Offset: 0x0010A38F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600580F RID: 22543 RVA: 0x0010BF97 File Offset: 0x0010A397
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005810 RID: 22544 RVA: 0x0010BFA0 File Offset: 0x0010A3A0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mapIds.Length);
			for (int i = 0; i < this.mapIds.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.mapIds[i]);
			}
		}

		// Token: 0x06005811 RID: 22545 RVA: 0x0010BFE8 File Offset: 0x0010A3E8
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.mapIds = new byte[(int)num];
			for (int i = 0; i < this.mapIds.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.mapIds[i]);
			}
		}

		// Token: 0x06005812 RID: 22546 RVA: 0x0010C03C File Offset: 0x0010A43C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mapIds.Length);
			for (int i = 0; i < this.mapIds.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.mapIds[i]);
			}
		}

		// Token: 0x06005813 RID: 22547 RVA: 0x0010C084 File Offset: 0x0010A484
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.mapIds = new byte[(int)num];
			for (int i = 0; i < this.mapIds.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.mapIds[i]);
			}
		}

		// Token: 0x06005814 RID: 22548 RVA: 0x0010C0D8 File Offset: 0x0010A4D8
		public int getLen()
		{
			int num = 0;
			return num + (2 + this.mapIds.Length);
		}

		// Token: 0x0400230C RID: 8972
		public const uint MsgID = 608621U;

		// Token: 0x0400230D RID: 8973
		public uint Sequence;

		// Token: 0x0400230E RID: 8974
		public byte[] mapIds = new byte[0];
	}
}
