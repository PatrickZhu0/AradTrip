using System;

namespace Protocol
{
	// Token: 0x020009AD RID: 2477
	[Protocol]
	public class SceneEquipConvertReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F5E RID: 28510 RVA: 0x00141CCF File Offset: 0x001400CF
		public uint GetMsgID()
		{
			return 501092U;
		}

		// Token: 0x06006F5F RID: 28511 RVA: 0x00141CD6 File Offset: 0x001400D6
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F60 RID: 28512 RVA: 0x00141CDE File Offset: 0x001400DE
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F61 RID: 28513 RVA: 0x00141CE7 File Offset: 0x001400E7
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.sourceEqGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetEqTypeId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.convertorGuid);
		}

		// Token: 0x06006F62 RID: 28514 RVA: 0x00141D21 File Offset: 0x00140121
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.sourceEqGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetEqTypeId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.convertorGuid);
		}

		// Token: 0x06006F63 RID: 28515 RVA: 0x00141D5B File Offset: 0x0014015B
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.sourceEqGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetEqTypeId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.convertorGuid);
		}

		// Token: 0x06006F64 RID: 28516 RVA: 0x00141D95 File Offset: 0x00140195
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.sourceEqGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetEqTypeId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.convertorGuid);
		}

		// Token: 0x06006F65 RID: 28517 RVA: 0x00141DD0 File Offset: 0x001401D0
		public int getLen()
		{
			int num = 0;
			num++;
			num += 8;
			num += 4;
			return num + 8;
		}

		// Token: 0x0400328B RID: 12939
		public const uint MsgID = 501092U;

		// Token: 0x0400328C RID: 12940
		public uint Sequence;

		// Token: 0x0400328D RID: 12941
		public byte type;

		// Token: 0x0400328E RID: 12942
		public ulong sourceEqGuid;

		// Token: 0x0400328F RID: 12943
		public uint targetEqTypeId;

		// Token: 0x04003290 RID: 12944
		public ulong convertorGuid;
	}
}
