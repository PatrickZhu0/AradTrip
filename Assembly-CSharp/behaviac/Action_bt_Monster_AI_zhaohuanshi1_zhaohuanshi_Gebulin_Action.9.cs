using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004059 RID: 16473
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node48 : Action
	{
		// Token: 0x06016811 RID: 92177 RVA: 0x006CF71C File Offset: 0x006CDB1C
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node48()
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
			item.skillID = 5108;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016812 RID: 92178 RVA: 0x006CF7AC File Offset: 0x006CDBAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401005C RID: 65628
		private List<Input> method_p0;

		// Token: 0x0401005D RID: 65629
		private bool method_p1;
	}
}
