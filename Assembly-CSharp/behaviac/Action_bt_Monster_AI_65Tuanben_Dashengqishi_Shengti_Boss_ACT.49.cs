using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E63 RID: 11875
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node252 : Action
	{
		// Token: 0x060145A3 RID: 83363 RVA: 0x0061BB7C File Offset: 0x00619F7C
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node252()
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
			item.skillID = 21638;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060145A4 RID: 83364 RVA: 0x0061BC0C File Offset: 0x0061A00C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF2D RID: 57133
		private List<Input> method_p0;

		// Token: 0x0400DF2E RID: 57134
		private bool method_p1;
	}
}
