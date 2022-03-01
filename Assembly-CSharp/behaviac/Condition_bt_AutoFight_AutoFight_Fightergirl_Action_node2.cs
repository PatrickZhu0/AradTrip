using System;

namespace behaviac
{
	// Token: 0x02001ECF RID: 7887
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node2 : Condition
	{
		// Token: 0x06012743 RID: 75587 RVA: 0x005660AC File Offset: 0x005644AC
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node2()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012744 RID: 75588 RVA: 0x005660E0 File Offset: 0x005644E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C133 RID: 49459
		private int opl_p0;

		// Token: 0x0400C134 RID: 49460
		private int opl_p1;

		// Token: 0x0400C135 RID: 49461
		private int opl_p2;

		// Token: 0x0400C136 RID: 49462
		private int opl_p3;
	}
}
