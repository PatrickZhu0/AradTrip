using System;

namespace behaviac
{
	// Token: 0x02002D84 RID: 11652
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node19 : Condition
	{
		// Token: 0x060143EA RID: 82922 RVA: 0x00614A3B File Offset: 0x00612E3B
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node19()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060143EB RID: 82923 RVA: 0x00614A70 File Offset: 0x00612E70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDBB RID: 56763
		private int opl_p0;

		// Token: 0x0400DDBC RID: 56764
		private int opl_p1;

		// Token: 0x0400DDBD RID: 56765
		private int opl_p2;

		// Token: 0x0400DDBE RID: 56766
		private int opl_p3;
	}
}
