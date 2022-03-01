using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F3F RID: 12095
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node17 : Action
	{
		// Token: 0x0601474F RID: 83791 RVA: 0x00627834 File Offset: 0x00625C34
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node17()
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
			item.skillID = 5000;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014750 RID: 83792 RVA: 0x006278C4 File Offset: 0x00625CC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0BF RID: 57535
		private List<Input> method_p0;

		// Token: 0x0400E0C0 RID: 57536
		private bool method_p1;
	}
}
