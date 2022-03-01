using System;

namespace behaviac
{
	// Token: 0x020025C6 RID: 9670
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node20 : Condition
	{
		// Token: 0x060134D3 RID: 79059 RVA: 0x005BD0B1 File Offset: 0x005BB4B1
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node20()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x060134D4 RID: 79060 RVA: 0x005BD0C4 File Offset: 0x005BB4C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF11 RID: 53009
		private float opl_p0;
	}
}
