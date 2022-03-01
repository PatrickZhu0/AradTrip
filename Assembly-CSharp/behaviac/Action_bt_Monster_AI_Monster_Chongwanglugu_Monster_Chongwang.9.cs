using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200360F RID: 13839
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node42 : Action
	{
		// Token: 0x06015444 RID: 87108 RVA: 0x00668DF0 File Offset: 0x006671F0
		public Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node42()
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
			item.skillID = 5439;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015445 RID: 87109 RVA: 0x00668E80 File Offset: 0x00667280
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDFF RID: 60927
		private List<Input> method_p0;

		// Token: 0x0400EE00 RID: 60928
		private bool method_p1;
	}
}
