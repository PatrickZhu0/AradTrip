using System;

namespace behaviac
{
	// Token: 0x02002665 RID: 9829
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node31 : Condition
	{
		// Token: 0x0601360F RID: 79375 RVA: 0x005C45E5 File Offset: 0x005C29E5
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node31()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x06013610 RID: 79376 RVA: 0x005C45F8 File Offset: 0x005C29F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D062 RID: 53346
		private float opl_p0;
	}
}
