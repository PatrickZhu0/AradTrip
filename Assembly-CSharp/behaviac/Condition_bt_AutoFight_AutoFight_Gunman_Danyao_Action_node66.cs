using System;

namespace behaviac
{
	// Token: 0x020025E6 RID: 9702
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node66 : Condition
	{
		// Token: 0x06013513 RID: 79123 RVA: 0x005BDE45 File Offset: 0x005BC245
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node66()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06013514 RID: 79124 RVA: 0x005BDE58 File Offset: 0x005BC258
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF59 RID: 53081
		private float opl_p0;
	}
}
