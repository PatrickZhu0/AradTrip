using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003993 RID: 14739
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node8 : Action
	{
		// Token: 0x06015AFB RID: 88827 RVA: 0x0068CD80 File Offset: 0x0068B180
		public Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node8()
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
			item.skillID = 21038;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015AFC RID: 88828 RVA: 0x0068CE10 File Offset: 0x0068B210
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F494 RID: 62612
		private List<Input> method_p0;

		// Token: 0x0400F495 RID: 62613
		private bool method_p1;
	}
}
