using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C4F RID: 11343
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node19 : Action
	{
		// Token: 0x0601419A RID: 82330 RVA: 0x00609144 File Offset: 0x00607544
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node19()
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
			item.skillID = 20782;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601419B RID: 82331 RVA: 0x006091D4 File Offset: 0x006075D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB60 RID: 56160
		private List<Input> method_p0;

		// Token: 0x0400DB61 RID: 56161
		private bool method_p1;
	}
}
