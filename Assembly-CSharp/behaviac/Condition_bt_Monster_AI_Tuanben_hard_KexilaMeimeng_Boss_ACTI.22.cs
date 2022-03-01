using System;

namespace behaviac
{
	// Token: 0x02003C27 RID: 15399
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node64 : Condition
	{
		// Token: 0x06015FF9 RID: 90105 RVA: 0x006A5566 File Offset: 0x006A3966
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node64()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 2500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06015FFA RID: 90106 RVA: 0x006A559C File Offset: 0x006A399C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F876 RID: 63606
		private int opl_p0;

		// Token: 0x0400F877 RID: 63607
		private int opl_p1;

		// Token: 0x0400F878 RID: 63608
		private int opl_p2;

		// Token: 0x0400F879 RID: 63609
		private int opl_p3;
	}
}
