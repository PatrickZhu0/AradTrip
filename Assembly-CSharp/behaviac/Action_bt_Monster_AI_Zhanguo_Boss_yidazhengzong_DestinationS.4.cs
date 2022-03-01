using System;

namespace behaviac
{
	// Token: 0x02003E98 RID: 16024
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node8 : Action
	{
		// Token: 0x060164B0 RID: 91312 RVA: 0x006BDBC7 File Offset: 0x006BBFC7
		public Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x060164B1 RID: 91313 RVA: 0x006BDBDD File Offset: 0x006BBFDD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCE7 RID: 64743
		private DestinationType method_p0;
	}
}
