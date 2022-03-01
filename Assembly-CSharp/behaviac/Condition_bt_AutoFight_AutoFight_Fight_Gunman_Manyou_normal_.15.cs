using System;

namespace behaviac
{
	// Token: 0x02002196 RID: 8598
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node37 : Condition
	{
		// Token: 0x06012CBC RID: 76988 RVA: 0x0058703A File Offset: 0x0058543A
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node37()
		{
			this.opl_p0 = 0.59f;
		}

		// Token: 0x06012CBD RID: 76989 RVA: 0x00587050 File Offset: 0x00585450
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6AF RID: 50863
		private float opl_p0;
	}
}
