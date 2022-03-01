using System;

namespace behaviac
{
	// Token: 0x0200259E RID: 9630
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node40 : Condition
	{
		// Token: 0x06013483 RID: 78979 RVA: 0x005BC011 File Offset: 0x005BA411
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node40()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06013484 RID: 78980 RVA: 0x005BC024 File Offset: 0x005BA424
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEB9 RID: 52921
		private float opl_p0;
	}
}
