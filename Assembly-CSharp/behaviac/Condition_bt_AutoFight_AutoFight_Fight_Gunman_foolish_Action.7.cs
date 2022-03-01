using System;

namespace behaviac
{
	// Token: 0x020020DE RID: 8414
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node17 : Condition
	{
		// Token: 0x06012B51 RID: 76625 RVA: 0x0057E9F6 File Offset: 0x0057CDF6
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node17()
		{
			this.opl_p0 = 0.26f;
		}

		// Token: 0x06012B52 RID: 76626 RVA: 0x0057EA0C File Offset: 0x0057CE0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C544 RID: 50500
		private float opl_p0;
	}
}
