using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D59 RID: 11609
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node10 : Action
	{
		// Token: 0x06014395 RID: 82837 RVA: 0x0061340C File Offset: 0x0061180C
		public Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node10()
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
			item.skillID = 21854;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014396 RID: 82838 RVA: 0x0061349C File Offset: 0x0061189C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD60 RID: 56672
		private List<Input> method_p0;

		// Token: 0x0400DD61 RID: 56673
		private bool method_p1;
	}
}
