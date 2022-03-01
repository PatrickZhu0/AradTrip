using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F18 RID: 12056
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node20 : Action
	{
		// Token: 0x06014707 RID: 83719 RVA: 0x00625D44 File Offset: 0x00624144
		public Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node20()
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
			item.skillID = 21611;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014708 RID: 83720 RVA: 0x00625DD4 File Offset: 0x006241D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E080 RID: 57472
		private List<Input> method_p0;

		// Token: 0x0400E081 RID: 57473
		private bool method_p1;
	}
}
