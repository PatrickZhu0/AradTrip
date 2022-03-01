using System;

namespace Protocol
{
	// Token: 0x02000715 RID: 1813
	[Protocol]
	public class SceneBattleNpcTradeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B30 RID: 23344 RVA: 0x00114A8D File Offset: 0x00112E8D
		public uint GetMsgID()
		{
			return 508930U;
		}

		// Token: 0x06005B31 RID: 23345 RVA: 0x00114A94 File Offset: 0x00112E94
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B32 RID: 23346 RVA: 0x00114A9C File Offset: 0x00112E9C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B33 RID: 23347 RVA: 0x00114AA8 File Offset: 0x00112EA8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.npcGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.npcId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.paramVec.Length);
			for (int i = 0; i < this.paramVec.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.paramVec[i]);
			}
		}

		// Token: 0x06005B34 RID: 23348 RVA: 0x00114B0C File Offset: 0x00112F0C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.npcGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.npcId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.paramVec = new ulong[(int)num];
			for (int i = 0; i < this.paramVec.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.paramVec[i]);
			}
		}

		// Token: 0x06005B35 RID: 23349 RVA: 0x00114B7C File Offset: 0x00112F7C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.npcGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.npcId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.paramVec.Length);
			for (int i = 0; i < this.paramVec.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.paramVec[i]);
			}
		}

		// Token: 0x06005B36 RID: 23350 RVA: 0x00114BE0 File Offset: 0x00112FE0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.npcGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.npcId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.paramVec = new ulong[(int)num];
			for (int i = 0; i < this.paramVec.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.paramVec[i]);
			}
		}

		// Token: 0x06005B37 RID: 23351 RVA: 0x00114C50 File Offset: 0x00113050
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			return num + (2 + 8 * this.paramVec.Length);
		}

		// Token: 0x04002525 RID: 9509
		public const uint MsgID = 508930U;

		// Token: 0x04002526 RID: 9510
		public uint Sequence;

		// Token: 0x04002527 RID: 9511
		public ulong npcGuid;

		// Token: 0x04002528 RID: 9512
		public uint npcId;

		// Token: 0x04002529 RID: 9513
		public ulong[] paramVec = new ulong[0];
	}
}
