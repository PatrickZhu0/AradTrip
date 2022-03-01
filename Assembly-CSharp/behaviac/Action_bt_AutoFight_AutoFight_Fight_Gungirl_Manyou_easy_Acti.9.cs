using System;

namespace behaviac
{
	// Token: 0x02001FD1 RID: 8145
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node24 : Action
	{
		// Token: 0x0601293F RID: 76095 RVA: 0x005719CD File Offset: 0x0056FDCD
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2513;
		}

		// Token: 0x06012940 RID: 76096 RVA: 0x005719E7 File Offset: 0x0056FDE7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C332 RID: 49970
		private int method_p0;
	}
}
