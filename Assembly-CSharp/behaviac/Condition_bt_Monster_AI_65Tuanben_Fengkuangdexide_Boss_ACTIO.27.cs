using System;

namespace behaviac
{
	// Token: 0x02002ED4 RID: 11988
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node65 : Condition
	{
		// Token: 0x06014682 RID: 83586 RVA: 0x00622AD0 File Offset: 0x00620ED0
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node65()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 1f;
		}

		// Token: 0x06014683 RID: 83587 RVA: 0x00622AF4 File Offset: 0x00620EF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFF0 RID: 57328
		private HMType opl_p0;

		// Token: 0x0400DFF1 RID: 57329
		private BE_Operation opl_p1;

		// Token: 0x0400DFF2 RID: 57330
		private float opl_p2;
	}
}
