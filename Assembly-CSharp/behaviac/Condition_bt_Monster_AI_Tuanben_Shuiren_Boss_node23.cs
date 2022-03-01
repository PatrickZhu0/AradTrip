using System;

namespace behaviac
{
	// Token: 0x02003B35 RID: 15157
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node23 : Condition
	{
		// Token: 0x06015E22 RID: 89634 RVA: 0x0069C609 File Offset: 0x0069AA09
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node23()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.2f;
		}

		// Token: 0x06015E23 RID: 89635 RVA: 0x0069C62C File Offset: 0x0069AA2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F701 RID: 63233
		private HMType opl_p0;

		// Token: 0x0400F702 RID: 63234
		private BE_Operation opl_p1;

		// Token: 0x0400F703 RID: 63235
		private float opl_p2;
	}
}
