using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003106 RID: 12550
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Gangban_Shu_Event_node2 : Action
	{
		// Token: 0x06014AB8 RID: 84664 RVA: 0x006396F8 File Offset: 0x00637AF8
		public Action_bt_Monster_AI_Chapter10_Gangban_Shu_Event_node2()
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
			item.skillID = 20723;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014AB9 RID: 84665 RVA: 0x00639788 File Offset: 0x00637B88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E42A RID: 58410
		private List<Input> method_p0;

		// Token: 0x0400E42B RID: 58411
		private bool method_p1;
	}
}
