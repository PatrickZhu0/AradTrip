using System;

namespace behaviac
{
	// Token: 0x020035B5 RID: 13749
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node2 : Condition
	{
		// Token: 0x06015397 RID: 86935 RVA: 0x00665C4B File Offset: 0x0066404B
		public Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node2()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015398 RID: 86936 RVA: 0x00665C80 File Offset: 0x00664080
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED61 RID: 60769
		private int opl_p0;

		// Token: 0x0400ED62 RID: 60770
		private int opl_p1;

		// Token: 0x0400ED63 RID: 60771
		private int opl_p2;

		// Token: 0x0400ED64 RID: 60772
		private int opl_p3;
	}
}
