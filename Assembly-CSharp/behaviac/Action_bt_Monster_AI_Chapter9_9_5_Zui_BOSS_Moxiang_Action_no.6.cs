using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031AD RID: 12717
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node25 : Action
	{
		// Token: 0x06014BED RID: 84973 RVA: 0x0063F4F0 File Offset: 0x0063D8F0
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node25()
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
			item.skillID = 21549;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014BEE RID: 84974 RVA: 0x0063F580 File Offset: 0x0063D980
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E553 RID: 58707
		private List<Input> method_p0;

		// Token: 0x0400E554 RID: 58708
		private bool method_p1;
	}
}
