using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025FA RID: 9722
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node10 : Action
	{
		// Token: 0x0601353A RID: 79162 RVA: 0x005C01CC File Offset: 0x005BE5CC
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node10()
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
			item.skillID = 1015;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601353B RID: 79163 RVA: 0x005C025C File Offset: 0x005BE65C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF82 RID: 53122
		private List<Input> method_p0;

		// Token: 0x0400CF83 RID: 53123
		private bool method_p1;
	}
}
