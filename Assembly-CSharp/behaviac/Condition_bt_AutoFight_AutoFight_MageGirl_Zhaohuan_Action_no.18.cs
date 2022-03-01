using System;

namespace behaviac
{
	// Token: 0x02002760 RID: 10080
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node9 : Condition
	{
		// Token: 0x06013801 RID: 79873 RVA: 0x005CFD79 File Offset: 0x005CE179
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node9()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013802 RID: 79874 RVA: 0x005CFD8C File Offset: 0x005CE18C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D263 RID: 53859
		private float opl_p0;
	}
}
