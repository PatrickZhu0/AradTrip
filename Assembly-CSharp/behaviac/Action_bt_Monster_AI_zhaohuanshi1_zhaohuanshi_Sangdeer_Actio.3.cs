using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200409E RID: 16542
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node17 : Action
	{
		// Token: 0x06016897 RID: 92311 RVA: 0x006D2CD4 File Offset: 0x006D10D4
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node17()
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
			item.skillID = 5355;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016898 RID: 92312 RVA: 0x006D2D64 File Offset: 0x006D1164
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100E0 RID: 65760
		private List<Input> method_p0;

		// Token: 0x040100E1 RID: 65761
		private bool method_p1;
	}
}
