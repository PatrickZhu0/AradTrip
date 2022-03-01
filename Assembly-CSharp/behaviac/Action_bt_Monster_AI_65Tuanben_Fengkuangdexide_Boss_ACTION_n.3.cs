using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002EBB RID: 11963
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node35 : Action
	{
		// Token: 0x06014650 RID: 83536 RVA: 0x0062223C File Offset: 0x0062063C
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node35()
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
			item.skillID = 21589;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014651 RID: 83537 RVA: 0x006222CC File Offset: 0x006206CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFC3 RID: 57283
		private List<Input> method_p0;

		// Token: 0x0400DFC4 RID: 57284
		private bool method_p1;
	}
}
