using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004065 RID: 16485
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node63 : Action
	{
		// Token: 0x06016829 RID: 92201 RVA: 0x006CFC38 File Offset: 0x006CE038
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node63()
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
			item.skillID = 5110;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601682A RID: 92202 RVA: 0x006CFCC8 File Offset: 0x006CE0C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010074 RID: 65652
		private List<Input> method_p0;

		// Token: 0x04010075 RID: 65653
		private bool method_p1;
	}
}
