using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200366A RID: 13930
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node30 : Action
	{
		// Token: 0x060154F5 RID: 87285 RVA: 0x0066D500 File Offset: 0x0066B900
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node30()
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
			item.skillID = 5430;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060154F6 RID: 87286 RVA: 0x0066D590 File Offset: 0x0066B990
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEAB RID: 61099
		private List<Input> method_p0;

		// Token: 0x0400EEAC RID: 61100
		private bool method_p1;
	}
}
