using System;

namespace behaviac
{
	// Token: 0x020031B9 RID: 12729
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node84 : Condition
	{
		// Token: 0x06014C05 RID: 84997 RVA: 0x0063F9F7 File Offset: 0x0063DDF7
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node84()
		{
			this.opl_p0 = 21571;
		}

		// Token: 0x06014C06 RID: 84998 RVA: 0x0063FA0C File Offset: 0x0063DE0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E565 RID: 58725
		private int opl_p0;
	}
}
