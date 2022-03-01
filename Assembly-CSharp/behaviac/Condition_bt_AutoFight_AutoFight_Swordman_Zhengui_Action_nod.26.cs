using System;

namespace behaviac
{
	// Token: 0x0200299F RID: 10655
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node70 : Condition
	{
		// Token: 0x06013C72 RID: 81010 RVA: 0x005EA67D File Offset: 0x005E8A7D
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node70()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013C73 RID: 81011 RVA: 0x005EA6B0 File Offset: 0x005E8AB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6DD RID: 55005
		private int opl_p0;

		// Token: 0x0400D6DE RID: 55006
		private int opl_p1;

		// Token: 0x0400D6DF RID: 55007
		private int opl_p2;

		// Token: 0x0400D6E0 RID: 55008
		private int opl_p3;
	}
}
