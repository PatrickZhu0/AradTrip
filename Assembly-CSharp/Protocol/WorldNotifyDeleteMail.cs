using System;

namespace Protocol
{
	// Token: 0x020009E6 RID: 2534
	[Protocol]
	public class WorldNotifyDeleteMail : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600712F RID: 28975 RVA: 0x00146BFB File Offset: 0x00144FFB
		public uint GetMsgID()
		{
			return 601511U;
		}

		// Token: 0x06007130 RID: 28976 RVA: 0x00146C02 File Offset: 0x00145002
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007131 RID: 28977 RVA: 0x00146C0A File Offset: 0x0014500A
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007132 RID: 28978 RVA: 0x00146C14 File Offset: 0x00145014
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.ids.Length);
			for (int i = 0; i < this.ids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.ids[i]);
			}
		}

		// Token: 0x06007133 RID: 28979 RVA: 0x00146C5C File Offset: 0x0014505C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.ids = new ulong[(int)num];
			for (int i = 0; i < this.ids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.ids[i]);
			}
		}

		// Token: 0x06007134 RID: 28980 RVA: 0x00146CB0 File Offset: 0x001450B0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.ids.Length);
			for (int i = 0; i < this.ids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.ids[i]);
			}
		}

		// Token: 0x06007135 RID: 28981 RVA: 0x00146CF8 File Offset: 0x001450F8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.ids = new ulong[(int)num];
			for (int i = 0; i < this.ids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.ids[i]);
			}
		}

		// Token: 0x06007136 RID: 28982 RVA: 0x00146D4C File Offset: 0x0014514C
		public int getLen()
		{
			int num = 0;
			return num + (2 + 8 * this.ids.Length);
		}

		// Token: 0x04003392 RID: 13202
		public const uint MsgID = 601511U;

		// Token: 0x04003393 RID: 13203
		public uint Sequence;

		// Token: 0x04003394 RID: 13204
		public ulong[] ids = new ulong[0];
	}
}
