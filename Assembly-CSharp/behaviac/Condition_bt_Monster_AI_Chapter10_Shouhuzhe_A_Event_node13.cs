using System;

namespace behaviac
{
	// Token: 0x0200312A RID: 12586
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node13 : Condition
	{
		// Token: 0x06014AF9 RID: 84729 RVA: 0x0063A987 File Offset: 0x00638D87
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node13()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x06014AFA RID: 84730 RVA: 0x0063A9A8 File Offset: 0x00638DA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E46D RID: 58477
		private HMType opl_p0;

		// Token: 0x0400E46E RID: 58478
		private BE_Operation opl_p1;

		// Token: 0x0400E46F RID: 58479
		private float opl_p2;
	}
}
