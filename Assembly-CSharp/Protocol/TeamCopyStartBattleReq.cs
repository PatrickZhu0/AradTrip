using System;

namespace Protocol
{
	// Token: 0x02000BC5 RID: 3013
	[Protocol]
	public class TeamCopyStartBattleReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007E9A RID: 32410 RVA: 0x0016770C File Offset: 0x00165B0C
		public uint GetMsgID()
		{
			return 1100013U;
		}

		// Token: 0x06007E9B RID: 32411 RVA: 0x00167713 File Offset: 0x00165B13
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007E9C RID: 32412 RVA: 0x0016771B File Offset: 0x00165B1B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007E9D RID: 32413 RVA: 0x00167724 File Offset: 0x00165B24
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.planModel);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.battlePlanList.Length);
			for (int i = 0; i < this.battlePlanList.Length; i++)
			{
				this.battlePlanList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007E9E RID: 32414 RVA: 0x00167778 File Offset: 0x00165B78
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.planModel);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.battlePlanList = new TeamCopyBattlePlan[(int)num];
			for (int i = 0; i < this.battlePlanList.Length; i++)
			{
				this.battlePlanList[i] = new TeamCopyBattlePlan();
				this.battlePlanList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007E9F RID: 32415 RVA: 0x001677E0 File Offset: 0x00165BE0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.planModel);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.battlePlanList.Length);
			for (int i = 0; i < this.battlePlanList.Length; i++)
			{
				this.battlePlanList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007EA0 RID: 32416 RVA: 0x00167834 File Offset: 0x00165C34
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.planModel);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.battlePlanList = new TeamCopyBattlePlan[(int)num];
			for (int i = 0; i < this.battlePlanList.Length; i++)
			{
				this.battlePlanList[i] = new TeamCopyBattlePlan();
				this.battlePlanList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007EA1 RID: 32417 RVA: 0x0016789C File Offset: 0x00165C9C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.battlePlanList.Length; i++)
			{
				num += this.battlePlanList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003C73 RID: 15475
		public const uint MsgID = 1100013U;

		// Token: 0x04003C74 RID: 15476
		public uint Sequence;

		// Token: 0x04003C75 RID: 15477
		public uint planModel;

		// Token: 0x04003C76 RID: 15478
		public TeamCopyBattlePlan[] battlePlanList = new TeamCopyBattlePlan[0];
	}
}
