using System;

namespace behaviac
{
	// Token: 0x02002260 RID: 8800
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node13 : Condition
	{
		// Token: 0x06012E48 RID: 77384 RVA: 0x00591BA3 File Offset: 0x0058FFA3
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node13()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06012E49 RID: 77385 RVA: 0x00591BB8 File Offset: 0x0058FFB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C858 RID: 51288
		private float opl_p0;
	}
}
