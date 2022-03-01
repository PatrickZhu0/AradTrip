using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020040AE RID: 16558
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node25 : Action
	{
		// Token: 0x060168B5 RID: 92341 RVA: 0x006D3884 File Offset: 0x006D1C84
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node25()
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
			item.skillID = 5094;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060168B6 RID: 92342 RVA: 0x006D3914 File Offset: 0x006D1D14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100FC RID: 65788
		private List<Input> method_p0;

		// Token: 0x040100FD RID: 65789
		private bool method_p1;
	}
}
