using System;

namespace Protocol
{
	// Token: 0x02000B5C RID: 2908
	[Protocol]
	public class SceneChangeSkillsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007BDF RID: 31711 RVA: 0x001629A8 File Offset: 0x00160DA8
		public uint GetMsgID()
		{
			return 500701U;
		}

		// Token: 0x06007BE0 RID: 31712 RVA: 0x001629AF File Offset: 0x00160DAF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007BE1 RID: 31713 RVA: 0x001629B7 File Offset: 0x00160DB7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007BE2 RID: 31714 RVA: 0x001629C0 File Offset: 0x00160DC0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.configType);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skills.Length);
			for (int i = 0; i < this.skills.Length; i++)
			{
				this.skills[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007BE3 RID: 31715 RVA: 0x00162A14 File Offset: 0x00160E14
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.configType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.skills = new ChangeSkill[(int)num];
			for (int i = 0; i < this.skills.Length; i++)
			{
				this.skills[i] = new ChangeSkill();
				this.skills[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007BE4 RID: 31716 RVA: 0x00162A7C File Offset: 0x00160E7C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.configType);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skills.Length);
			for (int i = 0; i < this.skills.Length; i++)
			{
				this.skills[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007BE5 RID: 31717 RVA: 0x00162AD0 File Offset: 0x00160ED0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.configType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.skills = new ChangeSkill[(int)num];
			for (int i = 0; i < this.skills.Length; i++)
			{
				this.skills[i] = new ChangeSkill();
				this.skills[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007BE6 RID: 31718 RVA: 0x00162B38 File Offset: 0x00160F38
		public int getLen()
		{
			int num = 0;
			num++;
			num += 2;
			for (int i = 0; i < this.skills.Length; i++)
			{
				num += this.skills[i].getLen();
			}
			return num;
		}

		// Token: 0x04003AB6 RID: 15030
		public const uint MsgID = 500701U;

		// Token: 0x04003AB7 RID: 15031
		public uint Sequence;

		// Token: 0x04003AB8 RID: 15032
		public byte configType;

		// Token: 0x04003AB9 RID: 15033
		public ChangeSkill[] skills = new ChangeSkill[0];
	}
}
