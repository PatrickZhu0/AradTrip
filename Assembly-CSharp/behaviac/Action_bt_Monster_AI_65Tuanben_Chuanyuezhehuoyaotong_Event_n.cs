using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D56 RID: 11606
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node7 : Action
	{
		// Token: 0x0601438F RID: 82831 RVA: 0x006132B8 File Offset: 0x006116B8
		public Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node7()
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
			item.skillID = 21855;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014390 RID: 82832 RVA: 0x00613348 File Offset: 0x00611748
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD5A RID: 56666
		private List<Input> method_p0;

		// Token: 0x0400DD5B RID: 56667
		private bool method_p1;
	}
}
