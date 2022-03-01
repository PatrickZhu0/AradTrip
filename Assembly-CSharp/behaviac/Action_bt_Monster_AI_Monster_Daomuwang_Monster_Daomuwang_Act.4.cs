using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200362B RID: 13867
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node10 : Action
	{
		// Token: 0x0601547A RID: 87162 RVA: 0x0066A4B8 File Offset: 0x006688B8
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node10()
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
			item.skillID = 5425;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601547B RID: 87163 RVA: 0x0066A548 File Offset: 0x00668948
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE33 RID: 60979
		private List<Input> method_p0;

		// Token: 0x0400EE34 RID: 60980
		private bool method_p1;
	}
}
