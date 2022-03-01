using System;

namespace behaviac
{
	// Token: 0x02002583 RID: 9603
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node37 : Condition
	{
		// Token: 0x0601344E RID: 78926 RVA: 0x005BA5EB File Offset: 0x005B89EB
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node37()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601344F RID: 78927 RVA: 0x005BA620 File Offset: 0x005B8A20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE76 RID: 52854
		private int opl_p0;

		// Token: 0x0400CE77 RID: 52855
		private int opl_p1;

		// Token: 0x0400CE78 RID: 52856
		private int opl_p2;

		// Token: 0x0400CE79 RID: 52857
		private int opl_p3;
	}
}
