using System;

namespace behaviac
{
	// Token: 0x0200232A RID: 9002
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node54 : Condition
	{
		// Token: 0x06012FC7 RID: 77767 RVA: 0x0059CC8E File Offset: 0x0059B08E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node54()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x06012FC8 RID: 77768 RVA: 0x0059CCA4 File Offset: 0x0059B0A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9DF RID: 51679
		private float opl_p0;
	}
}
