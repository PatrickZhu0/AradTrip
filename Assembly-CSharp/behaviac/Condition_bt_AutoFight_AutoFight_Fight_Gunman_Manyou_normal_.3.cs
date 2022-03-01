using System;

namespace behaviac
{
	// Token: 0x0200217E RID: 8574
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node7 : Condition
	{
		// Token: 0x06012C8C RID: 76940 RVA: 0x00586532 File Offset: 0x00584932
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node7()
		{
			this.opl_p0 = 0.47f;
		}

		// Token: 0x06012C8D RID: 76941 RVA: 0x00586548 File Offset: 0x00584948
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C67F RID: 50815
		private float opl_p0;
	}
}
