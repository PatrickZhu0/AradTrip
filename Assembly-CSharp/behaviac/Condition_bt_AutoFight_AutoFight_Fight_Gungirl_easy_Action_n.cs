using System;

namespace behaviac
{
	// Token: 0x02001F77 RID: 8055
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node2 : Condition
	{
		// Token: 0x0601288E RID: 75918 RVA: 0x0056D935 File Offset: 0x0056BD35
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node2()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x0601288F RID: 75919 RVA: 0x0056D948 File Offset: 0x0056BD48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C280 RID: 49792
		private float opl_p0;
	}
}
