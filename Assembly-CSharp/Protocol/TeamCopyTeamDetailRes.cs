using System;

namespace Protocol
{
	// Token: 0x02000BE6 RID: 3046
	[Protocol]
	public class TeamCopyTeamDetailRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007FB4 RID: 32692 RVA: 0x00169FA0 File Offset: 0x001683A0
		public uint GetMsgID()
		{
			return 1100044U;
		}

		// Token: 0x06007FB5 RID: 32693 RVA: 0x00169FA7 File Offset: 0x001683A7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007FB6 RID: 32694 RVA: 0x00169FAF File Offset: 0x001683AF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007FB7 RID: 32695 RVA: 0x00169FB8 File Offset: 0x001683B8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamModel);
			byte[] str = StringHelper.StringToUTF8Bytes(this.teamName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalCommission);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bonusCommission);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.squadList.Length);
			for (int i = 0; i < this.squadList.Length; i++)
			{
				this.squadList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007FB8 RID: 32696 RVA: 0x0016A060 File Offset: 0x00168460
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamModel);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.teamName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalCommission);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bonusCommission);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.squadList = new SquadData[(int)num2];
			for (int j = 0; j < this.squadList.Length; j++)
			{
				this.squadList[j] = new SquadData();
				this.squadList[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007FB9 RID: 32697 RVA: 0x0016A148 File Offset: 0x00168548
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamModel);
			byte[] str = StringHelper.StringToUTF8Bytes(this.teamName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalCommission);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bonusCommission);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.squadList.Length);
			for (int i = 0; i < this.squadList.Length; i++)
			{
				this.squadList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007FBA RID: 32698 RVA: 0x0016A1F4 File Offset: 0x001685F4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamModel);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.teamName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalCommission);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bonusCommission);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.squadList = new SquadData[(int)num2];
			for (int j = 0; j < this.squadList.Length; j++)
			{
				this.squadList[j] = new SquadData();
				this.squadList[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007FBB RID: 32699 RVA: 0x0016A2DC File Offset: 0x001686DC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.teamName);
			num += 2 + array.Length;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.squadList.Length; i++)
			{
				num += this.squadList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003CF2 RID: 15602
		public const uint MsgID = 1100044U;

		// Token: 0x04003CF3 RID: 15603
		public uint Sequence;

		// Token: 0x04003CF4 RID: 15604
		public uint teamId;

		// Token: 0x04003CF5 RID: 15605
		public uint teamType;

		// Token: 0x04003CF6 RID: 15606
		public uint teamModel;

		// Token: 0x04003CF7 RID: 15607
		public string teamName;

		// Token: 0x04003CF8 RID: 15608
		public uint totalCommission;

		// Token: 0x04003CF9 RID: 15609
		public uint bonusCommission;

		// Token: 0x04003CFA RID: 15610
		public SquadData[] squadList = new SquadData[0];
	}
}
