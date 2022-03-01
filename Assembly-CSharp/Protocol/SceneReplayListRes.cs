using System;

namespace Protocol
{
	// Token: 0x02000AAC RID: 2732
	[Protocol]
	public class SceneReplayListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060076CC RID: 30412 RVA: 0x00157650 File Offset: 0x00155A50
		public uint GetMsgID()
		{
			return 507502U;
		}

		// Token: 0x060076CD RID: 30413 RVA: 0x00157657 File Offset: 0x00155A57
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060076CE RID: 30414 RVA: 0x0015765F File Offset: 0x00155A5F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060076CF RID: 30415 RVA: 0x00157668 File Offset: 0x00155A68
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.replays.Length);
			for (int i = 0; i < this.replays.Length; i++)
			{
				this.replays[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060076D0 RID: 30416 RVA: 0x001576BC File Offset: 0x00155ABC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.replays = new ReplayInfo[(int)num];
			for (int i = 0; i < this.replays.Length; i++)
			{
				this.replays[i] = new ReplayInfo();
				this.replays[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060076D1 RID: 30417 RVA: 0x00157724 File Offset: 0x00155B24
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.replays.Length);
			for (int i = 0; i < this.replays.Length; i++)
			{
				this.replays[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060076D2 RID: 30418 RVA: 0x00157778 File Offset: 0x00155B78
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.replays = new ReplayInfo[(int)num];
			for (int i = 0; i < this.replays.Length; i++)
			{
				this.replays[i] = new ReplayInfo();
				this.replays[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060076D3 RID: 30419 RVA: 0x001577E0 File Offset: 0x00155BE0
		public int getLen()
		{
			int num = 0;
			num++;
			num += 2;
			for (int i = 0; i < this.replays.Length; i++)
			{
				num += this.replays[i].getLen();
			}
			return num;
		}

		// Token: 0x0400379A RID: 14234
		public const uint MsgID = 507502U;

		// Token: 0x0400379B RID: 14235
		public uint Sequence;

		// Token: 0x0400379C RID: 14236
		public byte type;

		// Token: 0x0400379D RID: 14237
		public ReplayInfo[] replays = new ReplayInfo[0];
	}
}
