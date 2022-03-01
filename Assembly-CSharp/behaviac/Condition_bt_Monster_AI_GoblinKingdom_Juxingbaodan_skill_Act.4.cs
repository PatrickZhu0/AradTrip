using System;

namespace behaviac
{
	// Token: 0x02003399 RID: 13209
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node3 : Condition
	{
		// Token: 0x06014F8D RID: 85901 RVA: 0x00651977 File Offset: 0x0064FD77
		public Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node3()
		{
			this.opl_p0 = 5804;
		}

		// Token: 0x06014F8E RID: 85902 RVA: 0x0065198C File Offset: 0x0064FD8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E869 RID: 59497
		private int opl_p0;
	}
}
