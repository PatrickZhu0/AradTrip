using System;

namespace behaviac
{
	// Token: 0x02002106 RID: 8454
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node7 : Condition
	{
		// Token: 0x06012B9F RID: 76703 RVA: 0x00580ADE File Offset: 0x0057EEDE
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node7()
		{
			this.opl_p0 = 0.33f;
		}

		// Token: 0x06012BA0 RID: 76704 RVA: 0x00580AF4 File Offset: 0x0057EEF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C592 RID: 50578
		private float opl_p0;
	}
}
