using System;

namespace Protocol
{
	// Token: 0x02000A9F RID: 2719
	[Protocol]
	public class RelaySvrReconnectReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007678 RID: 30328 RVA: 0x00156918 File Offset: 0x00154D18
		public uint GetMsgID()
		{
			return 1300012U;
		}

		// Token: 0x06007679 RID: 30329 RVA: 0x0015691F File Offset: 0x00154D1F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600767A RID: 30330 RVA: 0x00156927 File Offset: 0x00154D27
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600767B RID: 30331 RVA: 0x00156930 File Offset: 0x00154D30
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.session);
			BaseDLL.encode_uint64(buffer, ref pos_, this.lastFrame);
		}

		// Token: 0x0600767C RID: 30332 RVA: 0x00156984 File Offset: 0x00154D84
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.session);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.lastFrame);
		}

		// Token: 0x0600767D RID: 30333 RVA: 0x001569D8 File Offset: 0x00154DD8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.session);
			BaseDLL.encode_uint64(buffer, ref pos_, this.lastFrame);
		}

		// Token: 0x0600767E RID: 30334 RVA: 0x00156A2C File Offset: 0x00154E2C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.session);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.lastFrame);
		}

		// Token: 0x0600767F RID: 30335 RVA: 0x00156A80 File Offset: 0x00154E80
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			num += 8;
			num += 8;
			return num + 8;
		}

		// Token: 0x0400375D RID: 14173
		public const uint MsgID = 1300012U;

		// Token: 0x0400375E RID: 14174
		public uint Sequence;

		// Token: 0x0400375F RID: 14175
		public byte seat;

		// Token: 0x04003760 RID: 14176
		public uint accid;

		// Token: 0x04003761 RID: 14177
		public ulong roleid;

		// Token: 0x04003762 RID: 14178
		public ulong session;

		// Token: 0x04003763 RID: 14179
		public ulong lastFrame;
	}
}
