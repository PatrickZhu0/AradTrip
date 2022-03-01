using System;

namespace behaviac
{
	// Token: 0x02003728 RID: 14120
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node6 : Action
	{
		// Token: 0x0601565C RID: 87644 RVA: 0x00674AFB File Offset: 0x00672EFB
		public Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538804;
		}

		// Token: 0x0601565D RID: 87645 RVA: 0x00674B1C File Offset: 0x00672F1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F02C RID: 61484
		private BE_Target method_p0;

		// Token: 0x0400F02D RID: 61485
		private int method_p1;
	}
}
