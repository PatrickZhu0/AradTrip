using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027A6 RID: 10150
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Action_node30 : Action
	{
		// Token: 0x0601388C RID: 80012 RVA: 0x005D2D38 File Offset: 0x005D1138
		public Action_bt_AutoFight_AutoFight_Paladin_Action_node30()
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
			item.skillID = 3509;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601388D RID: 80013 RVA: 0x005D2DC8 File Offset: 0x005D11C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2EB RID: 53995
		private List<Input> method_p0;

		// Token: 0x0400D2EC RID: 53996
		private bool method_p1;
	}
}
