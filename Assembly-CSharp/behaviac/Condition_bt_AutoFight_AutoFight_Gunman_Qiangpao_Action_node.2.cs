using System;

namespace behaviac
{
	// Token: 0x0200263F RID: 9791
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node90 : Condition
	{
		// Token: 0x060135C3 RID: 79299 RVA: 0x005C3605 File Offset: 0x005C1A05
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node90()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x060135C4 RID: 79300 RVA: 0x005C3618 File Offset: 0x005C1A18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D012 RID: 53266
		private float opl_p0;
	}
}
