using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200376D RID: 14189
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node37 : Action
	{
		// Token: 0x060156E1 RID: 87777 RVA: 0x00676DC0 File Offset: 0x006751C0
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node37()
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

		// Token: 0x060156E2 RID: 87778 RVA: 0x00676E50 File Offset: 0x00675250
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0A9 RID: 61609
		private List<Input> method_p0;

		// Token: 0x0400F0AA RID: 61610
		private bool method_p1;
	}
}
