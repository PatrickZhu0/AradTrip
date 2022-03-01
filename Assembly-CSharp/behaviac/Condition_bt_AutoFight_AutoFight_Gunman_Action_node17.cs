using System;

namespace behaviac
{
	// Token: 0x02002573 RID: 9587
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node17 : Condition
	{
		// Token: 0x0601342E RID: 78894 RVA: 0x005B9E63 File Offset: 0x005B8263
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node17()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601342F RID: 78895 RVA: 0x005B9E98 File Offset: 0x005B8298
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE56 RID: 52822
		private int opl_p0;

		// Token: 0x0400CE57 RID: 52823
		private int opl_p1;

		// Token: 0x0400CE58 RID: 52824
		private int opl_p2;

		// Token: 0x0400CE59 RID: 52825
		private int opl_p3;
	}
}
