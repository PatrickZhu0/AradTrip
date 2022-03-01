using System;

namespace behaviac
{
	// Token: 0x02001FD9 RID: 8153
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node34 : Action
	{
		// Token: 0x0601294F RID: 76111 RVA: 0x00571DB5 File Offset: 0x005701B5
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2512;
		}

		// Token: 0x06012950 RID: 76112 RVA: 0x00571DCF File Offset: 0x005701CF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C342 RID: 49986
		private int method_p0;
	}
}
