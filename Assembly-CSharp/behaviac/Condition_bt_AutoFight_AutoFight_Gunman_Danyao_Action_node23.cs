using System;

namespace behaviac
{
	// Token: 0x0200259D RID: 9629
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node23 : Condition
	{
		// Token: 0x06013481 RID: 78977 RVA: 0x005BBF97 File Offset: 0x005BA397
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node23()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x06013482 RID: 78978 RVA: 0x005BBFCC File Offset: 0x005BA3CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEB5 RID: 52917
		private int opl_p0;

		// Token: 0x0400CEB6 RID: 52918
		private int opl_p1;

		// Token: 0x0400CEB7 RID: 52919
		private int opl_p2;

		// Token: 0x0400CEB8 RID: 52920
		private int opl_p3;
	}
}
