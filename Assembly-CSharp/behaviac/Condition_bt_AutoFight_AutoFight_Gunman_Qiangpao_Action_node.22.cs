using System;

namespace behaviac
{
	// Token: 0x0200265B RID: 9819
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node24 : Condition
	{
		// Token: 0x060135FB RID: 79355 RVA: 0x005C4165 File Offset: 0x005C2565
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node24()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x060135FC RID: 79356 RVA: 0x005C4178 File Offset: 0x005C2578
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D04C RID: 53324
		private float opl_p0;
	}
}
