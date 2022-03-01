using System;

namespace behaviac
{
	// Token: 0x02001F6F RID: 8047
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_easy_Move_node5 : Condition
	{
		// Token: 0x06012880 RID: 75904 RVA: 0x0056D495 File Offset: 0x0056B895
		public Condition_bt_AutoFight_AutoFight_Fight_easy_Move_node5()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012881 RID: 75905 RVA: 0x0056D4A8 File Offset: 0x0056B8A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C27A RID: 49786
		private float opl_p0;
	}
}
