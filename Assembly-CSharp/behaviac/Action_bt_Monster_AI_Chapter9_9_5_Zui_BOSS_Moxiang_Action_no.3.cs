using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031A3 RID: 12707
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node26 : Action
	{
		// Token: 0x06014BD9 RID: 84953 RVA: 0x0063F0DC File Offset: 0x0063D4DC
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node26()
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
			item.skillID = 21548;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014BDA RID: 84954 RVA: 0x0063F16C File Offset: 0x0063D56C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E544 RID: 58692
		private List<Input> method_p0;

		// Token: 0x0400E545 RID: 58693
		private bool method_p1;
	}
}
