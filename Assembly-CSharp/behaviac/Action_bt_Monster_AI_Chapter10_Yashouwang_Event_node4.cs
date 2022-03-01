using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200314D RID: 12621
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Yashouwang_Event_node4 : Action
	{
		// Token: 0x06014B3C RID: 84796 RVA: 0x0063C0D8 File Offset: 0x0063A4D8
		public Action_bt_Monster_AI_Chapter10_Yashouwang_Event_node4()
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
			item.skillID = 20680;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014B3D RID: 84797 RVA: 0x0063C168 File Offset: 0x0063A568
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4B2 RID: 58546
		private List<Input> method_p0;

		// Token: 0x0400E4B3 RID: 58547
		private bool method_p1;
	}
}
