using System;

namespace behaviac
{
	// Token: 0x02003398 RID: 13208
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node11 : Condition
	{
		// Token: 0x06014F8B RID: 85899 RVA: 0x0065192F File Offset: 0x0064FD2F
		public Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node11()
		{
			this.opl_p0 = 5803;
		}

		// Token: 0x06014F8C RID: 85900 RVA: 0x00651944 File Offset: 0x0064FD44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E868 RID: 59496
		private int opl_p0;
	}
}
