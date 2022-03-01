using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020040B5 RID: 16565
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node30 : Action
	{
		// Token: 0x060168C3 RID: 92355 RVA: 0x006D3BA8 File Offset: 0x006D1FA8
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node30()
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
			item.skillID = 5091;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060168C4 RID: 92356 RVA: 0x006D3C38 File Offset: 0x006D2038
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401010B RID: 65803
		private List<Input> method_p0;

		// Token: 0x0401010C RID: 65804
		private bool method_p1;
	}
}
