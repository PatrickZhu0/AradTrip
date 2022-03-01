using System;

namespace behaviac
{
	// Token: 0x02001F0F RID: 7951
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node15 : Condition
	{
		// Token: 0x060127C2 RID: 75714 RVA: 0x00568662 File Offset: 0x00566A62
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node15()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 4000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x060127C3 RID: 75715 RVA: 0x00568698 File Offset: 0x00566A98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1B7 RID: 49591
		private int opl_p0;

		// Token: 0x0400C1B8 RID: 49592
		private int opl_p1;

		// Token: 0x0400C1B9 RID: 49593
		private int opl_p2;

		// Token: 0x0400C1BA RID: 49594
		private int opl_p3;
	}
}
