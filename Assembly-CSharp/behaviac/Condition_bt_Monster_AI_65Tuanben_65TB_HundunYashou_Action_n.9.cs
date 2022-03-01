using System;

namespace behaviac
{
	// Token: 0x02002B90 RID: 11152
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node21 : Condition
	{
		// Token: 0x0601402C RID: 81964 RVA: 0x0060227D File Offset: 0x0060067D
		public Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node21()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 5500;
			this.opl_p2 = 5500;
			this.opl_p3 = 5500;
		}

		// Token: 0x0601402D RID: 81965 RVA: 0x006022B4 File Offset: 0x006006B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA21 RID: 55841
		private int opl_p0;

		// Token: 0x0400DA22 RID: 55842
		private int opl_p1;

		// Token: 0x0400DA23 RID: 55843
		private int opl_p2;

		// Token: 0x0400DA24 RID: 55844
		private int opl_p3;
	}
}
