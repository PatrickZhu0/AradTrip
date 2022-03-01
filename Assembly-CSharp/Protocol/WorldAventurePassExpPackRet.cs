using System;

namespace Protocol
{
	// Token: 0x02000C28 RID: 3112
	[Protocol]
	public class WorldAventurePassExpPackRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060081E8 RID: 33256 RVA: 0x0016E384 File Offset: 0x0016C784
		public uint GetMsgID()
		{
			return 609508U;
		}

		// Token: 0x060081E9 RID: 33257 RVA: 0x0016E38B File Offset: 0x0016C78B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060081EA RID: 33258 RVA: 0x0016E393 File Offset: 0x0016C793
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060081EB RID: 33259 RVA: 0x0016E39C File Offset: 0x0016C79C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x060081EC RID: 33260 RVA: 0x0016E3AC File Offset: 0x0016C7AC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x060081ED RID: 33261 RVA: 0x0016E3BC File Offset: 0x0016C7BC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x060081EE RID: 33262 RVA: 0x0016E3CC File Offset: 0x0016C7CC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x060081EF RID: 33263 RVA: 0x0016E3DC File Offset: 0x0016C7DC
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003DFC RID: 15868
		public const uint MsgID = 609508U;

		// Token: 0x04003DFD RID: 15869
		public uint Sequence;

		// Token: 0x04003DFE RID: 15870
		public byte type;
	}
}
