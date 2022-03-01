using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200364C RID: 13900
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node25 : Action
	{
		// Token: 0x060154BB RID: 87227 RVA: 0x0066B9EC File Offset: 0x00669DEC
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node25()
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
			item.skillID = 5424;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060154BC RID: 87228 RVA: 0x0066BA7C File Offset: 0x00669E7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE73 RID: 61043
		private List<Input> method_p0;

		// Token: 0x0400EE74 RID: 61044
		private bool method_p1;
	}
}
