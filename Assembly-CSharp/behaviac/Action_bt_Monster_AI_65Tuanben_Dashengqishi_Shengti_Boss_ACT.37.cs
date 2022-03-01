using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E40 RID: 11840
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node205 : Action
	{
		// Token: 0x0601455D RID: 83293 RVA: 0x0061ACB4 File Offset: 0x006190B4
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node205()
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
			item.skillID = 21627;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601455E RID: 83294 RVA: 0x0061AD44 File Offset: 0x00619144
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEF0 RID: 57072
		private List<Input> method_p0;

		// Token: 0x0400DEF1 RID: 57073
		private bool method_p1;
	}
}
