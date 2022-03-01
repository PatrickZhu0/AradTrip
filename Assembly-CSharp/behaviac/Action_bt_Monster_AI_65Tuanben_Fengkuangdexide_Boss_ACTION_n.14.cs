using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002EE9 RID: 12009
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node82 : Action
	{
		// Token: 0x060146AC RID: 83628 RVA: 0x006233E4 File Offset: 0x006217E4
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node82()
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
			item.skillID = 21597;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060146AD RID: 83629 RVA: 0x00623474 File Offset: 0x00621874
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E026 RID: 57382
		private List<Input> method_p0;

		// Token: 0x0400E027 RID: 57383
		private bool method_p1;
	}
}
