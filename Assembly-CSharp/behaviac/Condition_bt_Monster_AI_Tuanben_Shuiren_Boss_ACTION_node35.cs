using System;

namespace behaviac
{
	// Token: 0x02003B40 RID: 15168
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node35 : Condition
	{
		// Token: 0x06015E35 RID: 89653 RVA: 0x0069D3A9 File Offset: 0x0069B7A9
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node35()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x06015E36 RID: 89654 RVA: 0x0069D3CC File Offset: 0x0069B7CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F70F RID: 63247
		private HMType opl_p0;

		// Token: 0x0400F710 RID: 63248
		private BE_Operation opl_p1;

		// Token: 0x0400F711 RID: 63249
		private float opl_p2;
	}
}
