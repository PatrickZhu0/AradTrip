using System;

namespace behaviac
{
	// Token: 0x02002ED9 RID: 11993
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node69 : Condition
	{
		// Token: 0x0601468C RID: 83596 RVA: 0x00622CFE File Offset: 0x006210FE
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node69()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x0601468D RID: 83597 RVA: 0x00622D20 File Offset: 0x00621120
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFFD RID: 57341
		private HMType opl_p0;

		// Token: 0x0400DFFE RID: 57342
		private BE_Operation opl_p1;

		// Token: 0x0400DFFF RID: 57343
		private float opl_p2;
	}
}
