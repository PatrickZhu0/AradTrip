using System;

namespace Protocol
{
	// Token: 0x02000799 RID: 1945
	[Protocol]
	public class WorldDigMapOpenRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F35 RID: 24373 RVA: 0x0011D598 File Offset: 0x0011B998
		public uint GetMsgID()
		{
			return 608206U;
		}

		// Token: 0x06005F36 RID: 24374 RVA: 0x0011D59F File Offset: 0x0011B99F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F37 RID: 24375 RVA: 0x0011D5A7 File Offset: 0x0011B9A7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F38 RID: 24376 RVA: 0x0011D5B0 File Offset: 0x0011B9B0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infos.Length);
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005F39 RID: 24377 RVA: 0x0011D614 File Offset: 0x0011BA14
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
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

		// Token: 0x06005F3A RID: 24378 RVA: 0x0011D68C File Offset: 0x0011BA8C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infos.Length);
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005F3B RID: 24379 RVA: 0x0011D6F0 File Offset: 0x0011BAF0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
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

		// Token: 0x06005F3C RID: 24380 RVA: 0x0011D768 File Offset: 0x0011BB68
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.infos.Length; i++)
			{
				num += this.infos[i].getLen();
			}
			return num;
		}

		// Token: 0x04002749 RID: 10057
		public const uint MsgID = 608206U;

		// Token: 0x0400274A RID: 10058
		public uint Sequence;

		// Token: 0x0400274B RID: 10059
		public uint result;

		// Token: 0x0400274C RID: 10060
		public uint mapId;

		// Token: 0x0400274D RID: 10061
		public DigInfo[] infos = new DigInfo[0];
	}
}
