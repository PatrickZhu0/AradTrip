using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031EA RID: 12778
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node3 : Action
	{
		// Token: 0x06014C60 RID: 85088 RVA: 0x00642178 File Offset: 0x00640578
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node3()
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
			item.skillID = 21564;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014C61 RID: 85089 RVA: 0x00642208 File Offset: 0x00640608
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5BC RID: 58812
		private List<Input> method_p0;

		// Token: 0x0400E5BD RID: 58813
		private bool method_p1;
	}
}
