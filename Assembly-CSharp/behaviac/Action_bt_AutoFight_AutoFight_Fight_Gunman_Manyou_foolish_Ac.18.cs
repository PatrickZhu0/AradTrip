using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200214D RID: 8525
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node45 : Action
	{
		// Token: 0x06012C2C RID: 76844 RVA: 0x0058379C File Offset: 0x00581B9C
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node45()
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
			item.skillID = 1204;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012C2D RID: 76845 RVA: 0x0058382C File Offset: 0x00581C2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C61F RID: 50719
		private List<Input> method_p0;

		// Token: 0x0400C620 RID: 50720
		private bool method_p1;
	}
}
