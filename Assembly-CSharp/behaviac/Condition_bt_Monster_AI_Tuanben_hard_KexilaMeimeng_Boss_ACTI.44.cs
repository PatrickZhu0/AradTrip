using System;

namespace behaviac
{
	// Token: 0x02003C4C RID: 15436
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node10 : Condition
	{
		// Token: 0x06016042 RID: 90178 RVA: 0x006A6FE1 File Offset: 0x006A53E1
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node10()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016043 RID: 90179 RVA: 0x006A7018 File Offset: 0x006A5418
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8B7 RID: 63671
		private int opl_p0;

		// Token: 0x0400F8B8 RID: 63672
		private int opl_p1;

		// Token: 0x0400F8B9 RID: 63673
		private int opl_p2;

		// Token: 0x0400F8BA RID: 63674
		private int opl_p3;
	}
}
