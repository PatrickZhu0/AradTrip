using System;

namespace behaviac
{
	// Token: 0x02001F6D RID: 8045
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_easy_Move_node3 : Condition
	{
		// Token: 0x0601287C RID: 75900 RVA: 0x0056D422 File Offset: 0x0056B822
		public Condition_bt_AutoFight_AutoFight_Fight_easy_Move_node3()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x0601287D RID: 75901 RVA: 0x0056D438 File Offset: 0x0056B838
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C278 RID: 49784
		private float opl_p0;
	}
}
