using System;

namespace behaviac
{
	// Token: 0x020031AB RID: 12715
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node21 : Condition
	{
		// Token: 0x06014BE9 RID: 84969 RVA: 0x0063F45E File Offset: 0x0063D85E
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node21()
		{
			this.opl_p0 = 0.55f;
		}

		// Token: 0x06014BEA RID: 84970 RVA: 0x0063F474 File Offset: 0x0063D874
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E551 RID: 58705
		private float opl_p0;
	}
}
