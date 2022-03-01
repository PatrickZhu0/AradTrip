using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002523 RID: 9507
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node4 : Action
	{
		// Token: 0x0601338F RID: 78735 RVA: 0x005B61D0 File Offset: 0x005B45D0
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node4()
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
			item.skillID = 2610;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013390 RID: 78736 RVA: 0x005B6260 File Offset: 0x005B4660
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDB1 RID: 52657
		private List<Input> method_p0;

		// Token: 0x0400CDB2 RID: 52658
		private bool method_p1;
	}
}
