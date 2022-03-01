using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002796 RID: 10134
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Action_node69 : Action
	{
		// Token: 0x0601386C RID: 79980 RVA: 0x005D2668 File Offset: 0x005D0A68
		public Action_bt_AutoFight_AutoFight_Paladin_Action_node69()
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
			item.skillID = 3614;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601386D RID: 79981 RVA: 0x005D26F8 File Offset: 0x005D0AF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2CB RID: 53963
		private List<Input> method_p0;

		// Token: 0x0400D2CC RID: 53964
		private bool method_p1;
	}
}
