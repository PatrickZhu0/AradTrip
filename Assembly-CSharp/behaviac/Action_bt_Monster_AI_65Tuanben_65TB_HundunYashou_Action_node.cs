using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B81 RID: 11137
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node26 : Action
	{
		// Token: 0x0601400E RID: 81934 RVA: 0x00601CCC File Offset: 0x006000CC
		public Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node26()
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
			item.skillID = 20771;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601400F RID: 81935 RVA: 0x00601D5C File Offset: 0x0060015C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA0C RID: 55820
		private List<Input> method_p0;

		// Token: 0x0400DA0D RID: 55821
		private bool method_p1;
	}
}
