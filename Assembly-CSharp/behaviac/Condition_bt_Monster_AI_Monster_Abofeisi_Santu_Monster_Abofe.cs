using System;

namespace behaviac
{
	// Token: 0x020035E1 RID: 13793
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Abofeisi_Santu_Monster_Abofeisi_Santu_Event_node3 : Condition
	{
		// Token: 0x060153EA RID: 87018 RVA: 0x006677CA File Offset: 0x00665BCA
		public Condition_bt_Monster_AI_Monster_Abofeisi_Santu_Monster_Abofeisi_Santu_Event_node3()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x060153EB RID: 87019 RVA: 0x00667800 File Offset: 0x00665C00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDA9 RID: 60841
		private int opl_p0;

		// Token: 0x0400EDAA RID: 60842
		private int opl_p1;

		// Token: 0x0400EDAB RID: 60843
		private int opl_p2;

		// Token: 0x0400EDAC RID: 60844
		private int opl_p3;
	}
}
