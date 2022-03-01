using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020024C6 RID: 9414
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Action_node53 : Action
	{
		// Token: 0x060132D7 RID: 78551 RVA: 0x005B1224 File Offset: 0x005AF624
		public Action_bt_AutoFight_AutoFight_Gungirl_Action_node53()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 2;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 3;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 1500;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 4;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x060132D8 RID: 78552 RVA: 0x005B1308 File Offset: 0x005AF708
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCF5 RID: 52469
		private List<Input> method_p0;

		// Token: 0x0400CCF6 RID: 52470
		private bool method_p1;
	}
}
