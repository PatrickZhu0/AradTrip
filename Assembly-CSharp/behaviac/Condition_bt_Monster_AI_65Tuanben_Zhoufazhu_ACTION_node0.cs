using System;

namespace behaviac
{
	// Token: 0x02002F24 RID: 12068
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node0 : Condition
	{
		// Token: 0x0601471D RID: 83741 RVA: 0x00626927 File Offset: 0x00624D27
		public Condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node0()
		{
			this.opl_p0 = 600;
			this.opl_p1 = 600;
			this.opl_p2 = 0;
			this.opl_p3 = 90000;
		}

		// Token: 0x0601471E RID: 83742 RVA: 0x00626958 File Offset: 0x00624D58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E091 RID: 57489
		private int opl_p0;

		// Token: 0x0400E092 RID: 57490
		private int opl_p1;

		// Token: 0x0400E093 RID: 57491
		private int opl_p2;

		// Token: 0x0400E094 RID: 57492
		private int opl_p3;
	}
}
