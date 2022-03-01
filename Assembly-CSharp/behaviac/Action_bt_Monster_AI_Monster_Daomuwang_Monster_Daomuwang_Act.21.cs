using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003672 RID: 13938
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node15 : Action
	{
		// Token: 0x06015505 RID: 87301 RVA: 0x0066D868 File Offset: 0x0066BC68
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node15()
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
			item.skillID = 5660;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015506 RID: 87302 RVA: 0x0066D8F8 File Offset: 0x0066BCF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEBB RID: 61115
		private List<Input> method_p0;

		// Token: 0x0400EEBC RID: 61116
		private bool method_p1;
	}
}
