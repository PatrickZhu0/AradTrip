using System;

namespace behaviac
{
	// Token: 0x02002D68 RID: 11624
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node10 : Condition
	{
		// Token: 0x060143B2 RID: 82866 RVA: 0x00613F00 File Offset: 0x00612300
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node10()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.15f;
		}

		// Token: 0x060143B3 RID: 82867 RVA: 0x00613F24 File Offset: 0x00612324
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD7B RID: 56699
		private HMType opl_p0;

		// Token: 0x0400DD7C RID: 56700
		private BE_Operation opl_p1;

		// Token: 0x0400DD7D RID: 56701
		private float opl_p2;
	}
}
