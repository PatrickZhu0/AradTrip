using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003100 RID: 12544
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Gangban_Heng_Event_node2 : Action
	{
		// Token: 0x06014AAD RID: 84653 RVA: 0x006393A4 File Offset: 0x006377A4
		public Action_bt_Monster_AI_Chapter10_Gangban_Heng_Event_node2()
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
			item.skillID = 20722;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014AAE RID: 84654 RVA: 0x00639434 File Offset: 0x00637834
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E421 RID: 58401
		private List<Input> method_p0;

		// Token: 0x0400E422 RID: 58402
		private bool method_p1;
	}
}
