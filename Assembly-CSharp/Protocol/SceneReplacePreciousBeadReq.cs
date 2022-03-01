using System;

namespace Protocol
{
	// Token: 0x02000964 RID: 2404
	[Protocol]
	public class SceneReplacePreciousBeadReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006CE8 RID: 27880 RVA: 0x0013CAFC File Offset: 0x0013AEFC
		public uint GetMsgID()
		{
			return 501042U;
		}

		// Token: 0x06006CE9 RID: 27881 RVA: 0x0013CB03 File Offset: 0x0013AF03
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006CEA RID: 27882 RVA: 0x0013CB0B File Offset: 0x0013AF0B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006CEB RID: 27883 RVA: 0x0013CB14 File Offset: 0x0013AF14
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.preciousBeadUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.holeIndex);
		}

		// Token: 0x06006CEC RID: 27884 RVA: 0x0013CB40 File Offset: 0x0013AF40
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.preciousBeadUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.holeIndex);
		}

		// Token: 0x06006CED RID: 27885 RVA: 0x0013CB6C File Offset: 0x0013AF6C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.preciousBeadUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.holeIndex);
		}

		// Token: 0x06006CEE RID: 27886 RVA: 0x0013CB98 File Offset: 0x0013AF98
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.preciousBeadUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.holeIndex);
		}

		// Token: 0x06006CEF RID: 27887 RVA: 0x0013CBC4 File Offset: 0x0013AFC4
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 8;
			return num + 1;
		}

		// Token: 0x04003151 RID: 12625
		public const uint MsgID = 501042U;

		// Token: 0x04003152 RID: 12626
		public uint Sequence;

		// Token: 0x04003153 RID: 12627
		public ulong itemUid;

		// Token: 0x04003154 RID: 12628
		public ulong preciousBeadUid;

		// Token: 0x04003155 RID: 12629
		public byte holeIndex;
	}
}
