using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F96 RID: 8086
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node10 : Action
	{
		// Token: 0x060128CB RID: 75979 RVA: 0x0056EFA8 File Offset: 0x0056D3A8
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node10()
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
			item.skillID = 2508;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060128CC RID: 75980 RVA: 0x0056F038 File Offset: 0x0056D438
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2BD RID: 49853
		private List<Input> method_p0;

		// Token: 0x0400C2BE RID: 49854
		private bool method_p1;
	}
}
