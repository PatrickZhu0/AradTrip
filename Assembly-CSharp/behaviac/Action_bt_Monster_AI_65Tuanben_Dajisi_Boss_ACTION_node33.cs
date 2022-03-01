using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D79 RID: 11641
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node33 : Action
	{
		// Token: 0x060143D4 RID: 82900 RVA: 0x00614564 File Offset: 0x00612964
		public Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node33()
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
			item.skillID = 21606;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060143D5 RID: 82901 RVA: 0x006145F4 File Offset: 0x006129F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDA2 RID: 56738
		private List<Input> method_p0;

		// Token: 0x0400DDA3 RID: 56739
		private bool method_p1;
	}
}
