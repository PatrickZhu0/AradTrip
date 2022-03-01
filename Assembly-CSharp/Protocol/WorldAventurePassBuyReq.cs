using System;

namespace Protocol
{
	// Token: 0x02000C23 RID: 3107
	[Protocol]
	public class WorldAventurePassBuyReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060081BB RID: 33211 RVA: 0x0016E140 File Offset: 0x0016C540
		public uint GetMsgID()
		{
			return 609503U;
		}

		// Token: 0x060081BC RID: 33212 RVA: 0x0016E147 File Offset: 0x0016C547
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060081BD RID: 33213 RVA: 0x0016E14F File Offset: 0x0016C54F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060081BE RID: 33214 RVA: 0x0016E158 File Offset: 0x0016C558
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x060081BF RID: 33215 RVA: 0x0016E168 File Offset: 0x0016C568
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x060081C0 RID: 33216 RVA: 0x0016E178 File Offset: 0x0016C578
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x060081C1 RID: 33217 RVA: 0x0016E188 File Offset: 0x0016C588
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x060081C2 RID: 33218 RVA: 0x0016E198 File Offset: 0x0016C598
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003DED RID: 15853
		public const uint MsgID = 609503U;

		// Token: 0x04003DEE RID: 15854
		public uint Sequence;

		// Token: 0x04003DEF RID: 15855
		public byte type;
	}
}
