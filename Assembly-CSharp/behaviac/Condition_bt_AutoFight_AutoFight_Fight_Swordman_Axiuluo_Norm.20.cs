using System;

namespace behaviac
{
	// Token: 0x0200225A RID: 8794
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node20 : Condition
	{
		// Token: 0x06012E3C RID: 77372 RVA: 0x005918BE File Offset: 0x0058FCBE
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node20()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012E3D RID: 77373 RVA: 0x005918D4 File Offset: 0x0058FCD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C845 RID: 51269
		private float opl_p0;
	}
}
