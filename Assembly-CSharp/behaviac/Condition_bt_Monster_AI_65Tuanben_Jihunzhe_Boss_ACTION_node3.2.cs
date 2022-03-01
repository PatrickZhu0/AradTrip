using System;

namespace behaviac
{
	// Token: 0x02002F0A RID: 12042
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node35 : Condition
	{
		// Token: 0x060146EB RID: 83691 RVA: 0x00625710 File Offset: 0x00623B10
		public Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node35()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.8f;
		}

		// Token: 0x060146EC RID: 83692 RVA: 0x00625734 File Offset: 0x00623B34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E062 RID: 57442
		private HMType opl_p0;

		// Token: 0x0400E063 RID: 57443
		private BE_Operation opl_p1;

		// Token: 0x0400E064 RID: 57444
		private float opl_p2;
	}
}
