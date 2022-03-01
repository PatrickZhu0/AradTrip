using System;

namespace behaviac
{
	// Token: 0x020031B2 RID: 12722
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node42 : Condition
	{
		// Token: 0x06014BF7 RID: 84983 RVA: 0x0063F71F File Offset: 0x0063DB1F
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node42()
		{
			this.opl_p0 = 21550;
		}

		// Token: 0x06014BF8 RID: 84984 RVA: 0x0063F734 File Offset: 0x0063DB34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E55A RID: 58714
		private int opl_p0;
	}
}
