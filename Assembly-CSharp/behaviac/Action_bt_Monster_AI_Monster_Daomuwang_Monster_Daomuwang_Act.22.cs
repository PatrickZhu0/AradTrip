using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003676 RID: 13942
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node10 : Action
	{
		// Token: 0x0601550D RID: 87309 RVA: 0x0066DA1C File Offset: 0x0066BE1C
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node10()
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
			item.skillID = 5425;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601550E RID: 87310 RVA: 0x0066DAAC File Offset: 0x0066BEAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEC3 RID: 61123
		private List<Input> method_p0;

		// Token: 0x0400EEC4 RID: 61124
		private bool method_p1;
	}
}
