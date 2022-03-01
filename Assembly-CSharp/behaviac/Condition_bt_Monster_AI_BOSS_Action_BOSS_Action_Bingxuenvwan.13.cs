using System;

namespace behaviac
{
	// Token: 0x02002F7E RID: 12158
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node19 : Condition
	{
		// Token: 0x060147CA RID: 83914 RVA: 0x0062A382 File Offset: 0x00628782
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node19()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060147CB RID: 83915 RVA: 0x0062A3B8 File Offset: 0x006287B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E132 RID: 57650
		private int opl_p0;

		// Token: 0x0400E133 RID: 57651
		private int opl_p1;

		// Token: 0x0400E134 RID: 57652
		private int opl_p2;

		// Token: 0x0400E135 RID: 57653
		private int opl_p3;
	}
}
