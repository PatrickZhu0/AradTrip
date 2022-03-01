using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003640 RID: 13888
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node15 : Action
	{
		// Token: 0x060154A3 RID: 87203 RVA: 0x0066B4D0 File Offset: 0x006698D0
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node15()
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
			item.skillID = 5659;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060154A4 RID: 87204 RVA: 0x0066B560 File Offset: 0x00669960
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE5B RID: 61019
		private List<Input> method_p0;

		// Token: 0x0400EE5C RID: 61020
		private bool method_p1;
	}
}
