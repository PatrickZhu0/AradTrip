using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E68 RID: 11880
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node262 : Action
	{
		// Token: 0x060145AD RID: 83373 RVA: 0x0061BD80 File Offset: 0x0061A180
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node262()
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
			item.skillID = 21628;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060145AE RID: 83374 RVA: 0x0061BE10 File Offset: 0x0061A210
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF37 RID: 57143
		private List<Input> method_p0;

		// Token: 0x0400DF38 RID: 57144
		private bool method_p1;
	}
}
