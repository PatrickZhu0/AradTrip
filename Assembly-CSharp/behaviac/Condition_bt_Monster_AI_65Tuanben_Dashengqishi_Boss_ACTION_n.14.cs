using System;

namespace behaviac
{
	// Token: 0x02002D9C RID: 11676
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node35 : Condition
	{
		// Token: 0x06014419 RID: 82969 RVA: 0x00615C7F File Offset: 0x0061407F
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node35()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x0601441A RID: 82970 RVA: 0x00615CA0 File Offset: 0x006140A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDE0 RID: 56800
		private HMType opl_p0;

		// Token: 0x0400DDE1 RID: 56801
		private BE_Operation opl_p1;

		// Token: 0x0400DDE2 RID: 56802
		private float opl_p2;
	}
}
