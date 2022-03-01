using System;

namespace behaviac
{
	// Token: 0x02002321 RID: 8993
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node44 : Condition
	{
		// Token: 0x06012FB5 RID: 77749 RVA: 0x0059C86A File Offset: 0x0059AC6A
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node44()
		{
			this.opl_p0 = 0.42f;
		}

		// Token: 0x06012FB6 RID: 77750 RVA: 0x0059C880 File Offset: 0x0059AC80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9CC RID: 51660
		private float opl_p0;
	}
}
