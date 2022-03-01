using System;

namespace Protocol
{
	// Token: 0x02000902 RID: 2306
	[Protocol]
	public class SceneUseMagicJarRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006982 RID: 27010 RVA: 0x00136D1F File Offset: 0x0013511F
		public uint GetMsgID()
		{
			return 500943U;
		}

		// Token: 0x06006983 RID: 27011 RVA: 0x00136D26 File Offset: 0x00135126
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006984 RID: 27012 RVA: 0x00136D2E File Offset: 0x0013512E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006985 RID: 27013 RVA: 0x00136D38 File Offset: 0x00135138
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarID);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.getItems.Length);
			for (int i = 0; i < this.getItems.Length; i++)
			{
				this.getItems[i].encode(buffer, ref pos_);
			}
			this.baseItem.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.getPointId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.getPoint);
			BaseDLL.encode_uint32(buffer, ref pos_, this.crit);
		}

		// Token: 0x06006986 RID: 27014 RVA: 0x00136DD4 File Offset: 0x001351D4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.getItems = new OpenJarResult[(int)num];
			for (int i = 0; i < this.getItems.Length; i++)
			{
				this.getItems[i] = new OpenJarResult();
				this.getItems[i].decode(buffer, ref pos_);
			}
			this.baseItem.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getPointId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getPoint);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.crit);
		}

		// Token: 0x06006987 RID: 27015 RVA: 0x00136E84 File Offset: 0x00135284
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarID);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.getItems.Length);
			for (int i = 0; i < this.getItems.Length; i++)
			{
				this.getItems[i].encode(buffer, ref pos_);
			}
			this.baseItem.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.getPointId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.getPoint);
			BaseDLL.encode_uint32(buffer, ref pos_, this.crit);
		}

		// Token: 0x06006988 RID: 27016 RVA: 0x00136F20 File Offset: 0x00135320
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.getItems = new OpenJarResult[(int)num];
			for (int i = 0; i < this.getItems.Length; i++)
			{
				this.getItems[i] = new OpenJarResult();
				this.getItems[i].decode(buffer, ref pos_);
			}
			this.baseItem.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getPointId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getPoint);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.crit);
		}

		// Token: 0x06006989 RID: 27017 RVA: 0x00136FD0 File Offset: 0x001353D0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.getItems.Length; i++)
			{
				num += this.getItems[i].getLen();
			}
			num += this.baseItem.getLen();
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002FD0 RID: 12240
		public const uint MsgID = 500943U;

		// Token: 0x04002FD1 RID: 12241
		public uint Sequence;

		// Token: 0x04002FD2 RID: 12242
		public uint code;

		// Token: 0x04002FD3 RID: 12243
		public uint jarID;

		// Token: 0x04002FD4 RID: 12244
		public OpenJarResult[] getItems = new OpenJarResult[0];

		// Token: 0x04002FD5 RID: 12245
		public ItemReward baseItem = new ItemReward();

		// Token: 0x04002FD6 RID: 12246
		public uint getPointId;

		// Token: 0x04002FD7 RID: 12247
		public uint getPoint;

		// Token: 0x04002FD8 RID: 12248
		public uint crit;
	}
}
