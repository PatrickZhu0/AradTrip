using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020021B9 RID: 8633
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node30 : Action
	{
		// Token: 0x06012D01 RID: 77057 RVA: 0x00588C10 File Offset: 0x00587010
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node30()
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
			item.skillID = 1008;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012D02 RID: 77058 RVA: 0x00588CA0 File Offset: 0x005870A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6F4 RID: 50932
		private List<Input> method_p0;

		// Token: 0x0400C6F5 RID: 50933
		private bool method_p1;
	}
}
