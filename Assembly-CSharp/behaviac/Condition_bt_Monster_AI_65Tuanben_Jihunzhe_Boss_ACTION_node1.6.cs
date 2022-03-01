using System;

namespace behaviac
{
	// Token: 0x02002F17 RID: 12055
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node19 : Condition
	{
		// Token: 0x06014705 RID: 83717 RVA: 0x00625CC7 File Offset: 0x006240C7
		public Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node19()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06014706 RID: 83718 RVA: 0x00625CFC File Offset: 0x006240FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E07C RID: 57468
		private int opl_p0;

		// Token: 0x0400E07D RID: 57469
		private int opl_p1;

		// Token: 0x0400E07E RID: 57470
		private int opl_p2;

		// Token: 0x0400E07F RID: 57471
		private int opl_p3;
	}
}
