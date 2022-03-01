using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002DD6 RID: 11734
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node77 : Action
	{
		// Token: 0x06014489 RID: 83081 RVA: 0x00618394 File Offset: 0x00616794
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node77()
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
			item.skillID = 21631;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601448A RID: 83082 RVA: 0x00618424 File Offset: 0x00616824
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE43 RID: 56899
		private List<Input> method_p0;

		// Token: 0x0400DE44 RID: 56900
		private bool method_p1;
	}
}
