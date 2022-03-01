using System;

namespace behaviac
{
	// Token: 0x020030BB RID: 12475
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node1 : Condition
	{
		// Token: 0x06014A34 RID: 84532 RVA: 0x00636F24 File Offset: 0x00635324
		public Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06014A35 RID: 84533 RVA: 0x00636F48 File Offset: 0x00635348
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E398 RID: 58264
		private HMType opl_p0;

		// Token: 0x0400E399 RID: 58265
		private BE_Operation opl_p1;

		// Token: 0x0400E39A RID: 58266
		private float opl_p2;
	}
}
