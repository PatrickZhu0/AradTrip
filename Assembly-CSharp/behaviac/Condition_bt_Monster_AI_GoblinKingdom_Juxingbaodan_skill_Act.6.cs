using System;

namespace behaviac
{
	// Token: 0x0200339D RID: 13213
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node4 : Condition
	{
		// Token: 0x06014F95 RID: 85909 RVA: 0x00651B2D File Offset: 0x0064FF2D
		public Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node4()
		{
			this.opl_p0 = 5803;
		}

		// Token: 0x06014F96 RID: 85910 RVA: 0x00651B40 File Offset: 0x0064FF40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E872 RID: 59506
		private int opl_p0;
	}
}
