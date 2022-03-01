using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003776 RID: 14198
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node49 : Action
	{
		// Token: 0x060156F3 RID: 87795 RVA: 0x00677174 File Offset: 0x00675574
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node49()
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

		// Token: 0x060156F4 RID: 87796 RVA: 0x00677204 File Offset: 0x00675604
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0B5 RID: 61621
		private List<Input> method_p0;

		// Token: 0x0400F0B6 RID: 61622
		private bool method_p1;
	}
}
