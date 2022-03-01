using System;

namespace Protocol
{
	// Token: 0x020009AB RID: 2475
	[Protocol]
	public class SceneEquipSchemeWearReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F4C RID: 28492 RVA: 0x0014196D File Offset: 0x0013FD6D
		public uint GetMsgID()
		{
			return 501088U;
		}

		// Token: 0x06006F4D RID: 28493 RVA: 0x00141974 File Offset: 0x0013FD74
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F4E RID: 28494 RVA: 0x0014197C File Offset: 0x0013FD7C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F4F RID: 28495 RVA: 0x00141985 File Offset: 0x0013FD85
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.isSync);
		}

		// Token: 0x06006F50 RID: 28496 RVA: 0x001419B1 File Offset: 0x0013FDB1
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isSync);
		}

		// Token: 0x06006F51 RID: 28497 RVA: 0x001419DD File Offset: 0x0013FDDD
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.isSync);
		}

		// Token: 0x06006F52 RID: 28498 RVA: 0x00141A09 File Offset: 0x0013FE09
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isSync);
		}

		// Token: 0x06006F53 RID: 28499 RVA: 0x00141A38 File Offset: 0x0013FE38
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			return num + 1;
		}

		// Token: 0x0400327F RID: 12927
		public const uint MsgID = 501088U;

		// Token: 0x04003280 RID: 12928
		public uint Sequence;

		// Token: 0x04003281 RID: 12929
		public byte type;

		// Token: 0x04003282 RID: 12930
		public uint id;

		// Token: 0x04003283 RID: 12931
		public byte isSync;
	}
}
