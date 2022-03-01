using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003750 RID: 14160
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node12 : Action
	{
		// Token: 0x060156A7 RID: 87719 RVA: 0x006761E4 File Offset: 0x006745E4
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node12()
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
			item.skillID = 21192;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060156A8 RID: 87720 RVA: 0x00676274 File Offset: 0x00674674
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F07F RID: 61567
		private List<Input> method_p0;

		// Token: 0x0400F080 RID: 61568
		private bool method_p1;
	}
}
