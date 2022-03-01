using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025F6 RID: 9718
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node5 : Action
	{
		// Token: 0x06013532 RID: 79154 RVA: 0x005C0018 File Offset: 0x005BE418
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node5()
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
			item.skillID = 1108;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013533 RID: 79155 RVA: 0x005C00A8 File Offset: 0x005BE4A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF7A RID: 53114
		private List<Input> method_p0;

		// Token: 0x0400CF7B RID: 53115
		private bool method_p1;
	}
}
