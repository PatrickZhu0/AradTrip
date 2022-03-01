using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E7E RID: 11902
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node165 : Action
	{
		// Token: 0x060145D9 RID: 83417 RVA: 0x0061C7AC File Offset: 0x0061ABAC
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node165()
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
			item.skillID = 21624;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060145DA RID: 83418 RVA: 0x0061C83C File Offset: 0x0061AC3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF64 RID: 57188
		private List<Input> method_p0;

		// Token: 0x0400DF65 RID: 57189
		private bool method_p1;
	}
}
