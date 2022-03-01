using System;

namespace behaviac
{
	// Token: 0x02003397 RID: 13207
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node1 : Condition
	{
		// Token: 0x06014F89 RID: 85897 RVA: 0x006518E9 File Offset: 0x0064FCE9
		public Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node1()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014F8A RID: 85898 RVA: 0x006518FC File Offset: 0x0064FCFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E867 RID: 59495
		private float opl_p0;
	}
}
