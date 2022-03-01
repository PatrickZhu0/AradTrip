using System;

namespace behaviac
{
	// Token: 0x020031AC RID: 12716
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node22 : Condition
	{
		// Token: 0x06014BEB RID: 84971 RVA: 0x0063F4A7 File Offset: 0x0063D8A7
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node22()
		{
			this.opl_p0 = 21549;
		}

		// Token: 0x06014BEC RID: 84972 RVA: 0x0063F4BC File Offset: 0x0063D8BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E552 RID: 58706
		private int opl_p0;
	}
}
