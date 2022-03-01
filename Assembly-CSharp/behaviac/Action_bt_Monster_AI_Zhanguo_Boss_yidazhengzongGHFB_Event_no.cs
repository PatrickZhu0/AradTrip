using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E74 RID: 15988
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzongGHFB_Event_node2 : Action
	{
		// Token: 0x0601646A RID: 91242 RVA: 0x006BC4A4 File Offset: 0x006BA8A4
		public Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzongGHFB_Event_node2()
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
			item.skillID = 20054;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601646B RID: 91243 RVA: 0x006BC534 File Offset: 0x006BA934
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCA2 RID: 64674
		private List<Input> method_p0;

		// Token: 0x0400FCA3 RID: 64675
		private bool method_p1;
	}
}
