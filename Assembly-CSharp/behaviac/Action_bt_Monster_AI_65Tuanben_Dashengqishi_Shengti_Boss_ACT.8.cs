using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002DE2 RID: 11746
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node44 : Action
	{
		// Token: 0x060144A1 RID: 83105 RVA: 0x0061888C File Offset: 0x00616C8C
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node44()
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
			item.skillID = 21637;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060144A2 RID: 83106 RVA: 0x0061891C File Offset: 0x00616D1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE57 RID: 56919
		private List<Input> method_p0;

		// Token: 0x0400DE58 RID: 56920
		private bool method_p1;
	}
}
