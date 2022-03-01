using System;

namespace behaviac
{
	// Token: 0x020020E2 RID: 8418
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node22 : Condition
	{
		// Token: 0x06012B59 RID: 76633 RVA: 0x0057EC42 File Offset: 0x0057D042
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node22()
		{
			this.opl_p0 = 0.28f;
		}

		// Token: 0x06012B5A RID: 76634 RVA: 0x0057EC58 File Offset: 0x0057D058
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C54C RID: 50508
		private float opl_p0;
	}
}
