using System;

namespace behaviac
{
	// Token: 0x02002ED5 RID: 11989
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node66 : Condition
	{
		// Token: 0x06014684 RID: 83588 RVA: 0x00622B33 File Offset: 0x00620F33
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node66()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x06014685 RID: 83589 RVA: 0x00622B54 File Offset: 0x00620F54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFF3 RID: 57331
		private HMType opl_p0;

		// Token: 0x0400DFF4 RID: 57332
		private BE_Operation opl_p1;

		// Token: 0x0400DFF5 RID: 57333
		private float opl_p2;
	}
}
