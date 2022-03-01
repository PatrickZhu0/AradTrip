using System;

namespace behaviac
{
	// Token: 0x0200261A RID: 9754
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node43 : Condition
	{
		// Token: 0x0601357A RID: 79226 RVA: 0x005C109B File Offset: 0x005BF49B
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node43()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 1800;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x0601357B RID: 79227 RVA: 0x005C10D0 File Offset: 0x005BF4D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFC3 RID: 53187
		private int opl_p0;

		// Token: 0x0400CFC4 RID: 53188
		private int opl_p1;

		// Token: 0x0400CFC5 RID: 53189
		private int opl_p2;

		// Token: 0x0400CFC6 RID: 53190
		private int opl_p3;
	}
}
