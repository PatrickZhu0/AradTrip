using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200278A RID: 10122
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Action_node5 : Action
	{
		// Token: 0x06013854 RID: 79956 RVA: 0x005D214C File Offset: 0x005D054C
		public Action_bt_AutoFight_AutoFight_Paladin_Action_node5()
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
			item.skillID = 3508;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013855 RID: 79957 RVA: 0x005D21DC File Offset: 0x005D05DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2B3 RID: 53939
		private List<Input> method_p0;

		// Token: 0x0400D2B4 RID: 53940
		private bool method_p1;
	}
}
