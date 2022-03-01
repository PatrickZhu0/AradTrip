using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031B3 RID: 12723
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node46 : Action
	{
		// Token: 0x06014BF9 RID: 84985 RVA: 0x0063F768 File Offset: 0x0063DB68
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node46()
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

		// Token: 0x06014BFA RID: 84986 RVA: 0x0063F7F8 File Offset: 0x0063DBF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E55B RID: 58715
		private List<Input> method_p0;

		// Token: 0x0400E55C RID: 58716
		private bool method_p1;
	}
}
