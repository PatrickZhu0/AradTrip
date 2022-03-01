using System;

namespace behaviac
{
	// Token: 0x020025C2 RID: 9666
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node84 : Condition
	{
		// Token: 0x060134CB RID: 79051 RVA: 0x005BCEFD File Offset: 0x005BB2FD
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node84()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x060134CC RID: 79052 RVA: 0x005BCF10 File Offset: 0x005BB310
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF09 RID: 53001
		private float opl_p0;
	}
}
