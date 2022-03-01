using System;

namespace behaviac
{
	// Token: 0x0200232F RID: 9007
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node60 : Condition
	{
		// Token: 0x06012FD1 RID: 77777 RVA: 0x0059CEA2 File Offset: 0x0059B2A2
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node60()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012FD2 RID: 77778 RVA: 0x0059CEB8 File Offset: 0x0059B2B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9EA RID: 51690
		private float opl_p0;
	}
}
