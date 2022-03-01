using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002ED8 RID: 11992
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node17 : Action
	{
		// Token: 0x0601468A RID: 83594 RVA: 0x00622C54 File Offset: 0x00621054
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node17()
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
			item.skillID = 21600;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601468B RID: 83595 RVA: 0x00622CE4 File Offset: 0x006210E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFFB RID: 57339
		private List<Input> method_p0;

		// Token: 0x0400DFFC RID: 57340
		private bool method_p1;
	}
}
