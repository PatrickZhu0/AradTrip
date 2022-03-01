using System;

namespace behaviac
{
	// Token: 0x02003466 RID: 13414
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node45 : Condition
	{
		// Token: 0x06015117 RID: 86295 RVA: 0x0065943D File Offset: 0x0065783D
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node45()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06015118 RID: 86296 RVA: 0x00659474 File Offset: 0x00657874
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA16 RID: 59926
		private int opl_p0;

		// Token: 0x0400EA17 RID: 59927
		private int opl_p1;

		// Token: 0x0400EA18 RID: 59928
		private int opl_p2;

		// Token: 0x0400EA19 RID: 59929
		private int opl_p3;
	}
}
