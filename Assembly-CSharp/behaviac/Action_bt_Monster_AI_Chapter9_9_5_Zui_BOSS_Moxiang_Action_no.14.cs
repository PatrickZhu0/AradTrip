using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031C7 RID: 12743
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node60 : Action
	{
		// Token: 0x06014C21 RID: 85025 RVA: 0x0063FF90 File Offset: 0x0063E390
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node60()
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
			item.skillID = 21571;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014C22 RID: 85026 RVA: 0x00640020 File Offset: 0x0063E420
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E579 RID: 58745
		private List<Input> method_p0;

		// Token: 0x0400E57A RID: 58746
		private bool method_p1;
	}
}
