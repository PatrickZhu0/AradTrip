using System;

namespace behaviac
{
	// Token: 0x02002103 RID: 8451
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node3 : Condition
	{
		// Token: 0x06012B99 RID: 76697 RVA: 0x0058098B File Offset: 0x0057ED8B
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node3()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012B9A RID: 76698 RVA: 0x005809C0 File Offset: 0x0057EDC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C58B RID: 50571
		private int opl_p0;

		// Token: 0x0400C58C RID: 50572
		private int opl_p1;

		// Token: 0x0400C58D RID: 50573
		private int opl_p2;

		// Token: 0x0400C58E RID: 50574
		private int opl_p3;
	}
}
