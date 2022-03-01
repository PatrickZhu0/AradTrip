using System;

namespace behaviac
{
	// Token: 0x02002FA8 RID: 12200
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node74 : Condition
	{
		// Token: 0x0601481E RID: 83998 RVA: 0x0062B423 File Offset: 0x00629823
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node74()
		{
			this.opl_p0 = 5531;
		}

		// Token: 0x0601481F RID: 83999 RVA: 0x0062B438 File Offset: 0x00629838
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E17F RID: 57727
		private int opl_p0;
	}
}
