using System;

namespace behaviac
{
	// Token: 0x02002156 RID: 8534
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node7 : Condition
	{
		// Token: 0x06012C3D RID: 76861 RVA: 0x00584716 File Offset: 0x00582B16
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node7()
		{
			this.opl_p0 = 0.75f;
		}

		// Token: 0x06012C3E RID: 76862 RVA: 0x0058472C File Offset: 0x00582B2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C630 RID: 50736
		private float opl_p0;
	}
}
