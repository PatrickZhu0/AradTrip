using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E19 RID: 15897
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node15 : Action
	{
		// Token: 0x060163BB RID: 91067 RVA: 0x006B8888 File Offset: 0x006B6C88
		public Action_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node15()
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
			item.skillID = 7241;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060163BC RID: 91068 RVA: 0x006B8918 File Offset: 0x006B6D18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC22 RID: 64546
		private List<Input> method_p0;

		// Token: 0x0400FC23 RID: 64547
		private bool method_p1;
	}
}
