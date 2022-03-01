using System;

namespace behaviac
{
	// Token: 0x02003E9D RID: 16029
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node16 : Action
	{
		// Token: 0x060164BA RID: 91322 RVA: 0x006BDD23 File Offset: 0x006BC123
		public Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x060164BB RID: 91323 RVA: 0x006BDD39 File Offset: 0x006BC139
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCEF RID: 64751
		private DestinationType method_p0;
	}
}
