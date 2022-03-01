using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003766 RID: 14182
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node78 : Action
	{
		// Token: 0x060156D3 RID: 87763 RVA: 0x00676AE8 File Offset: 0x00674EE8
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node78()
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
			item.skillID = 21194;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060156D4 RID: 87764 RVA: 0x00676B78 File Offset: 0x00674F78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F09E RID: 61598
		private List<Input> method_p0;

		// Token: 0x0400F09F RID: 61599
		private bool method_p1;
	}
}
