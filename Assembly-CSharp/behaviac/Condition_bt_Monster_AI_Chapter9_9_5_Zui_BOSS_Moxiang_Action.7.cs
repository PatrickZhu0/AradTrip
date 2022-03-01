using System;

namespace behaviac
{
	// Token: 0x020031A2 RID: 12706
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node75 : Condition
	{
		// Token: 0x06014BD7 RID: 84951 RVA: 0x0063F093 File Offset: 0x0063D493
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node75()
		{
			this.opl_p0 = 21548;
		}

		// Token: 0x06014BD8 RID: 84952 RVA: 0x0063F0A8 File Offset: 0x0063D4A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E543 RID: 58691
		private int opl_p0;
	}
}
