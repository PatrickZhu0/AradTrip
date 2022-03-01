using System;

namespace behaviac
{
	// Token: 0x02001EFE RID: 7934
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node5 : Condition
	{
		// Token: 0x060127A0 RID: 75680 RVA: 0x00567F42 File Offset: 0x00566342
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node5()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 0;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060127A1 RID: 75681 RVA: 0x00567F74 File Offset: 0x00566374
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C194 RID: 49556
		private int opl_p0;

		// Token: 0x0400C195 RID: 49557
		private int opl_p1;

		// Token: 0x0400C196 RID: 49558
		private int opl_p2;

		// Token: 0x0400C197 RID: 49559
		private int opl_p3;
	}
}
