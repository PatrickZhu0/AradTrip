using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003638 RID: 13880
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node30 : Action
	{
		// Token: 0x06015493 RID: 87187 RVA: 0x0066B168 File Offset: 0x00669568
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node30()
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
			item.skillID = 5430;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015494 RID: 87188 RVA: 0x0066B1F8 File Offset: 0x006695F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE4B RID: 61003
		private List<Input> method_p0;

		// Token: 0x0400EE4C RID: 61004
		private bool method_p1;
	}
}
