using System;

namespace behaviac
{
	// Token: 0x020030C1 RID: 12481
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_geliya_zhaohuan_event_node1 : Condition
	{
		// Token: 0x06014A3E RID: 84542 RVA: 0x00637244 File Offset: 0x00635644
		public Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_geliya_zhaohuan_event_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06014A3F RID: 84543 RVA: 0x00637268 File Offset: 0x00635668
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3A8 RID: 58280
		private HMType opl_p0;

		// Token: 0x0400E3A9 RID: 58281
		private BE_Operation opl_p1;

		// Token: 0x0400E3AA RID: 58282
		private float opl_p2;
	}
}
