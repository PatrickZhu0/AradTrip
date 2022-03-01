using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002557 RID: 9559
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node95 : Action
	{
		// Token: 0x060133F7 RID: 78839 RVA: 0x005B7854 File Offset: 0x005B5C54
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node95()
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
			item.skillID = 2513;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060133F8 RID: 78840 RVA: 0x005B78E4 File Offset: 0x005B5CE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE1D RID: 52765
		private List<Input> method_p0;

		// Token: 0x0400CE1E RID: 52766
		private bool method_p1;
	}
}
