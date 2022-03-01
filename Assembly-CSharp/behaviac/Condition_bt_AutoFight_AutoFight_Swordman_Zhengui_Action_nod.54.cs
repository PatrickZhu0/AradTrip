using System;

namespace behaviac
{
	// Token: 0x020029C3 RID: 10691
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node55 : Condition
	{
		// Token: 0x06013CBA RID: 81082 RVA: 0x005EB57F File Offset: 0x005E997F
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node55()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013CBB RID: 81083 RVA: 0x005EB5B4 File Offset: 0x005E99B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D727 RID: 55079
		private int opl_p0;

		// Token: 0x0400D728 RID: 55080
		private int opl_p1;

		// Token: 0x0400D729 RID: 55081
		private int opl_p2;

		// Token: 0x0400D72A RID: 55082
		private int opl_p3;
	}
}
