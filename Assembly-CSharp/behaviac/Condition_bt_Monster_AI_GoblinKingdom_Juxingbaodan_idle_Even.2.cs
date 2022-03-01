using System;

namespace behaviac
{
	// Token: 0x02003377 RID: 13175
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node1 : Condition
	{
		// Token: 0x06014F4B RID: 85835 RVA: 0x00650679 File Offset: 0x0064EA79
		public Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.75f;
		}

		// Token: 0x06014F4C RID: 85836 RVA: 0x0065069C File Offset: 0x0064EA9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E80F RID: 59407
		private HMType opl_p0;

		// Token: 0x0400E810 RID: 59408
		private BE_Operation opl_p1;

		// Token: 0x0400E811 RID: 59409
		private float opl_p2;
	}
}
