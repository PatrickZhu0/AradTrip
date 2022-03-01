using System;

namespace Protocol
{
	// Token: 0x020006AC RID: 1708
	[Protocol]
	public class WorldQueryOwnOccupationsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600581F RID: 22559 RVA: 0x0010C2F1 File Offset: 0x0010A6F1
		public uint GetMsgID()
		{
			return 608623U;
		}

		// Token: 0x06005820 RID: 22560 RVA: 0x0010C2F8 File Offset: 0x0010A6F8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005821 RID: 22561 RVA: 0x0010C300 File Offset: 0x0010A700
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005822 RID: 22562 RVA: 0x0010C30C File Offset: 0x0010A70C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.baseOccus.Length);
			for (int i = 0; i < this.baseOccus.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.baseOccus[i]);
			}
		}

		// Token: 0x06005823 RID: 22563 RVA: 0x0010C354 File Offset: 0x0010A754
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.baseOccus = new byte[(int)num];
			for (int i = 0; i < this.baseOccus.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.baseOccus[i]);
			}
		}

		// Token: 0x06005824 RID: 22564 RVA: 0x0010C3A8 File Offset: 0x0010A7A8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.baseOccus.Length);
			for (int i = 0; i < this.baseOccus.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.baseOccus[i]);
			}
		}

		// Token: 0x06005825 RID: 22565 RVA: 0x0010C3F0 File Offset: 0x0010A7F0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.baseOccus = new byte[(int)num];
			for (int i = 0; i < this.baseOccus.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.baseOccus[i]);
			}
		}

		// Token: 0x06005826 RID: 22566 RVA: 0x0010C444 File Offset: 0x0010A844
		public int getLen()
		{
			int num = 0;
			return num + (2 + this.baseOccus.Length);
		}

		// Token: 0x04002313 RID: 8979
		public const uint MsgID = 608623U;

		// Token: 0x04002314 RID: 8980
		public uint Sequence;

		// Token: 0x04002315 RID: 8981
		public byte[] baseOccus = new byte[0];
	}
}
