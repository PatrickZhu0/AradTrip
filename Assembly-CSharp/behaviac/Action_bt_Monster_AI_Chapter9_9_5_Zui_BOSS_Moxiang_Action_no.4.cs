using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031A6 RID: 12710
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node29 : Action
	{
		// Token: 0x06014BDF RID: 84959 RVA: 0x0063F218 File Offset: 0x0063D618
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node29()
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
			item.skillID = 21550;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014BE0 RID: 84960 RVA: 0x0063F2A8 File Offset: 0x0063D6A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E548 RID: 58696
		private List<Input> method_p0;

		// Token: 0x0400E549 RID: 58697
		private bool method_p1;
	}
}
