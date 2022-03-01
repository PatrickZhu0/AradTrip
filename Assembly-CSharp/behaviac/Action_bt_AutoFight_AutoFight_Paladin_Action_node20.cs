using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200279E RID: 10142
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Action_node20 : Action
	{
		// Token: 0x0601387C RID: 79996 RVA: 0x005D29D0 File Offset: 0x005D0DD0
		public Action_bt_AutoFight_AutoFight_Paladin_Action_node20()
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
			item.skillID = 3507;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601387D RID: 79997 RVA: 0x005D2A60 File Offset: 0x005D0E60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2DB RID: 53979
		private List<Input> method_p0;

		// Token: 0x0400D2DC RID: 53980
		private bool method_p1;
	}
}
