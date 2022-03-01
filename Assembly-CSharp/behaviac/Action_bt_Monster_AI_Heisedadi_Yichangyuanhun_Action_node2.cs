using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003554 RID: 13652
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Action_node2 : Action
	{
		// Token: 0x060152E7 RID: 86759 RVA: 0x006624B8 File Offset: 0x006608B8
		public Action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Action_node2()
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
			item.skillID = 6250;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060152E8 RID: 86760 RVA: 0x00662548 File Offset: 0x00660948
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC9E RID: 60574
		private List<Input> method_p0;

		// Token: 0x0400EC9F RID: 60575
		private bool method_p1;
	}
}
