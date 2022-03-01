using System;

namespace Protocol
{
	// Token: 0x02000CB3 RID: 3251
	[Protocol]
	public class WorldNotifyDelMasterSectRelation : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008602 RID: 34306 RVA: 0x0017704C File Offset: 0x0017544C
		public uint GetMsgID()
		{
			return 601747U;
		}

		// Token: 0x06008603 RID: 34307 RVA: 0x00177053 File Offset: 0x00175453
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008604 RID: 34308 RVA: 0x0017705B File Offset: 0x0017545B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008605 RID: 34309 RVA: 0x00177064 File Offset: 0x00175464
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06008606 RID: 34310 RVA: 0x00177082 File Offset: 0x00175482
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06008607 RID: 34311 RVA: 0x001770A0 File Offset: 0x001754A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06008608 RID: 34312 RVA: 0x001770BE File Offset: 0x001754BE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06008609 RID: 34313 RVA: 0x001770DC File Offset: 0x001754DC
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 8;
		}

		// Token: 0x04004027 RID: 16423
		public const uint MsgID = 601747U;

		// Token: 0x04004028 RID: 16424
		public uint Sequence;

		// Token: 0x04004029 RID: 16425
		public byte type;

		// Token: 0x0400402A RID: 16426
		public ulong id;
	}
}
