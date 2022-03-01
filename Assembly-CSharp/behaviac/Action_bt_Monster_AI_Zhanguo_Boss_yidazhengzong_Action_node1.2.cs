using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E83 RID: 16003
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node16 : Action
	{
		// Token: 0x06016487 RID: 91271 RVA: 0x006BCC2C File Offset: 0x006BB02C
		public Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node16()
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
			item.skillID = 7285;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016488 RID: 91272 RVA: 0x006BCCBC File Offset: 0x006BB0BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCBE RID: 64702
		private List<Input> method_p0;

		// Token: 0x0400FCBF RID: 64703
		private bool method_p1;
	}
}
