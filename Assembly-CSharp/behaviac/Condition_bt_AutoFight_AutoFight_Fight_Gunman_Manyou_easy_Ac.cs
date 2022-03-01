using System;

namespace behaviac
{
	// Token: 0x02002102 RID: 8450
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node2 : Condition
	{
		// Token: 0x06012B97 RID: 76695 RVA: 0x00580942 File Offset: 0x0057ED42
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node2()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012B98 RID: 76696 RVA: 0x00580958 File Offset: 0x0057ED58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C58A RID: 50570
		private float opl_p0;
	}
}
