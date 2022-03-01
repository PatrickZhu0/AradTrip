using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020021A5 RID: 8613
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node5 : Action
	{
		// Token: 0x06012CD9 RID: 77017 RVA: 0x005882A4 File Offset: 0x005866A4
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node5()
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

		// Token: 0x06012CDA RID: 77018 RVA: 0x00588334 File Offset: 0x00586734
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6CC RID: 50892
		private List<Input> method_p0;

		// Token: 0x0400C6CD RID: 50893
		private bool method_p1;
	}
}
