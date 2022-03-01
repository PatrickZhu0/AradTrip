using System;

namespace Protocol
{
	// Token: 0x020008DA RID: 2266
	[Protocol]
	public class SceneUseItem : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600681A RID: 26650 RVA: 0x00134FF0 File Offset: 0x001333F0
		public uint GetMsgID()
		{
			return 500901U;
		}

		// Token: 0x0600681B RID: 26651 RVA: 0x00134FF7 File Offset: 0x001333F7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600681C RID: 26652 RVA: 0x00134FFF File Offset: 0x001333FF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600681D RID: 26653 RVA: 0x00135008 File Offset: 0x00133408
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_int8(buffer, ref pos_, this.useAll);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param2);
		}

		// Token: 0x0600681E RID: 26654 RVA: 0x00135042 File Offset: 0x00133442
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.useAll);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param2);
		}

		// Token: 0x0600681F RID: 26655 RVA: 0x0013507C File Offset: 0x0013347C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_int8(buffer, ref pos_, this.useAll);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param2);
		}

		// Token: 0x06006820 RID: 26656 RVA: 0x001350B6 File Offset: 0x001334B6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.useAll);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param2);
		}

		// Token: 0x06006821 RID: 26657 RVA: 0x001350F0 File Offset: 0x001334F0
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002F42 RID: 12098
		public const uint MsgID = 500901U;

		// Token: 0x04002F43 RID: 12099
		public uint Sequence;

		// Token: 0x04002F44 RID: 12100
		public ulong uid;

		// Token: 0x04002F45 RID: 12101
		public byte useAll;

		// Token: 0x04002F46 RID: 12102
		public uint param1;

		// Token: 0x04002F47 RID: 12103
		public uint param2;
	}
}
