using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004084 RID: 16516
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node7 : Action
	{
		// Token: 0x06016865 RID: 92261 RVA: 0x006D1B10 File Offset: 0x006CFF10
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 5021;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016866 RID: 92262 RVA: 0x006D1BA0 File Offset: 0x006CFFA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100B0 RID: 65712
		private List<Input> method_p0;

		// Token: 0x040100B1 RID: 65713
		private bool method_p1;
	}
}
