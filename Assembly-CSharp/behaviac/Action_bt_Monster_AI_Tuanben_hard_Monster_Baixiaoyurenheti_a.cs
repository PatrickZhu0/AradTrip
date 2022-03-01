using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D07 RID: 15623
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_action_hard_node9 : Action
	{
		// Token: 0x060161AC RID: 90540 RVA: 0x006AEA70 File Offset: 0x006ACE70
		public Action_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_action_hard_node9()
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
			item.skillID = 21302;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060161AD RID: 90541 RVA: 0x006AEB00 File Offset: 0x006ACF00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA3D RID: 64061
		private List<Input> method_p0;

		// Token: 0x0400FA3E RID: 64062
		private bool method_p1;
	}
}
