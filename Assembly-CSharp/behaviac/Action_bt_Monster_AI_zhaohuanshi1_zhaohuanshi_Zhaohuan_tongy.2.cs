using System;

namespace behaviac
{
	// Token: 0x020040C9 RID: 16585
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node9 : Action
	{
		// Token: 0x060168E9 RID: 92393 RVA: 0x006D4AA9 File Offset: 0x006D2EA9
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060168EA RID: 92394 RVA: 0x006D4ABF File Offset: 0x006D2EBF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010130 RID: 65840
		private DestinationType method_p0;
	}
}
