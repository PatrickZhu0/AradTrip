using System;

namespace behaviac
{
	// Token: 0x02002F9C RID: 12188
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node49 : Condition
	{
		// Token: 0x06014806 RID: 83974 RVA: 0x0062AF6A File Offset: 0x0062936A
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node49()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014807 RID: 83975 RVA: 0x0062AFA0 File Offset: 0x006293A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E168 RID: 57704
		private int opl_p0;

		// Token: 0x0400E169 RID: 57705
		private int opl_p1;

		// Token: 0x0400E16A RID: 57706
		private int opl_p2;

		// Token: 0x0400E16B RID: 57707
		private int opl_p3;
	}
}
