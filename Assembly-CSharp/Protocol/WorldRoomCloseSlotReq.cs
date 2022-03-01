using System;

namespace Protocol
{
	// Token: 0x02000AEA RID: 2794
	[Protocol]
	public class WorldRoomCloseSlotReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007885 RID: 30853 RVA: 0x0015C536 File Offset: 0x0015A936
		public uint GetMsgID()
		{
			return 607829U;
		}

		// Token: 0x06007886 RID: 30854 RVA: 0x0015C53D File Offset: 0x0015A93D
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007887 RID: 30855 RVA: 0x0015C545 File Offset: 0x0015A945
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007888 RID: 30856 RVA: 0x0015C54E File Offset: 0x0015A94E
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.slotGroup);
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
		}

		// Token: 0x06007889 RID: 30857 RVA: 0x0015C56C File Offset: 0x0015A96C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotGroup);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
		}

		// Token: 0x0600788A RID: 30858 RVA: 0x0015C58A File Offset: 0x0015A98A
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.slotGroup);
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
		}

		// Token: 0x0600788B RID: 30859 RVA: 0x0015C5A8 File Offset: 0x0015A9A8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotGroup);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
		}

		// Token: 0x0600788C RID: 30860 RVA: 0x0015C5C8 File Offset: 0x0015A9C8
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 1;
		}

		// Token: 0x040038E3 RID: 14563
		public const uint MsgID = 607829U;

		// Token: 0x040038E4 RID: 14564
		public uint Sequence;

		// Token: 0x040038E5 RID: 14565
		public byte slotGroup;

		// Token: 0x040038E6 RID: 14566
		public byte index;
	}
}
