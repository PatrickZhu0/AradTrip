using System;

namespace behaviac
{
	// Token: 0x020030B8 RID: 12472
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node1 : Condition
	{
		// Token: 0x06014A2F RID: 84527 RVA: 0x00636D94 File Offset: 0x00635194
		public Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06014A30 RID: 84528 RVA: 0x00636DB8 File Offset: 0x006351B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E390 RID: 58256
		private HMType opl_p0;

		// Token: 0x0400E391 RID: 58257
		private BE_Operation opl_p1;

		// Token: 0x0400E392 RID: 58258
		private float opl_p2;
	}
}
