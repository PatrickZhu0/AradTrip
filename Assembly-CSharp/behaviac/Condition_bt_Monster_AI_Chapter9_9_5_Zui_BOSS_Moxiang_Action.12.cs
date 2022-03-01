using System;

namespace behaviac
{
	// Token: 0x020031A9 RID: 12713
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node18 : Condition
	{
		// Token: 0x06014BE5 RID: 84965 RVA: 0x0063F36B File Offset: 0x0063D76B
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node18()
		{
			this.opl_p0 = 21547;
		}

		// Token: 0x06014BE6 RID: 84966 RVA: 0x0063F380 File Offset: 0x0063D780
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E54E RID: 58702
		private int opl_p0;
	}
}
