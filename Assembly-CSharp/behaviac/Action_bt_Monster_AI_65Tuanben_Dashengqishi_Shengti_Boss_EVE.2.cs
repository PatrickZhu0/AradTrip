using System;

namespace behaviac
{
	// Token: 0x02002E89 RID: 11913
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node28 : Action
	{
		// Token: 0x060145ED RID: 83437 RVA: 0x006208CB File Offset: 0x0061ECCB
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "弱化祭台已通关，卡德蒙已被削弱！";
			this.method_p1 = 7f;
			this.method_p2 = 2;
		}

		// Token: 0x060145EE RID: 83438 RVA: 0x006208F7 File Offset: 0x0061ECF7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF70 RID: 57200
		private string method_p0;

		// Token: 0x0400DF71 RID: 57201
		private float method_p1;

		// Token: 0x0400DF72 RID: 57202
		private int method_p2;
	}
}
