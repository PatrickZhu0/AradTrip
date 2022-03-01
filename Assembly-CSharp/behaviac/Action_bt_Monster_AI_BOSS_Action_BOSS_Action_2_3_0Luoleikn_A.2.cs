using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F59 RID: 12121
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node12 : Action
	{
		// Token: 0x06014781 RID: 83841 RVA: 0x00628BD8 File Offset: 0x00626FD8
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node12()
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
			item.skillID = 5313;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014782 RID: 83842 RVA: 0x00628C68 File Offset: 0x00627068
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0EF RID: 57583
		private List<Input> method_p0;

		// Token: 0x0400E0F0 RID: 57584
		private bool method_p1;
	}
}
