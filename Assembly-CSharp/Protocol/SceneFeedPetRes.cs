using System;

namespace Protocol
{
	// Token: 0x02000A55 RID: 2645
	[Protocol]
	public class SceneFeedPetRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007453 RID: 29779 RVA: 0x00151360 File Offset: 0x0014F760
		public uint GetMsgID()
		{
			return 502208U;
		}

		// Token: 0x06007454 RID: 29780 RVA: 0x00151367 File Offset: 0x0014F767
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007455 RID: 29781 RVA: 0x0015136F File Offset: 0x0014F76F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007456 RID: 29782 RVA: 0x00151378 File Offset: 0x0014F778
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.feedType);
			BaseDLL.encode_int8(buffer, ref pos_, this.isCritical);
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
		}

		// Token: 0x06007457 RID: 29783 RVA: 0x001513B2 File Offset: 0x0014F7B2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.feedType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isCritical);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
		}

		// Token: 0x06007458 RID: 29784 RVA: 0x001513EC File Offset: 0x0014F7EC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.feedType);
			BaseDLL.encode_int8(buffer, ref pos_, this.isCritical);
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
		}

		// Token: 0x06007459 RID: 29785 RVA: 0x00151426 File Offset: 0x0014F826
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.feedType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isCritical);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
		}

		// Token: 0x0600745A RID: 29786 RVA: 0x00151460 File Offset: 0x0014F860
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num++;
			return num + 4;
		}

		// Token: 0x04003604 RID: 13828
		public const uint MsgID = 502208U;

		// Token: 0x04003605 RID: 13829
		public uint Sequence;

		// Token: 0x04003606 RID: 13830
		public uint result;

		// Token: 0x04003607 RID: 13831
		public byte feedType;

		// Token: 0x04003608 RID: 13832
		public byte isCritical;

		// Token: 0x04003609 RID: 13833
		public uint value;
	}
}
