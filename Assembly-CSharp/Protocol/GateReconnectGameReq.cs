using System;

namespace Protocol
{
	// Token: 0x020009C7 RID: 2503
	[Protocol]
	public class GateReconnectGameReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007027 RID: 28711 RVA: 0x00144CAC File Offset: 0x001430AC
		public uint GetMsgID()
		{
			return 300311U;
		}

		// Token: 0x06007028 RID: 28712 RVA: 0x00144CB3 File Offset: 0x001430B3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007029 RID: 28713 RVA: 0x00144CBB File Offset: 0x001430BB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600702A RID: 28714 RVA: 0x00144CC4 File Offset: 0x001430C4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sequence);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.session.Length);
			for (int i = 0; i < this.session.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.session[i]);
			}
		}

		// Token: 0x0600702B RID: 28715 RVA: 0x00144D38 File Offset: 0x00143138
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sequence);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.session = new byte[(int)num];
			for (int i = 0; i < this.session.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.session[i]);
			}
		}

		// Token: 0x0600702C RID: 28716 RVA: 0x00144DB4 File Offset: 0x001431B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sequence);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.session.Length);
			for (int i = 0; i < this.session.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.session[i]);
			}
		}

		// Token: 0x0600702D RID: 28717 RVA: 0x00144E28 File Offset: 0x00143228
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sequence);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.session = new byte[(int)num];
			for (int i = 0; i < this.session.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.session[i]);
			}
		}

		// Token: 0x0600702E RID: 28718 RVA: 0x00144EA4 File Offset: 0x001432A4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num += 4;
			return num + (2 + this.session.Length);
		}

		// Token: 0x0400331A RID: 13082
		public const uint MsgID = 300311U;

		// Token: 0x0400331B RID: 13083
		public uint Sequence;

		// Token: 0x0400331C RID: 13084
		public uint accid;

		// Token: 0x0400331D RID: 13085
		public ulong roleId;

		// Token: 0x0400331E RID: 13086
		public uint sequence;

		// Token: 0x0400331F RID: 13087
		public byte[] session = new byte[0];
	}
}
