using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E72 RID: 11890
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node273 : Action
	{
		// Token: 0x060145C1 RID: 83393 RVA: 0x0061C210 File Offset: 0x0061A610
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node273()
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

		// Token: 0x060145C2 RID: 83394 RVA: 0x0061C2A0 File Offset: 0x0061A6A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF49 RID: 57161
		private List<Input> method_p0;

		// Token: 0x0400DF4A RID: 57162
		private bool method_p1;
	}
}
