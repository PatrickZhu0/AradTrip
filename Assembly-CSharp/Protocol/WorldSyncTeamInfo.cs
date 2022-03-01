using System;

namespace Protocol
{
	// Token: 0x02000B7E RID: 2942
	[Protocol]
	public class WorldSyncTeamInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007CC9 RID: 31945 RVA: 0x00163F44 File Offset: 0x00162344
		public uint GetMsgID()
		{
			return 601601U;
		}

		// Token: 0x06007CCA RID: 31946 RVA: 0x00163F4B File Offset: 0x0016234B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007CCB RID: 31947 RVA: 0x00163F53 File Offset: 0x00162353
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007CCC RID: 31948 RVA: 0x00163F5C File Offset: 0x0016235C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.target);
			BaseDLL.encode_int8(buffer, ref pos_, this.autoAgree);
			BaseDLL.encode_uint64(buffer, ref pos_, this.master);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.members.Length);
			for (int i = 0; i < this.members.Length; i++)
			{
				this.members[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.options);
		}

		// Token: 0x06007CCD RID: 31949 RVA: 0x00163FE8 File Offset: 0x001623E8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.target);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.autoAgree);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.master);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.members = new TeammemberInfo[(int)num];
			for (int i = 0; i < this.members.Length; i++)
			{
				this.members[i] = new TeammemberInfo();
				this.members[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.options);
		}

		// Token: 0x06007CCE RID: 31950 RVA: 0x00164088 File Offset: 0x00162488
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.target);
			BaseDLL.encode_int8(buffer, ref pos_, this.autoAgree);
			BaseDLL.encode_uint64(buffer, ref pos_, this.master);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.members.Length);
			for (int i = 0; i < this.members.Length; i++)
			{
				this.members[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.options);
		}

		// Token: 0x06007CCF RID: 31951 RVA: 0x00164114 File Offset: 0x00162514
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.target);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.autoAgree);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.master);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.members = new TeammemberInfo[(int)num];
			for (int i = 0; i < this.members.Length; i++)
			{
				this.members[i] = new TeammemberInfo();
				this.members[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.options);
		}

		// Token: 0x06007CD0 RID: 31952 RVA: 0x001641B4 File Offset: 0x001625B4
		public int getLen()
		{
			int num = 0;
			num += 2;
			num += 4;
			num++;
			num += 8;
			num += 2;
			for (int i = 0; i < this.members.Length; i++)
			{
				num += this.members[i].getLen();
			}
			return num + 4;
		}

		// Token: 0x04003B2F RID: 15151
		public const uint MsgID = 601601U;

		// Token: 0x04003B30 RID: 15152
		public uint Sequence;

		// Token: 0x04003B31 RID: 15153
		public ushort id;

		// Token: 0x04003B32 RID: 15154
		public uint target;

		// Token: 0x04003B33 RID: 15155
		public byte autoAgree;

		// Token: 0x04003B34 RID: 15156
		public ulong master;

		// Token: 0x04003B35 RID: 15157
		public TeammemberInfo[] members = new TeammemberInfo[0];

		// Token: 0x04003B36 RID: 15158
		public uint options;
	}
}
