using System;

namespace behaviac
{
	// Token: 0x02002325 RID: 8997
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node48 : Condition
	{
		// Token: 0x06012FBD RID: 77757 RVA: 0x0059CA7A File Offset: 0x0059AE7A
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node48()
		{
			this.opl_p0 = 0.44f;
		}

		// Token: 0x06012FBE RID: 77758 RVA: 0x0059CA90 File Offset: 0x0059AE90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9D4 RID: 51668
		private float opl_p0;
	}
}
