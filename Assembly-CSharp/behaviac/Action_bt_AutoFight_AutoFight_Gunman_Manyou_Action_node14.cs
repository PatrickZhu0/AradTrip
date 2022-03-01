using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025FE RID: 9726
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node14 : Action
	{
		// Token: 0x06013542 RID: 79170 RVA: 0x005C03D0 File Offset: 0x005BE7D0
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node14()
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
			item.skillID = 1106;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013543 RID: 79171 RVA: 0x005C0460 File Offset: 0x005BE860
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF8E RID: 53134
		private List<Input> method_p0;

		// Token: 0x0400CF8F RID: 53135
		private bool method_p1;
	}
}
