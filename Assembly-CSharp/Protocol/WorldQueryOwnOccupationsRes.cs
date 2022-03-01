using System;

namespace Protocol
{
	// Token: 0x020006AD RID: 1709
	[Protocol]
	public class WorldQueryOwnOccupationsRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005828 RID: 22568 RVA: 0x0010C475 File Offset: 0x0010A875
		public uint GetMsgID()
		{
			return 608624U;
		}

		// Token: 0x06005829 RID: 22569 RVA: 0x0010C47C File Offset: 0x0010A87C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600582A RID: 22570 RVA: 0x0010C484 File Offset: 0x0010A884
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600582B RID: 22571 RVA: 0x0010C490 File Offset: 0x0010A890
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.occus.Length);
			for (int i = 0; i < this.occus.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.occus[i]);
			}
		}

		// Token: 0x0600582C RID: 22572 RVA: 0x0010C4E8 File Offset: 0x0010A8E8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.occus = new byte[(int)num];
			for (int i = 0; i < this.occus.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.occus[i]);
			}
		}

		// Token: 0x0600582D RID: 22573 RVA: 0x0010C548 File Offset: 0x0010A948
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.occus.Length);
			for (int i = 0; i < this.occus.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.occus[i]);
			}
		}

		// Token: 0x0600582E RID: 22574 RVA: 0x0010C5A0 File Offset: 0x0010A9A0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.occus = new byte[(int)num];
			for (int i = 0; i < this.occus.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.occus[i]);
			}
		}

		// Token: 0x0600582F RID: 22575 RVA: 0x0010C600 File Offset: 0x0010AA00
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + (2 + this.occus.Length);
		}

		// Token: 0x04002316 RID: 8982
		public const uint MsgID = 608624U;

		// Token: 0x04002317 RID: 8983
		public uint Sequence;

		// Token: 0x04002318 RID: 8984
		public uint resCode;

		// Token: 0x04002319 RID: 8985
		public byte[] occus = new byte[0];
	}
}
