using System;

namespace Protocol
{
	// Token: 0x02000C71 RID: 3185
	[Protocol]
	public class WorldGetDiscipleMasterTasksRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008401 RID: 33793 RVA: 0x00172839 File Offset: 0x00170C39
		public uint GetMsgID()
		{
			return 601757U;
		}

		// Token: 0x06008402 RID: 33794 RVA: 0x00172840 File Offset: 0x00170C40
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008403 RID: 33795 RVA: 0x00172848 File Offset: 0x00170C48
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008404 RID: 33796 RVA: 0x00172851 File Offset: 0x00170C51
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipleId);
			this.masterTaskShareData.encode(buffer, ref pos_);
		}

		// Token: 0x06008405 RID: 33797 RVA: 0x0017287C File Offset: 0x00170C7C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipleId);
			this.masterTaskShareData.decode(buffer, ref pos_);
		}

		// Token: 0x06008406 RID: 33798 RVA: 0x001728A7 File Offset: 0x00170CA7
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipleId);
			this.masterTaskShareData.encode(buffer, ref pos_);
		}

		// Token: 0x06008407 RID: 33799 RVA: 0x001728D2 File Offset: 0x00170CD2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipleId);
			this.masterTaskShareData.decode(buffer, ref pos_);
		}

		// Token: 0x06008408 RID: 33800 RVA: 0x00172900 File Offset: 0x00170D00
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			return num + this.masterTaskShareData.getLen();
		}

		// Token: 0x04003F14 RID: 16148
		public const uint MsgID = 601757U;

		// Token: 0x04003F15 RID: 16149
		public uint Sequence;

		// Token: 0x04003F16 RID: 16150
		public uint code;

		// Token: 0x04003F17 RID: 16151
		public ulong discipleId;

		// Token: 0x04003F18 RID: 16152
		public MasterTaskShareData masterTaskShareData = new MasterTaskShareData();
	}
}
