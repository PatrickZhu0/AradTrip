using System;

namespace behaviac
{
	// Token: 0x020031BC RID: 12732
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node85 : Condition
	{
		// Token: 0x06014C0B RID: 85003 RVA: 0x0063FB33 File Offset: 0x0063DF33
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node85()
		{
			this.opl_p0 = 21569;
		}

		// Token: 0x06014C0C RID: 85004 RVA: 0x0063FB48 File Offset: 0x0063DF48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E569 RID: 58729
		private int opl_p0;
	}
}
