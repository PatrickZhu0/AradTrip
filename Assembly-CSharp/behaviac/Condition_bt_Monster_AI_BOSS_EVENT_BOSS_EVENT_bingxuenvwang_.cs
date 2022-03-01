using System;

namespace behaviac
{
	// Token: 0x020030B5 RID: 12469
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event_node1 : Condition
	{
		// Token: 0x06014A2A RID: 84522 RVA: 0x00636C07 File Offset: 0x00635007
		public Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.8f;
		}

		// Token: 0x06014A2B RID: 84523 RVA: 0x00636C28 File Offset: 0x00635028
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E388 RID: 58248
		private HMType opl_p0;

		// Token: 0x0400E389 RID: 58249
		private BE_Operation opl_p1;

		// Token: 0x0400E38A RID: 58250
		private float opl_p2;
	}
}
