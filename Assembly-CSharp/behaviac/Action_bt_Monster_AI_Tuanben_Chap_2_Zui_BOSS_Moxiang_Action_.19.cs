using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003786 RID: 14214
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node88 : Action
	{
		// Token: 0x06015713 RID: 87827 RVA: 0x00677800 File Offset: 0x00675C00
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node88()
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
			item.skillID = 21196;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015714 RID: 87828 RVA: 0x00677890 File Offset: 0x00675C90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0CC RID: 61644
		private List<Input> method_p0;

		// Token: 0x0400F0CD RID: 61645
		private bool method_p1;
	}
}
