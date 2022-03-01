using System;

namespace behaviac
{
	// Token: 0x02002FA6 RID: 12198
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node59 : Condition
	{
		// Token: 0x0601481A RID: 83994 RVA: 0x0062B362 File Offset: 0x00629762
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node59()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601481B RID: 83995 RVA: 0x0062B398 File Offset: 0x00629798
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E17A RID: 57722
		private int opl_p0;

		// Token: 0x0400E17B RID: 57723
		private int opl_p1;

		// Token: 0x0400E17C RID: 57724
		private int opl_p2;

		// Token: 0x0400E17D RID: 57725
		private int opl_p3;
	}
}
