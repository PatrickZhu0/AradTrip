using System;

namespace Protocol
{
	// Token: 0x020008FB RID: 2299
	[Protocol]
	public class SceneDungeonUseItem : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006943 RID: 26947 RVA: 0x00136764 File Offset: 0x00134B64
		public uint GetMsgID()
		{
			return 500934U;
		}

		// Token: 0x06006944 RID: 26948 RVA: 0x0013676B File Offset: 0x00134B6B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006945 RID: 26949 RVA: 0x00136773 File Offset: 0x00134B73
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006946 RID: 26950 RVA: 0x0013677C File Offset: 0x00134B7C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemid);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06006947 RID: 26951 RVA: 0x0013679A File Offset: 0x00134B9A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemid);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006948 RID: 26952 RVA: 0x001367B8 File Offset: 0x00134BB8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemid);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06006949 RID: 26953 RVA: 0x001367D6 File Offset: 0x00134BD6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemid);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x0600694A RID: 26954 RVA: 0x001367F4 File Offset: 0x00134BF4
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 2;
		}

		// Token: 0x04002FB5 RID: 12213
		public const uint MsgID = 500934U;

		// Token: 0x04002FB6 RID: 12214
		public uint Sequence;

		// Token: 0x04002FB7 RID: 12215
		public uint itemid;

		// Token: 0x04002FB8 RID: 12216
		public ushort num;
	}
}
