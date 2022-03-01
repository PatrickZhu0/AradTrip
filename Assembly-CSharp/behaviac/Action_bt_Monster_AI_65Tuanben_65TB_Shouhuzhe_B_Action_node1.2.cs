using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C60 RID: 11360
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node15 : Action
	{
		// Token: 0x060141BB RID: 82363 RVA: 0x00609D0C File Offset: 0x0060810C
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node15()
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
			item.skillID = 20780;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060141BC RID: 82364 RVA: 0x00609D9C File Offset: 0x0060819C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB79 RID: 56185
		private List<Input> method_p0;

		// Token: 0x0400DB7A RID: 56186
		private bool method_p1;
	}
}
