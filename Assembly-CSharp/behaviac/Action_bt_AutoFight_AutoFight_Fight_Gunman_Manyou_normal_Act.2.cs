using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200217D RID: 8573
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node5 : Action
	{
		// Token: 0x06012C8A RID: 76938 RVA: 0x00586488 File Offset: 0x00584888
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node5()
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

		// Token: 0x06012C8B RID: 76939 RVA: 0x00586518 File Offset: 0x00584918
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C67D RID: 50813
		private List<Input> method_p0;

		// Token: 0x0400C67E RID: 50814
		private bool method_p1;
	}
}
