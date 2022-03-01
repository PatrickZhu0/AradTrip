using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200407D RID: 16509
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node15 : Action
	{
		// Token: 0x06016857 RID: 92247 RVA: 0x006D17EC File Offset: 0x006CFBEC
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node15()
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
			item.skillID = 5023;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016858 RID: 92248 RVA: 0x006D187C File Offset: 0x006CFC7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100A1 RID: 65697
		private List<Input> method_p0;

		// Token: 0x040100A2 RID: 65698
		private bool method_p1;
	}
}
