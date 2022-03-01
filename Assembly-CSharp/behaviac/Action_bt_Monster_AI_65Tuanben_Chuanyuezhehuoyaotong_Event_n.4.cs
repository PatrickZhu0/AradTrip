using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D5F RID: 11615
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node16 : Action
	{
		// Token: 0x060143A1 RID: 82849 RVA: 0x006136B4 File Offset: 0x00611AB4
		public Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node16()
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
			item.skillID = 21857;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060143A2 RID: 82850 RVA: 0x00613744 File Offset: 0x00611B44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD6C RID: 56684
		private List<Input> method_p0;

		// Token: 0x0400DD6D RID: 56685
		private bool method_p1;
	}
}
