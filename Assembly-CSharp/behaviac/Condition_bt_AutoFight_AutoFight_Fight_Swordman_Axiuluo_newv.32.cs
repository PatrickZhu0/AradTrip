using System;

namespace behaviac
{
	// Token: 0x0200222B RID: 8747
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node21 : Condition
	{
		// Token: 0x06012DE0 RID: 77280 RVA: 0x0058EA64 File Offset: 0x0058CE64
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node21()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
			this.opl_p4 = 10000;
			this.opl_p5 = 1000;
			this.opl_p6 = 3000;
			this.opl_p7 = 3000;
		}

		// Token: 0x06012DE1 RID: 77281 RVA: 0x0058EAD0 File Offset: 0x0058CED0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7DA RID: 51162
		private int opl_p0;

		// Token: 0x0400C7DB RID: 51163
		private int opl_p1;

		// Token: 0x0400C7DC RID: 51164
		private int opl_p2;

		// Token: 0x0400C7DD RID: 51165
		private int opl_p3;

		// Token: 0x0400C7DE RID: 51166
		private int opl_p4;

		// Token: 0x0400C7DF RID: 51167
		private int opl_p5;

		// Token: 0x0400C7E0 RID: 51168
		private int opl_p6;

		// Token: 0x0400C7E1 RID: 51169
		private int opl_p7;
	}
}
