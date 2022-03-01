using System;

namespace behaviac
{
	// Token: 0x02002243 RID: 8771
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node5 : Condition
	{
		// Token: 0x06012E0E RID: 77326 RVA: 0x0059087B File Offset: 0x0058EC7B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node5()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012E0F RID: 77327 RVA: 0x00590890 File Offset: 0x0058EC90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C808 RID: 51208
		private float opl_p0;
	}
}
