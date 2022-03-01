using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D6E RID: 15726
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node54 : Action
	{
		// Token: 0x06016272 RID: 90738 RVA: 0x006B1888 File Offset: 0x006AFC88
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node54()
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
			item.skillID = 21079;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016273 RID: 90739 RVA: 0x006B1918 File Offset: 0x006AFD18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FACD RID: 64205
		private List<Input> method_p0;

		// Token: 0x0400FACE RID: 64206
		private bool method_p1;
	}
}
