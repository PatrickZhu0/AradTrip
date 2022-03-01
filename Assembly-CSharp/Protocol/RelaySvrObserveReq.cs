using System;

namespace Protocol
{
	// Token: 0x02000AA4 RID: 2724
	[Protocol]
	public class RelaySvrObserveReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060076A5 RID: 30373 RVA: 0x00156E2C File Offset: 0x0015522C
		public uint GetMsgID()
		{
			return 1300022U;
		}

		// Token: 0x060076A6 RID: 30374 RVA: 0x00156E33 File Offset: 0x00155233
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060076A7 RID: 30375 RVA: 0x00156E3B File Offset: 0x0015523B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060076A8 RID: 30376 RVA: 0x00156E44 File Offset: 0x00155244
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startFrame);
		}

		// Token: 0x060076A9 RID: 30377 RVA: 0x00156E7E File Offset: 0x0015527E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startFrame);
		}

		// Token: 0x060076AA RID: 30378 RVA: 0x00156EB8 File Offset: 0x001552B8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startFrame);
		}

		// Token: 0x060076AB RID: 30379 RVA: 0x00156EF2 File Offset: 0x001552F2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startFrame);
		}

		// Token: 0x060076AC RID: 30380 RVA: 0x00156F2C File Offset: 0x0015532C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num += 8;
			return num + 4;
		}

		// Token: 0x04003772 RID: 14194
		public const uint MsgID = 1300022U;

		// Token: 0x04003773 RID: 14195
		public uint Sequence;

		// Token: 0x04003774 RID: 14196
		public uint accid;

		// Token: 0x04003775 RID: 14197
		public ulong roleId;

		// Token: 0x04003776 RID: 14198
		public ulong raceId;

		// Token: 0x04003777 RID: 14199
		public uint startFrame;
	}
}
