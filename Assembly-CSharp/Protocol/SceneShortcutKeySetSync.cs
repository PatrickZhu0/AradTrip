using System;

namespace Protocol
{
	// Token: 0x02000B4E RID: 2894
	[Protocol]
	public class SceneShortcutKeySetSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007B82 RID: 31618 RVA: 0x00161226 File Offset: 0x0015F626
		public uint GetMsgID()
		{
			return 501231U;
		}

		// Token: 0x06007B83 RID: 31619 RVA: 0x0016122D File Offset: 0x0015F62D
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B84 RID: 31620 RVA: 0x00161235 File Offset: 0x0015F635
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B85 RID: 31621 RVA: 0x00161240 File Offset: 0x0015F640
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infos.Length);
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007B86 RID: 31622 RVA: 0x00161288 File Offset: 0x0015F688
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infos = new ShortcutKeyInfo[(int)num];
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i] = new ShortcutKeyInfo();
				this.infos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007B87 RID: 31623 RVA: 0x001612E4 File Offset: 0x0015F6E4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infos.Length);
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007B88 RID: 31624 RVA: 0x0016132C File Offset: 0x0015F72C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infos = new ShortcutKeyInfo[(int)num];
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i] = new ShortcutKeyInfo();
				this.infos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007B89 RID: 31625 RVA: 0x00161388 File Offset: 0x0015F788
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.infos.Length; i++)
			{
				num += this.infos[i].getLen();
			}
			return num;
		}

		// Token: 0x04003A76 RID: 14966
		public const uint MsgID = 501231U;

		// Token: 0x04003A77 RID: 14967
		public uint Sequence;

		// Token: 0x04003A78 RID: 14968
		public ShortcutKeyInfo[] infos = new ShortcutKeyInfo[0];
	}
}
