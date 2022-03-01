using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001FF9 RID: 8185
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node20 : Action
	{
		// Token: 0x0601298E RID: 76174 RVA: 0x00573840 File Offset: 0x00571C40
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node20()
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
			item.skillID = 2508;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601298F RID: 76175 RVA: 0x005738D0 File Offset: 0x00571CD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C381 RID: 50049
		private List<Input> method_p0;

		// Token: 0x0400C382 RID: 50050
		private bool method_p1;
	}
}
