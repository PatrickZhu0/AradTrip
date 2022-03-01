using System;

namespace behaviac
{
	// Token: 0x02002126 RID: 8486
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node47 : Condition
	{
		// Token: 0x06012BDF RID: 76767 RVA: 0x00581A2A File Offset: 0x0057FE2A
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node47()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06012BE0 RID: 76768 RVA: 0x00581A40 File Offset: 0x0057FE40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5D2 RID: 50642
		private float opl_p0;
	}
}
