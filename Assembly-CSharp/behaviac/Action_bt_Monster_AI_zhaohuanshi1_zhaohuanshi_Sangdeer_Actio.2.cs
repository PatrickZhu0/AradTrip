using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200409A RID: 16538
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node12 : Action
	{
		// Token: 0x0601688F RID: 92303 RVA: 0x006D2B20 File Offset: 0x006D0F20
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node12()
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

		// Token: 0x06016890 RID: 92304 RVA: 0x006D2BB0 File Offset: 0x006D0FB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100D8 RID: 65752
		private List<Input> method_p0;

		// Token: 0x040100D9 RID: 65753
		private bool method_p1;
	}
}
