using System;

namespace Protocol
{
	// Token: 0x02000A87 RID: 2695
	[Protocol]
	public class WorldSyncRedPacketRecord : IProtocolStream, IGetMsgID
	{
		// Token: 0x060075CD RID: 30157 RVA: 0x0015498C File Offset: 0x00152D8C
		public uint GetMsgID()
		{
			return 607312U;
		}

		// Token: 0x060075CE RID: 30158 RVA: 0x00154993 File Offset: 0x00152D93
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060075CF RID: 30159 RVA: 0x0015499B File Offset: 0x00152D9B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060075D0 RID: 30160 RVA: 0x001549A4 File Offset: 0x00152DA4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.adds.Length);
			for (int i = 0; i < this.adds.Length; i++)
			{
				this.adds[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dels.Length);
			for (int j = 0; j < this.dels.Length; j++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.dels[j]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.updates.Length);
			for (int k = 0; k < this.updates.Length; k++)
			{
				this.updates[k].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060075D1 RID: 30161 RVA: 0x00154A60 File Offset: 0x00152E60
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.adds = new RedPacketRecord[(int)num];
			for (int i = 0; i < this.adds.Length; i++)
			{
				this.adds[i] = new RedPacketRecord();
				this.adds[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.dels = new ulong[(int)num2];
			for (int j = 0; j < this.dels.Length; j++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.dels[j]);
			}
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.updates = new RedPacketRecord[(int)num3];
			for (int k = 0; k < this.updates.Length; k++)
			{
				this.updates[k] = new RedPacketRecord();
				this.updates[k].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060075D2 RID: 30162 RVA: 0x00154B54 File Offset: 0x00152F54
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.adds.Length);
			for (int i = 0; i < this.adds.Length; i++)
			{
				this.adds[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dels.Length);
			for (int j = 0; j < this.dels.Length; j++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.dels[j]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.updates.Length);
			for (int k = 0; k < this.updates.Length; k++)
			{
				this.updates[k].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060075D3 RID: 30163 RVA: 0x00154C10 File Offset: 0x00153010
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.adds = new RedPacketRecord[(int)num];
			for (int i = 0; i < this.adds.Length; i++)
			{
				this.adds[i] = new RedPacketRecord();
				this.adds[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.dels = new ulong[(int)num2];
			for (int j = 0; j < this.dels.Length; j++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.dels[j]);
			}
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.updates = new RedPacketRecord[(int)num3];
			for (int k = 0; k < this.updates.Length; k++)
			{
				this.updates[k] = new RedPacketRecord();
				this.updates[k].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060075D4 RID: 30164 RVA: 0x00154D04 File Offset: 0x00153104
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.adds.Length; i++)
			{
				num += this.adds[i].getLen();
			}
			num += 2 + 8 * this.dels.Length;
			num += 2;
			for (int j = 0; j < this.updates.Length; j++)
			{
				num += this.updates[j].getLen();
			}
			return num;
		}

		// Token: 0x040036D8 RID: 14040
		public const uint MsgID = 607312U;

		// Token: 0x040036D9 RID: 14041
		public uint Sequence;

		// Token: 0x040036DA RID: 14042
		public RedPacketRecord[] adds = new RedPacketRecord[0];

		// Token: 0x040036DB RID: 14043
		public ulong[] dels = new ulong[0];

		// Token: 0x040036DC RID: 14044
		public RedPacketRecord[] updates = new RedPacketRecord[0];
	}
}
