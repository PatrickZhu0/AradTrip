using System;

namespace behaviac
{
	// Token: 0x0200339E RID: 13214
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node16 : Condition
	{
		// Token: 0x06014F97 RID: 85911 RVA: 0x00651B73 File Offset: 0x0064FF73
		public Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node16()
		{
			this.opl_p0 = 5804;
		}

		// Token: 0x06014F98 RID: 85912 RVA: 0x00651B88 File Offset: 0x0064FF88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E873 RID: 59507
		private int opl_p0;
	}
}
