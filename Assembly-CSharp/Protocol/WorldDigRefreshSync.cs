using System;

namespace Protocol
{
	// Token: 0x02000795 RID: 1941
	[Protocol]
	public class WorldDigRefreshSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F11 RID: 24337 RVA: 0x0011D202 File Offset: 0x0011B602
		public uint GetMsgID()
		{
			return 608202U;
		}

		// Token: 0x06005F12 RID: 24338 RVA: 0x0011D209 File Offset: 0x0011B609
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F13 RID: 24339 RVA: 0x0011D211 File Offset: 0x0011B611
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F14 RID: 24340 RVA: 0x0011D21C File Offset: 0x0011B61C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infos.Length);
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005F15 RID: 24341 RVA: 0x0011D270 File Offset: 0x0011B670
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infos = new DigInfo[(int)num];
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i] = new DigInfo();
				this.infos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005F16 RID: 24342 RVA: 0x0011D2D8 File Offset: 0x0011B6D8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infos.Length);
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005F17 RID: 24343 RVA: 0x0011D32C File Offset: 0x0011B72C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infos = new DigInfo[(int)num];
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i] = new DigInfo();
				this.infos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005F18 RID: 24344 RVA: 0x0011D394 File Offset: 0x0011B794
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.infos.Length; i++)
			{
				num += this.infos[i].getLen();
			}
			return num;
		}

		// Token: 0x0400273B RID: 10043
		public const uint MsgID = 608202U;

		// Token: 0x0400273C RID: 10044
		public uint Sequence;

		// Token: 0x0400273D RID: 10045
		public uint mapId;

		// Token: 0x0400273E RID: 10046
		public DigInfo[] infos = new DigInfo[0];
	}
}
