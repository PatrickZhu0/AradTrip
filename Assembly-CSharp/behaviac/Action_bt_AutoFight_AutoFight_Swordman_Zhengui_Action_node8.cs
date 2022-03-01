using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002981 RID: 10625
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node8 : Action
	{
		// Token: 0x06013C36 RID: 80950 RVA: 0x005E97C4 File Offset: 0x005E7BC4
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node8()
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
			item.skillID = 1800;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013C37 RID: 80951 RVA: 0x005E9854 File Offset: 0x005E7C54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D69D RID: 54941
		private List<Input> method_p0;

		// Token: 0x0400D69E RID: 54942
		private bool method_p1;
	}
}
