using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002620 RID: 9760
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node73 : Action
	{
		// Token: 0x06013586 RID: 79238 RVA: 0x005C1310 File Offset: 0x005BF710
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node73()
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
			item.skillID = 1010;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013587 RID: 79239 RVA: 0x005C13A0 File Offset: 0x005BF7A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFD0 RID: 53200
		private List<Input> method_p0;

		// Token: 0x0400CFD1 RID: 53201
		private bool method_p1;
	}
}
