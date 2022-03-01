using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002DBA RID: 11706
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node29 : Action
	{
		// Token: 0x06014453 RID: 83027 RVA: 0x0061762C File Offset: 0x00615A2C
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node29()
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
			item.skillID = 21651;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014454 RID: 83028 RVA: 0x006176BC File Offset: 0x00615ABC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE1B RID: 56859
		private List<Input> method_p0;

		// Token: 0x0400DE1C RID: 56860
		private bool method_p1;
	}
}
