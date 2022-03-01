using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E2D RID: 11821
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node193 : Action
	{
		// Token: 0x06014537 RID: 83255 RVA: 0x0061A658 File Offset: 0x00618A58
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node193()
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

		// Token: 0x06014538 RID: 83256 RVA: 0x0061A6E8 File Offset: 0x00618AE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DED5 RID: 57045
		private List<Input> method_p0;

		// Token: 0x0400DED6 RID: 57046
		private bool method_p1;
	}
}
