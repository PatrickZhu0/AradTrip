using System;

namespace behaviac
{
	// Token: 0x02002672 RID: 9842
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node84 : Condition
	{
		// Token: 0x06013629 RID: 79401 RVA: 0x005C4B61 File Offset: 0x005C2F61
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node84()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x0601362A RID: 79402 RVA: 0x005C4B74 File Offset: 0x005C2F74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D07D RID: 53373
		private float opl_p0;
	}
}
