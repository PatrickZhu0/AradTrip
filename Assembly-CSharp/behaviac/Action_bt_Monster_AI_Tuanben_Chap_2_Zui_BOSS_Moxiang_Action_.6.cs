using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200375D RID: 14173
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node19 : Action
	{
		// Token: 0x060156C1 RID: 87745 RVA: 0x00676734 File Offset: 0x00674B34
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node19()
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
			item.skillID = 21188;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060156C2 RID: 87746 RVA: 0x006767C4 File Offset: 0x00674BC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F092 RID: 61586
		private List<Input> method_p0;

		// Token: 0x0400F093 RID: 61587
		private bool method_p1;
	}
}
