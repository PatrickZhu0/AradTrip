using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002EDD RID: 11997
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node73 : Action
	{
		// Token: 0x06014694 RID: 83604 RVA: 0x00622E80 File Offset: 0x00621280
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node73()
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
			item.skillID = 21594;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014695 RID: 83605 RVA: 0x00622F10 File Offset: 0x00621310
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E008 RID: 57352
		private List<Input> method_p0;

		// Token: 0x0400E009 RID: 57353
		private bool method_p1;
	}
}
