using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031BA RID: 12730
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node41 : Action
	{
		// Token: 0x06014C07 RID: 84999 RVA: 0x0063FA40 File Offset: 0x0063DE40
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node41()
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

		// Token: 0x06014C08 RID: 85000 RVA: 0x0063FAD0 File Offset: 0x0063DED0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E566 RID: 58726
		private List<Input> method_p0;

		// Token: 0x0400E567 RID: 58727
		private bool method_p1;
	}
}
