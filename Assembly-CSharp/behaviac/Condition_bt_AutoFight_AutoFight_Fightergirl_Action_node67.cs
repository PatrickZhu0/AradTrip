using System;

namespace behaviac
{
	// Token: 0x02001ED9 RID: 7897
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node67 : Condition
	{
		// Token: 0x06012757 RID: 75607 RVA: 0x005664E5 File Offset: 0x005648E5
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node67()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 100;
			this.opl_p2 = 100;
			this.opl_p3 = 100;
		}

		// Token: 0x06012758 RID: 75608 RVA: 0x00566510 File Offset: 0x00564910
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C14A RID: 49482
		private int opl_p0;

		// Token: 0x0400C14B RID: 49483
		private int opl_p1;

		// Token: 0x0400C14C RID: 49484
		private int opl_p2;

		// Token: 0x0400C14D RID: 49485
		private int opl_p3;
	}
}
