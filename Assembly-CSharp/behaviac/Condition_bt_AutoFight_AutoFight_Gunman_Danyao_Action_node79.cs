using System;

namespace behaviac
{
	// Token: 0x020025E1 RID: 9697
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node79 : Condition
	{
		// Token: 0x06013509 RID: 79113 RVA: 0x005BDBBA File Offset: 0x005BBFBA
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node79()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601350A RID: 79114 RVA: 0x005BDBF0 File Offset: 0x005BBFF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF4D RID: 53069
		private int opl_p0;

		// Token: 0x0400CF4E RID: 53070
		private int opl_p1;

		// Token: 0x0400CF4F RID: 53071
		private int opl_p2;

		// Token: 0x0400CF50 RID: 53072
		private int opl_p3;
	}
}
