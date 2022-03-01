using System;

namespace behaviac
{
	// Token: 0x0200267D RID: 9853
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node14 : Condition
	{
		// Token: 0x0601363F RID: 79423 RVA: 0x005C500A File Offset: 0x005C340A
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node14()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013640 RID: 79424 RVA: 0x005C5020 File Offset: 0x005C3420
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D091 RID: 53393
		private float opl_p0;
	}
}
