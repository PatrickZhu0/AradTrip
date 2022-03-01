using System;

namespace behaviac
{
	// Token: 0x02001EDD RID: 7901
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node8 : Condition
	{
		// Token: 0x0601275F RID: 75615 RVA: 0x0056668E File Offset: 0x00564A8E
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 0;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012760 RID: 75616 RVA: 0x005666C0 File Offset: 0x00564AC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C152 RID: 49490
		private int opl_p0;

		// Token: 0x0400C153 RID: 49491
		private int opl_p1;

		// Token: 0x0400C154 RID: 49492
		private int opl_p2;

		// Token: 0x0400C155 RID: 49493
		private int opl_p3;
	}
}
