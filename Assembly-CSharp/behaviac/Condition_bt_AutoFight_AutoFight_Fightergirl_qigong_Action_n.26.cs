using System;

namespace behaviac
{
	// Token: 0x02001F14 RID: 7956
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node38 : Condition
	{
		// Token: 0x060127CC RID: 75724 RVA: 0x00568877 File Offset: 0x00566C77
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node38()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 0;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060127CD RID: 75725 RVA: 0x005688A8 File Offset: 0x00566CA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1C2 RID: 49602
		private int opl_p0;

		// Token: 0x0400C1C3 RID: 49603
		private int opl_p1;

		// Token: 0x0400C1C4 RID: 49604
		private int opl_p2;

		// Token: 0x0400C1C5 RID: 49605
		private int opl_p3;
	}
}
