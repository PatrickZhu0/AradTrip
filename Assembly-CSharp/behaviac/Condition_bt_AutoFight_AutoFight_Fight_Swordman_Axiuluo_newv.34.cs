using System;

namespace behaviac
{
	// Token: 0x0200222E RID: 8750
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node23 : Condition
	{
		// Token: 0x06012DE6 RID: 77286 RVA: 0x0058EC22 File Offset: 0x0058D022
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node23()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06012DE7 RID: 77287 RVA: 0x0058EC38 File Offset: 0x0058D038
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7E5 RID: 51173
		private float opl_p0;
	}
}
