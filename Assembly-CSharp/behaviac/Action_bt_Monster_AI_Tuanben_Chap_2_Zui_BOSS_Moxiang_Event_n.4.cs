using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003794 RID: 14228
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node11 : Action
	{
		// Token: 0x0601572D RID: 87853 RVA: 0x006791E4 File Offset: 0x006775E4
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node11()
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
			item.skillID = 21189;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601572E RID: 87854 RVA: 0x00679274 File Offset: 0x00677674
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0E2 RID: 61666
		private List<Input> method_p0;

		// Token: 0x0400F0E3 RID: 61667
		private bool method_p1;
	}
}
