using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003633 RID: 13875
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node25 : Action
	{
		// Token: 0x0601548A RID: 87178 RVA: 0x0066A820 File Offset: 0x00668C20
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node25()
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
			item.skillID = 5424;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601548B RID: 87179 RVA: 0x0066A8B0 File Offset: 0x00668CB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE43 RID: 60995
		private List<Input> method_p0;

		// Token: 0x0400EE44 RID: 60996
		private bool method_p1;
	}
}
