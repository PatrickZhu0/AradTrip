using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200377D RID: 14205
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node61 : Action
	{
		// Token: 0x06015701 RID: 87809 RVA: 0x0067744C File Offset: 0x0067584C
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node61()
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
			item.skillID = 21198;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015702 RID: 87810 RVA: 0x006774DC File Offset: 0x006758DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0C0 RID: 61632
		private List<Input> method_p0;

		// Token: 0x0400F0C1 RID: 61633
		private bool method_p1;
	}
}
