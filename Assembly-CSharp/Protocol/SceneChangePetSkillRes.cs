using System;

namespace Protocol
{
	// Token: 0x02000A59 RID: 2649
	[Protocol]
	public class SceneChangePetSkillRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007477 RID: 29815 RVA: 0x00151620 File Offset: 0x0014FA20
		public uint GetMsgID()
		{
			return 502212U;
		}

		// Token: 0x06007478 RID: 29816 RVA: 0x00151627 File Offset: 0x0014FA27
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007479 RID: 29817 RVA: 0x0015162F File Offset: 0x0014FA2F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600747A RID: 29818 RVA: 0x00151638 File Offset: 0x0014FA38
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.petId);
			BaseDLL.encode_int8(buffer, ref pos_, this.skillIndex);
		}

		// Token: 0x0600747B RID: 29819 RVA: 0x00151664 File Offset: 0x0014FA64
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.petId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.skillIndex);
		}

		// Token: 0x0600747C RID: 29820 RVA: 0x00151690 File Offset: 0x0014FA90
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.petId);
			BaseDLL.encode_int8(buffer, ref pos_, this.skillIndex);
		}

		// Token: 0x0600747D RID: 29821 RVA: 0x001516BC File Offset: 0x0014FABC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.petId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.skillIndex);
		}

		// Token: 0x0600747E RID: 29822 RVA: 0x001516E8 File Offset: 0x0014FAE8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			return num + 1;
		}

		// Token: 0x04003614 RID: 13844
		public const uint MsgID = 502212U;

		// Token: 0x04003615 RID: 13845
		public uint Sequence;

		// Token: 0x04003616 RID: 13846
		public uint result;

		// Token: 0x04003617 RID: 13847
		public ulong petId;

		// Token: 0x04003618 RID: 13848
		public byte skillIndex;
	}
}
