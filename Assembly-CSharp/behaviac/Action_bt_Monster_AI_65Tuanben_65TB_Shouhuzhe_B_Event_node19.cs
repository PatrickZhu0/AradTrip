using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C78 RID: 11384
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node19 : Action
	{
		// Token: 0x060141E9 RID: 82409 RVA: 0x0060AAA0 File Offset: 0x00608EA0
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node19()
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
			item.skillID = 20782;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060141EA RID: 82410 RVA: 0x0060AB30 File Offset: 0x00608F30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBAA RID: 56234
		private List<Input> method_p0;

		// Token: 0x0400DBAB RID: 56235
		private bool method_p1;
	}
}
