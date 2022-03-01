using System;

namespace behaviac
{
	// Token: 0x0200260C RID: 9740
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node60 : Condition
	{
		// Token: 0x0601355E RID: 79198 RVA: 0x005C09DF File Offset: 0x005BEDDF
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node60()
		{
			this.opl_p0 = 3800;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601355F RID: 79199 RVA: 0x005C0A14 File Offset: 0x005BEE14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFA9 RID: 53161
		private int opl_p0;

		// Token: 0x0400CFAA RID: 53162
		private int opl_p1;

		// Token: 0x0400CFAB RID: 53163
		private int opl_p2;

		// Token: 0x0400CFAC RID: 53164
		private int opl_p3;
	}
}
