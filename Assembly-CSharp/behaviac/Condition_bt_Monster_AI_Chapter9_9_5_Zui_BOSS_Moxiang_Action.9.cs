using System;

namespace behaviac
{
	// Token: 0x020031A5 RID: 12709
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node77 : Condition
	{
		// Token: 0x06014BDD RID: 84957 RVA: 0x0063F1CF File Offset: 0x0063D5CF
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node77()
		{
			this.opl_p0 = 21550;
		}

		// Token: 0x06014BDE RID: 84958 RVA: 0x0063F1E4 File Offset: 0x0063D5E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E547 RID: 58695
		private int opl_p0;
	}
}
