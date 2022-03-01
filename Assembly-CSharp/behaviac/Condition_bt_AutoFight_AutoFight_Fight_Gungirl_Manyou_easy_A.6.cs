using System;

namespace behaviac
{
	// Token: 0x02001FC8 RID: 8136
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node13 : Condition
	{
		// Token: 0x0601292D RID: 76077 RVA: 0x0057156B File Offset: 0x0056F96B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node13()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601292E RID: 76078 RVA: 0x005715A0 File Offset: 0x0056F9A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C31E RID: 49950
		private int opl_p0;

		// Token: 0x0400C31F RID: 49951
		private int opl_p1;

		// Token: 0x0400C320 RID: 49952
		private int opl_p2;

		// Token: 0x0400C321 RID: 49953
		private int opl_p3;
	}
}
