using System;

namespace behaviac
{
	// Token: 0x02003684 RID: 13956
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node1 : Condition
	{
		// Token: 0x06015527 RID: 87335 RVA: 0x0066E7E6 File Offset: 0x0066CBE6
		public Condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06015528 RID: 87336 RVA: 0x0066E808 File Offset: 0x0066CC08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEE2 RID: 61154
		private HMType opl_p0;

		// Token: 0x0400EEE3 RID: 61155
		private BE_Operation opl_p1;

		// Token: 0x0400EEE4 RID: 61156
		private float opl_p2;
	}
}
