using System;

namespace Protocol
{
	// Token: 0x02000A94 RID: 2708
	[Protocol]
	public class RelaySvrPlayerInputReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007624 RID: 30244 RVA: 0x00155810 File Offset: 0x00153C10
		public uint GetMsgID()
		{
			return 1300005U;
		}

		// Token: 0x06007625 RID: 30245 RVA: 0x00155817 File Offset: 0x00153C17
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007626 RID: 30246 RVA: 0x0015581F File Offset: 0x00153C1F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007627 RID: 30247 RVA: 0x00155828 File Offset: 0x00153C28
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.session);
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleid);
			this.input.encode(buffer, ref pos_);
		}

		// Token: 0x06007628 RID: 30248 RVA: 0x00155861 File Offset: 0x00153C61
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.session);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleid);
			this.input.decode(buffer, ref pos_);
		}

		// Token: 0x06007629 RID: 30249 RVA: 0x0015589A File Offset: 0x00153C9A
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.session);
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleid);
			this.input.encode(buffer, ref pos_);
		}

		// Token: 0x0600762A RID: 30250 RVA: 0x001558D3 File Offset: 0x00153CD3
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.session);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleid);
			this.input.decode(buffer, ref pos_);
		}

		// Token: 0x0600762B RID: 30251 RVA: 0x0015590C File Offset: 0x00153D0C
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			num += 8;
			return num + this.input.getLen();
		}

		// Token: 0x04003726 RID: 14118
		public const uint MsgID = 1300005U;

		// Token: 0x04003727 RID: 14119
		public uint Sequence;

		// Token: 0x04003728 RID: 14120
		public ulong session;

		// Token: 0x04003729 RID: 14121
		public byte seat;

		// Token: 0x0400372A RID: 14122
		public ulong roleid;

		// Token: 0x0400372B RID: 14123
		public _inputData input = new _inputData();
	}
}
