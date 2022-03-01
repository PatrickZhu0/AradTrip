using System;

namespace behaviac
{
	// Token: 0x020025BA RID: 9658
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node24 : Condition
	{
		// Token: 0x060134BB RID: 79035 RVA: 0x005BCB95 File Offset: 0x005BAF95
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node24()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x060134BC RID: 79036 RVA: 0x005BCBA8 File Offset: 0x005BAFA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEF9 RID: 52985
		private float opl_p0;
	}
}
