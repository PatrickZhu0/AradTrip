using System;

namespace behaviac
{
	// Token: 0x020033A7 RID: 13223
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node21 : Condition
	{
		// Token: 0x06014FA9 RID: 85929 RVA: 0x00651F59 File Offset: 0x00650359
		public Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node21()
		{
			this.opl_p0 = 5807;
		}

		// Token: 0x06014FAA RID: 85930 RVA: 0x00651F6C File Offset: 0x0065036C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E88A RID: 59530
		private int opl_p0;
	}
}
