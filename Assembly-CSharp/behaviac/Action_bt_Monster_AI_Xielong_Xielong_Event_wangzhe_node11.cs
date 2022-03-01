using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E57 RID: 15959
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node11 : Action
	{
		// Token: 0x06016432 RID: 91186 RVA: 0x006BB1C0 File Offset: 0x006B95C0
		public Action_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node11()
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
			item.skillID = 7228;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016433 RID: 91187 RVA: 0x006BB250 File Offset: 0x006B9650
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC7E RID: 64638
		private List<Input> method_p0;

		// Token: 0x0400FC7F RID: 64639
		private bool method_p1;
	}
}
