using System;

namespace Protocol
{
	// Token: 0x02000965 RID: 2405
	[Protocol]
	public class SceneReplacePreciousBeadRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006CF1 RID: 27889 RVA: 0x0013CBE8 File Offset: 0x0013AFE8
		public uint GetMsgID()
		{
			return 501043U;
		}

		// Token: 0x06006CF2 RID: 27890 RVA: 0x0013CBEF File Offset: 0x0013AFEF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006CF3 RID: 27891 RVA: 0x0013CBF7 File Offset: 0x0013AFF7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006CF4 RID: 27892 RVA: 0x0013CC00 File Offset: 0x0013B000
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preciousBeadId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.holeIndex);
		}

		// Token: 0x06006CF5 RID: 27893 RVA: 0x0013CC3A File Offset: 0x0013B03A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preciousBeadId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.holeIndex);
		}

		// Token: 0x06006CF6 RID: 27894 RVA: 0x0013CC74 File Offset: 0x0013B074
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preciousBeadId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.holeIndex);
		}

		// Token: 0x06006CF7 RID: 27895 RVA: 0x0013CCAE File Offset: 0x0013B0AE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preciousBeadId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.holeIndex);
		}

		// Token: 0x06006CF8 RID: 27896 RVA: 0x0013CCE8 File Offset: 0x0013B0E8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 8;
			return num + 1;
		}

		// Token: 0x04003156 RID: 12630
		public const uint MsgID = 501043U;

		// Token: 0x04003157 RID: 12631
		public uint Sequence;

		// Token: 0x04003158 RID: 12632
		public uint retCode;

		// Token: 0x04003159 RID: 12633
		public uint preciousBeadId;

		// Token: 0x0400315A RID: 12634
		public ulong itemUid;

		// Token: 0x0400315B RID: 12635
		public byte holeIndex;
	}
}
