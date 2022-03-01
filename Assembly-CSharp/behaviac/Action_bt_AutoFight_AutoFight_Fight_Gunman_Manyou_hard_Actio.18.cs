using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002175 RID: 8565
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node45 : Action
	{
		// Token: 0x06012C7B RID: 76923 RVA: 0x005855B8 File Offset: 0x005839B8
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node45()
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

		// Token: 0x06012C7C RID: 76924 RVA: 0x00585648 File Offset: 0x00583A48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C66E RID: 50798
		private List<Input> method_p0;

		// Token: 0x0400C66F RID: 50799
		private bool method_p1;
	}
}
