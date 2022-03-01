using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029BC RID: 10684
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node41 : Action
	{
		// Token: 0x06013CAC RID: 81068 RVA: 0x005EB278 File Offset: 0x005E9678
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node41()
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
			item.skillID = 1809;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013CAD RID: 81069 RVA: 0x005EB308 File Offset: 0x005E9708
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D719 RID: 55065
		private List<Input> method_p0;

		// Token: 0x0400D71A RID: 55066
		private bool method_p1;
	}
}
